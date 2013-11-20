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

namespace ComCon.Client.Modules.Login.Views
{
    /// <summary>
    /// Interaktionslogik für RegistrationView.xaml
    /// </summary>
    [Export("RegistrationView")]
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
