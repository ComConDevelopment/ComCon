using P42.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P42.UserControls
{
    /// <summary>
    /// Interaktionslogik für GoogleControl.xaml
    /// </summary>
    public partial class GoogleControl : UserControl
    {
        public GoogleControl()
        {
            InitializeComponent();
            this.DataContext = new GoogleSearchModel();
        }
    }
}
