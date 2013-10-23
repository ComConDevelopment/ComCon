using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ComCon.Client.Base.ServerService;
using System.ServiceModel;
using ComCon.Client.Base.ServerService;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using ComCon.Client.Base;

namespace ComCon.Client.Modules.Chat
{
    public class ChatModel : INotifyPropertyChanged, IServerFunctionsCallback
    {



        private readonly IEventAggregator EventAggregator;

        #region Deklaration

        private ServerFunctionsClient client = null;      
        private List<string> mChannels;
        private string mMessage;

        private string mChatText;


        #endregion

        #region Properties

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

        public List<string> Channels
        {
            get { return (mChannels); }
            set { mChannels = value; RaisePropertyChanged("Channels"); }
        }

        #endregion

        #region Konstruktor

        public ChatModel()
        {
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //EventAggregator.GetEvent<MessageReceivedHandler>().

            SendCommand = new DelegateCommand(SendMessage);

            InstanceContext context = new InstanceContext(this);
            client = new ServerFunctionsClient(context);
            client.ConnectToServer();
            Channels = client.GetChannels().ToList();
            
        }

        #endregion

        #region Events



        #endregion

        #region Diverses

        private void SendMessage()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, args) =>
                {
                    try
                    {
                        client.Send(new Base.ServerService.ChatMessage() { Message = this.Message, TimeStamp = DateTime.Now, User = "Tom" });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fehler!");
                    }
                    
                };
            bw.RunWorkerCompleted += (s, args) =>
                {
                    Message = "";
                };
            bw.RunWorkerAsync();
           
        }

        public void ShowMessage(string pMessage)
        {
            ChatText += pMessage + "\n";
            EventAggregator.GetEvent<MessageReceivedEvent>().Publish(pMessage);
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


    }

}
