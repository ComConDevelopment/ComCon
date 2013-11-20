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
using System.ServiceModel;
using ComCon.Server.Classes;

namespace ComCon.Server
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost sh;

        

        public MainWindow()
        {
            LoggingService.LogEvent += LoggingService_LogEvent;
            InitializeComponent();
        }

        void LoggingService_LogEvent(object sender, LoggingEventArgs data)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                Log(data.LogString, data.Status);
            }), System.Windows.Threading.DispatcherPriority.Send);         
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sh = new ServiceHost((typeof(ComConServer)));
                sh.Open();
                LoggingService.Log("Server gestartet", LogStatus.INFO);
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex.Message, LogStatus.WARNING);
            }
        }

        private void Log(string pText, LogStatus pStatus)
        {
            switch (pStatus)
            {
                case LogStatus.ERROR:
                    textBox1.AppendText("[ERROR] " + pText + "\n");
                    break;
                case LogStatus.INFO:
                    textBox1.AppendText("[INFO] " + pText + "\n");
                    break;
                case LogStatus.WARNING:
                    textBox1.AppendText("[WARNING] " + pText + "\n");
                    break;

            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sh.Close();
                LoggingService.Log("Server beendet", LogStatus.INFO);
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex.Message, LogStatus.ERROR);
            }
        }
    }


}
