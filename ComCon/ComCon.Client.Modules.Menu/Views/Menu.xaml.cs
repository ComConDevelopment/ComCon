using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComCon.Client.Modules.Menu
{
    /// <summary>
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    [Export]
    public partial class Menu : UserControl
    {
        private List<string> mMenuItems = new List<string>();

        public List<string> CurrentItems
        {
            get { return mMenuItems; }
            set { mMenuItems = value; }
        }



        public Menu()
        {
            CurrentItems.Add("Test1");
            CurrentItems.Add("Test2");
            CurrentItems.Add("Test3");
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
