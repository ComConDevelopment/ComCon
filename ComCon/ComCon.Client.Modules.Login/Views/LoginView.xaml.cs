using System;
using System.Collections.Generic;
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
using ComCon.Client.Modules.Login.Models;
using System.ComponentModel.Composition;

namespace ComCon.Client.Modules.Login.Views
{
    /// <summary>
    /// Interaktionslogik für LoginView.xaml
    /// </summary>
    [Export]
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            this.DataContext = new LoginModel();
            InitializeComponent();
        }
    }
}
