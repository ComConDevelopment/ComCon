using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Client.Contracts.Interfaces
{
    public interface IMenuItem : INotifyPropertyChanged
    {
        string Header { get; set; }
        ObservableCollection<ISubMenuItem> ChildItems { get; set; }

    }
}
