using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P42.Models
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Deklaration


        #endregion

        #region Properties



        #endregion

        #region Konstruktor

        public ViewModelBase()
        {

        }

        #endregion

        #region Events

        public virtual void OverrideMe()
        {

        }

        #endregion

        #region Diverses

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

        #endregion
    }
}
