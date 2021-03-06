﻿using ComCon.Client.Modules.Login.Models;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
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
    /// Interaktionslogik für LoginView.xaml
    /// </summary>
    [Export]
    public partial class LoginView : UserControl
    {
        private IEventAggregator EventAggregator;

        public LoginView()
        {
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this.DataContext = new LoginModel();
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<Events.PasswordChangedEvent>().Publish(ComCon.Shared.Classes.Crypter.Crypt((sender as PasswordBox).Password));
        }
    }
}
