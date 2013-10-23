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
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sh = new ServiceHost((typeof(ServerFunctions)));
                sh.Open();
                Log("Server gestartet");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void Log(string pText)
        {
            textBox1.AppendText("[INFO] " + pText + "\n");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sh.Close();
                Log("Server beendet");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}
