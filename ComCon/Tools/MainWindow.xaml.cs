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
using ComCon.Shared.Classes;
using Npgsql;
using System.ComponentModel;

namespace Tools
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        private string mStatus;
        public string Status
        {
            get { return (mStatus); }
            set { mStatus = value; RaisePropertyChanged("Status"); }
        }

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textbox2.Text = Crypter.Crypt(textbox1.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Status = "Öffne Verbindung...";
            NpgsqlConnection conn = new NpgsqlConnection(String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4}", tbHost.Text, tbPort.Text, tbUser.Text, tbPass.Password, tbDataBaseName.Text));
            try
            {
                
                conn.Open();
                Status = "Verbindung geöffnet!";
            }
            catch (Exception ex)
            {
                Status = "Verbindung fehlgeschlagen";
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        #endregion
    }
}
