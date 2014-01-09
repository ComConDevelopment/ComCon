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
using System.Diagnostics;
using System.Reflection;


namespace speedsearch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow 

    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool website = false;
        private string sz = ".";

        

        public void tb_KeyDown(object sender, KeyEventArgs e)
        {
            

            foreach (char zeichen in sz)
            {
                if (TextBox.Text.Contains(zeichen))
                {
                    website = true;
                }
            }
            
            if (e.Key == Key.Return)
            {
                try
                {
                    if (TextBox.Text != "")
                    {
                        if (website == true)
                        {
                          Process.Start("http://" + TextBox.Text);
                        }
                        if (website == false)
                        {
                          Process.Start("http://google.de/search?q=" + TextBox.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                TextBox.Text = "";
                website = false;
            }
          
        }

       
  
    }
}
