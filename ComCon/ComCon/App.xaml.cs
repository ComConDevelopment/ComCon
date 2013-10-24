using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using ComCon.Client.Base;

namespace ComCon
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private IEventAggregator EventAggregator;

        protected override void OnExit(ExitEventArgs e)
        {
            EventAggregator.GetEvent<OnExitEvent>().Publish("Application exit");
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            
        }
    }
}
