using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ComCon.Client.Base.ServerService;
using System.ServiceModel;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using ComCon.Client.Base;
using System.Windows.Documents;
using System.Windows.Media;
using ComCon.Client.Base.Helpers;
using Microsoft.Practices.Prism.Modularity;
using ComCon.Client.Base.Classes;

namespace ComCon.Client.Modules.Chat.Models
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public class ChatModel : INotifyPropertyChanged, IChatServerFunctionsCallback
    {
        #region Deklaration

        private ChatServerFunctionsClient client = null;
        private List<User> mUsers;
        private string mMessage;
        private string mChatText;
        private readonly IEventAggregator EventAggregator;
        private bool mIsLoggedIn;

        public bool IsBusy { get { return Global.IsBusy; } set { Global.IsBusy = value; RaisePropertyChanged("IsBusy"); } }


        private string mBusyText = "Lädt...";


        #endregion

        #region Properties

        public string BusyText
        {
            get { return (mBusyText); }
            set { mBusyText = value; RaisePropertyChanged("BusyText"); }
        }

        public bool IsLoggedIn
        {
            get { return mIsLoggedIn; }
            set { mIsLoggedIn = value; }
        }


        public string ChatText
        {
            get { return (mChatText); }
            set { mChatText = value; RaisePropertyChanged("ChatText"); }
        }

        public string Message
        {
            get { return (mMessage); }
            set { mMessage = value; RaisePropertyChanged("Message"); }
        }

        public DelegateCommand SendCommand { get; private set; }

        public List<User> Users
        {
            get { return (mUsers); }
            set { mUsers = value; RaisePropertyChanged("Users"); }
        }

        #endregion

        #region Konstruktor

        public ChatModel()
        {
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this.EventAggregator.GetEvent<OnExitEvent>().Subscribe(OnAppExit);
            //this.EventAggregator.GetEvent<OnLoginEvent>().Subscribe(Login, true);
            SendCommand = new DelegateCommand(SendMessage);


            InstanceContext context = new InstanceContext(this);
            client = new ChatServerFunctionsClient(context);
            try
            {
                client.Open();
                BusyText = "Verbinde zu Server";
                client.ConnectToServerAsync(Global.Credentials);
                client.ConnectToServerCompleted += (s, args) =>
                {                    
                    EventAggregator.GetEvent<OnLoginEvent>().Subscribe(OnLogin);
                    try
                    {
                        Users = client.get_LoggedInUsers().ToList();
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    IsBusy = false;
                };

            }
            catch (Exception e)
            {
                ShowMessage(new ChatMessage() { User = new User() { Username = "Server" }, Message = "Fehler beim Einloggen!\r\n" + e.Message });
            }


            
            

            
        }

        

        #endregion

        #region Events

        void OnAppExit(string pMessage)
        {
            try
            {
                if (client != null)
                {
                    client.DisconnectFromServer();
                    client.Close();
                }
            }
            catch (Exception)
            {
                
            }

        }

        void OnLogin(string pMessage)
        {
            try
            {
                
            }
            catch (Exception)
            {
            }
            
        }

        #endregion

        #region Diverses
            

        private void SendMessage()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, args) =>
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(this.Message))
                        {
                            //ChatUser u = client.GetUser(Global.Credentials);
                            client.Send(new Base.ServerService.ChatMessage() { Message = this.Message, TimeStamp = DateTime.Now, User = Global.User });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                };
            bw.RunWorkerCompleted += (s, args) =>
                {
                    Message = "";
                };
            bw.RunWorkerAsync();
           
        }


        public void ShowMessage(Base.ServerService.ChatMessage cm)
        {
            EventAggregator.GetEvent<MessageReceivedEvent>().Publish(cm);
        }

        

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        #endregion

        public IAsyncResult BeginShowMessage(ChatMessage cm, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndShowMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUpdateUserList(AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUpdateUserList(IAsyncResult result)
        {
            throw new NotImplementedException();
        }


        public void UpdateUserList()
        {
            //this.Users = client.GetUsers().ToList();
        }
    }

}
