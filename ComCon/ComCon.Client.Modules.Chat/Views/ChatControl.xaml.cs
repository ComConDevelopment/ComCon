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

namespace ComCon.Client.Modules.Chat
{
    /// <summary>
    /// Interaktionslogik für ChatControl.xaml
    /// </summary>
    /// 
    [Export]
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            this.DataContext = new ChatModel();
            InitializeComponent();
        }
    }
}
