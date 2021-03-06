﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Client.Base.ServerService;
using System.Collections.ObjectModel;

namespace ComCon.Client.Base.Classes
{
    public class Global
    {

        #region Deklaration

        private static bool mIsLoggedIn;
        private static bool mIsBusy;

        #endregion

        #region Properties        

        public static bool IsLoggedIn
        {
            get
            {
                return Global.User != null;
            }
        }

        private static ObservableCollection<string> mLoadedModules = new ObservableCollection<string>();
        public static ObservableCollection<string> LoadedModules
        {
            get { return mLoadedModules; }
            set { mLoadedModules = value; }
            
        }

        public static bool IsBusy
        {
            get { return mIsBusy; }
            set { mIsBusy = value; }
        }

        private static User mUser;

        public static User User
        {
            get { return mUser; }
            set { mUser = value; }
        }

        private static Credentials mCredentials;

        public static Credentials Credentials
        {
            get { return mCredentials; }
            set { mCredentials = value; }
        }



        #endregion

        #region Konstruktor



        #endregion

        #region Events



        #endregion

        #region Diverses



        #endregion


    }
}
