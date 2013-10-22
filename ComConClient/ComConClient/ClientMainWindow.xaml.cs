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
using ComConClient.MessageService;
using ComCon.Shared.Classes;

namespace ComConClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServerFunctionsCallback
    {
        ServerFunctionsClient client = null;

        public MainWindow()
        {
            InitializeComponent();
            InstanceContext context = new InstanceContext(this);
            client = new ServerFunctionsClient(context);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            client.ConnectToServer("Test", "asdf");
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (client.State == CommunicationState.Opened)
            {
                ChatMessage cm = new ChatMessage();
                cm.Message = textBox2.Text;
                cm.TimeStamp = DateTime.Today;
                cm.User = new ChatUser() { Username = "Test" };
                client.Send(cm);
            }
            else
            {
                ShowMessage("Nicht eingeloggt!");
            }
        }

        public void ShowMessage(string pMessage)
        {
            
        }
    }
    
}
