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
using System.Windows.Threading;
using ComCon.Modulization;
using FirstFloor.ModernUI.Windows;

namespace ComCon.Client.Modules.Chat
{
    /// <summary>
    /// Interaktionslogik für ChatControl.xaml
    /// </summary>
    /// 
    [Content("/Chat")]
    public partial class ChatControl : UserControl, IContent
    {
        private delegate void MyDelegate();
        public ChatControl()
        {


        }


        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
           
        }
    }
}
