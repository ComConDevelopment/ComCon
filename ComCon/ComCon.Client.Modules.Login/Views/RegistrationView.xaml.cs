using ComCon.Client.Modules.Login.Classes;
using ComCon.Client.Modules.Login.Models;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
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
    /// Interaktionslogik für RegistrationView.xaml
    /// </summary>
    [Export("RegistrationView")]
    public partial class RegistrationView : UserControl, INavigationAware
    {
        private IEventAggregator EventAggregator;

        public RegistrationView()
        {
            this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<Events.PasswordChangedEvent>().Publish(ComCon.Shared.Classes.Crypter.Crypt((sender as PasswordBox).Password));
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            EventAggregator.GetEvent<Events.PasswordVerificationChangedEvent>().Publish(ComCon.Shared.Classes.Crypter.Crypt((sender as PasswordBox).Password));
        }



        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            int hash = int.Parse(navigationContext.Parameters["hash"]);
            this.DataContext = (LoginModel)Parameters.Request(hash);
        }
    }
}
