using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Client.Base.Classes;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using ComCon.Client.Base.Helpers;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using Microsoft.Practices.Prism.Modularity;

namespace ComCon.Client.Modules.Login.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        #region Deklaration

        private readonly IEventAggregator EventAggregator;

        #endregion

        #region Properties

        public DelegateCommand LoginCommand { get; private set; }


        private string mName;
        public string Name
        {
            get { return (mName); }
            set { mName = value; RaisePropertyChanged("Name"); }
        }

        #endregion

        #region Konstruktor

        public LoginModel()
        {
            LoginCommand = new DelegateCommand(Login);
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        #endregion

        #region Events



        #endregion

        #region Diverses

        public void Login()
        {
            Global.IsBusy = true;
            Global.IsLoggedIn = true;
            Global.User = new Base.ServerService.ChatUser()
            {
                Username = Name,
                IsVisible = true
            };


            var moduleLoader = ServiceLocator.Current.GetInstance<IModuleManager>();
            EventAggregator.GetEvent<OnLoginEvent>().Publish(Global.User);
            moduleLoader.LoadModule("ClientChatModule");
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
