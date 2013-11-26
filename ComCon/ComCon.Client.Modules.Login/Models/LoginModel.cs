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
using System.Security;
using Microsoft.Practices.Prism.Regions;
using ComCon.Client.Base.ServerService;
using System.Windows;
using com.dominicsayers.isemail;
using ComCon.Client.Modules.Login.Classes;
using Microsoft.Practices.Prism;
using System.ComponentModel.DataAnnotations;
using ComCon.Client.Base;

namespace ComCon.Client.Modules.Login.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        #region Deklaration

        private readonly IEventAggregator EventAggregator;
        private MainServerFunctionsClient client = new MainServerFunctionsClient();
        private string mName;
        private string mPassword;
        private string mPasswordVerification;
        private string mEMail;
        private string mValidationText;

        #endregion

        #region Properties

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand RegisterCommand { get; private set; }
        public DelegateCommand ShowRegisterViewCommand { get; private set; }
        public readonly IRegionManager RegionManager;

        [Required(ErrorMessage = "Passwort muss angegeben werden!")]
        public string Password
        {
            get { return (mPassword); }
            set { mPassword = value; RaisePropertyChanged("Password"); }
        }

        [Required(ErrorMessage = "Passwort muss angegeben werden!")]
        public string PasswordVerification
        {
            get { return (mPasswordVerification); }
            set { mPasswordVerification = value; RaisePropertyChanged("PasswordVerification"); }
        }
        
        [Required(ErrorMessage = "E-Mail muss angegeben werden!")]
        [StringLength(50, ErrorMessage = "E-Mail darf nicht länger als 50 Zeichen sein!")]
        public string EMail
        {
            get { return (mEMail); }
            set { mEMail = value; RaisePropertyChanged("EMail"); }
        }
        
        public string ValidationText
        {
            get { return (mValidationText); }
            set { mValidationText = value; RaisePropertyChanged("ValidationText"); }
        }

        public bool IsBusy { get { return Global.IsBusy; } set { Global.IsBusy = value; RaisePropertyChanged("IsBusy"); } }

        #endregion

        #region Konstruktor

        public LoginModel()
        {

            LoginCommand = new DelegateCommand(doBackWorking);
            RegisterCommand = new DelegateCommand(Register);
            ShowRegisterViewCommand = new DelegateCommand(ShowRegistrationView);
            this.RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this.EventAggregator.GetEvent<Events.PasswordChangedEvent>().Subscribe(PasswordChanged);
            this.EventAggregator.GetEvent<Events.PasswordVerificationChangedEvent>().Subscribe(PasswordVerificationChanged);
            
        }

        #endregion

        #region Events

        private void PasswordChanged(string pPassword)
        {
            Password = pPassword;
        }

        private void PasswordVerificationChanged(string pPassword)
        {
            PasswordVerification = pPassword;
        }

        #endregion

        #region Diverses


        #region BackgroundWorker

        private System.ComponentModel.BackgroundWorker mBackWorker = new System.ComponentModel.BackgroundWorker();

        private void doBackWorking()
        {
            mBackWorker.DoWork += new DoWorkEventHandler(mBackWorker_DoWork);
            mBackWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(mBackWorker_RunWorkerCompleted);
            mBackWorker.RunWorkerAsync();
        }

        private void mBackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Login();
        }

        private void mBackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Global.IsLoggedIn)
            {
                var moduleLoader = ServiceLocator.Current.GetInstance<IModuleManager>();
                moduleLoader.LoadModule("ClientChatModule");
            }
        }

        #endregion

        public void Login()
        {
            
            IsBusy = true;

            try
            {
                Global.Credentials = new Base.ServerService.Credentials()
                {
                    Email = this.EMail,
                    Password = this.Password
                };
                User u = client.Authenticate(Global.Credentials);
                if (u != null)
                {
                    Global.User = u;

                }
                else
                {
                    ValidationText = "Fehler - Username oder Passwort falsch!";
                }

            }
            catch (Exception ex)
            {
                ValidationText = "Fehler. ComCon-Server nicht erreichbar!";
            }
            finally
            {
                IsBusy = false;
            }


            
        }

        public void Register()
        {
            ValidationText = "";
            if (PasswordVerification == Password && PasswordVerification != null)
            {
                IsEMail isEmail = new IsEMail();
                if (isEmail.IsEmailValid(EMail))
                {
                    if (client.RegisterUser(new Credentials() { Email = this.EMail, Password = this.Password }))
                    {
                        MessageBox.Show("Registrierung erfolgreich!");
                    }
                }
                else
                {
                    ValidationText = "Die E-Mail Adresse hat das falsche Format!";
                }
            }
            else
            {
                ValidationText = "Passwörter sind nicht gleich!";
            }
            
        }

        public void ShowRegistrationView()
        {
            ValidationText = "";
            Parameters.Save(this.GetHashCode(), this);
            UriQuery q = new UriQuery();
            q.Add("hash", this.GetHashCode().ToString());
            RegionManager.Regions["MainRegion"].RequestNavigate(new Uri("RegistrationView" + q.ToString(), UriKind.RelativeOrAbsolute));

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
