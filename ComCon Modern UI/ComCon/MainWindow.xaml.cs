using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using System.ComponentModel.Composition;

namespace ComCon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class MainWindow : ModernWindow
    {
        public IEventAggregator pAggregator
        {
            set
            {
                (this.DataContext as ShellViewModel).EventAggregator = value;
                (this.DataContext as ShellViewModel).Init();
            }
        }
        public MainWindow()
        {
            this.DataContext = new ShellViewModel();
            InitializeComponent();
            AppearanceManager.Current.ThemeSource = AppearanceManager.DarkThemeSource;
            this.Closed += MainWindow_Closed;
        }

        void MainWindow_Closed(object sender, System.EventArgs e)
        {
            App.Current.Shutdown(0);
        }
    }
}
