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
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using ComCon.Client.Base;
using ComCon.Client.Base.ServerService;

namespace ComCon.Client.Modules.Chat
{
    /// <summary>
    /// Interaktionslogik für ChatControl.xaml
    /// </summary>
    /// 
    [Export]
    public partial class ChatControl : UserControl
    {
        private readonly IEventAggregator EventAggregator;

        public ChatControl()
        {
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this.DataContext = new ComCon.Client.Modules.Chat.Models.ChatModel();
            InitializeComponent();

            EventAggregator.GetEvent<MessageReceivedEvent>().Subscribe(MessageReceived);

        }

        public void MessageReceived(ChatMessage pMessage)
        {
            switch (pMessage.User.Username)
            {
                case "Server":
                    AppendTextToRTB("<" + pMessage.User.Username + "> " + pMessage.Message, new SolidColorBrush(Colors.Green));
                    break;
                default:
                    AppendTextToRTB("<" + pMessage.User.Username + "> " + pMessage.Message, new SolidColorBrush(Colors.Black));
                    break;
            }
            

        }


        public void AppendTextToRTB(string pText, SolidColorBrush pColor)
        {
            Run r = new Run();
            r.Text = pText;
            r.Foreground = pColor;
            Paragraph p = new Paragraph(r);
            p.Margin = new Thickness(0);
            ChatBox.Document.Blocks.Add(p);
        }


    }
}
