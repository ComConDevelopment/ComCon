using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Shared.Classes.Main
{
    [Serializable]
    public class Profile : INotifyPropertyChanged
    {

        #region Deklaration

        private int mID = 0;

        private string mMail;

        private string mPassword;

        private string mUsername;

        private string mPicture;

        private string mDescription;

        private int mAge = 0;

        private int mRole = 0;

        private string mCountry;

        private bool mIsProfileOpen;

        #endregion



        #region Properties

        [JsonProperty("ID")]
        public int ID
        {
            get { return (mID); }
            set { mID = value; RaisePropertyChanged("ID"); }
        }

        [JsonProperty("Mail")]
        public string Mail
        {
            get { return (mMail); }
            set { mMail = value; RaisePropertyChanged("Mail"); }
        }

        [JsonProperty("Password")]
        public string Password
        {
            get { return (mPassword); }
            set { mPassword = value; RaisePropertyChanged("Password"); }
        }

        [JsonProperty("Username")]
        public string Username
        {
            get { return (mUsername); }
            set { mUsername = value; RaisePropertyChanged("Username"); }
        }

        [JsonProperty("Picture")]
        public string Picture
        {
            get { return (mPicture); }
            set { mPicture = value; RaisePropertyChanged("Picture"); }
        }

        [JsonProperty("Description")]
        public string Description
        {
            get { return (mDescription); }
            set { mDescription = value; RaisePropertyChanged("Description"); }
        }

        [JsonProperty("Age")]
        public int Age
        {
            get { return (mAge); }
            set { mAge = value; RaisePropertyChanged("Age"); }
        }

        [JsonProperty("Role")]
        public int Role
        {
            get { return (mRole); }
            set { mRole = value; RaisePropertyChanged("Role"); }
        }

        [JsonProperty("Country")]
        public string Country
        {
            get { return (mCountry); }
            set { mCountry = value; RaisePropertyChanged("Country"); }
        }

        [JsonProperty("IsProfileOpen")]
        public bool IsProfileOpen
        {
            get { return (mIsProfileOpen); }
            set { mIsProfileOpen = value; RaisePropertyChanged("IsProfileOpen"); }
        }


        #endregion

        #region Konstruktor

        public Profile()
        {

        }

        #endregion

        #region Events



        #endregion

        #region Diverses



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
