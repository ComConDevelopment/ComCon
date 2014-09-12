using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Modules.Main.Classes
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase(IEventAggregator pAggregator)
        {

        }


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
