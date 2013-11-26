using ComCon.Client.Modules.Menu.Models;
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

        public Menu()
        {

            this.DataContext = new MenuModel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(this.DataContext as MenuModel).MenuItems[MainListBox.SelectedIndex].OnMenuItemClicked(this, new Classes.MenuItemClickedEventArgs((this.DataContext as MenuModel).MenuItems[MainListBox.SelectedIndex].CorrelatedView, (this.DataContext as MenuModel).MenuItems[MainListBox.SelectedIndex].CorrelatedRegion));
        }
    }
}
