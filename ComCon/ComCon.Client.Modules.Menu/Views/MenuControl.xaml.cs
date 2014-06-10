using ComCon.Client.Base.Classes;
using ComCon.Client.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComCon.Client.Modules.Menu.Views
{
    /// <summary>
    /// Interaktionslogik für MenuControl.xaml
    /// </summary>
    /// 
    [Export]
    public partial class MenuControl : UserControl
    {


        private ViewModelBase mViewModel;

        public ViewModelBase ViewModel
        {
            get { return mViewModel; }
            set { mViewModel = value; this.DataContext = value; }
        }

        public MenuControl()
        {
            InitializeComponent();
        }
    }
}
