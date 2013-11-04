using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComCon.Client.Base.ServerService;

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
            get { return mIsLoggedIn; }
            set { mIsLoggedIn = value; }
        }

        

        public static bool IsBusy
        {
            get { return mIsBusy; }
            set { mIsBusy = value; }
        }

        private static ChatUser mUser;

        public static ChatUser User
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
