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

namespace ComConServer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class ServerMainWindow : Window
    {
        ServiceHost sh = new ServiceHost(typeof(MessageService));

        public ServerMainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sh = new ServiceHost(typeof(MessageService));
            sh.Open();
            textBox1.AppendText("Server gestartet\n");
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            sh.Close();
            textBox1.AppendText("Server gestoppt\n");
        }
    }
}
