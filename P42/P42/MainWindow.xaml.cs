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
using System.Runtime.InteropServices;
using System.Windows.Interop;


namespace P42
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();

        }

        private bool suche = false;
        private bool website = false;
        private bool starte = false;
        private bool rechner = false;
        private bool wecker = false;
        private bool schalte = false;
        private bool kalender = false;
        private bool enter = false;

        private string sz = ".";
        

        //[DllImport("User32.dll")]
        //private static extern bool RegisterHotKey(
        //    [In] IntPtr hWnd,
        //    [In] int id,
        //    [In] uint fsModifiers,
        //    [In] uint vk);

        //[DllImport("User32.dll")]
        //private static extern bool UnregisterHotKey(
        //    [In] IntPtr hWnd,
        //    [In] int id);

        //private HwndSource _source;
        //private const int HOTKEY_ID = 9000;



        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    var helper = new WindowInteropHelper(this);
        //    _source = HwndSource.FromHwnd(helper.Handle);
        //    _source.AddHook(HwndHook);
        //    RegisterHotKey();
        //}

        //protected override void OnClosed(EventArgs e)
        //{
        //    _source.RemoveHook(HwndHook);
        //    _source = null;
        //    UnregisterHotKey();
        //    base.OnClosed(e);
        //}

        //private void RegisterHotKey()
        //{
        //    var helper = new WindowInteropHelper(this);
        //    const uint VK_F10 = 0x79;
        //    const uint MOD_CTRL = 0x0002;
        //    if (!RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_CTRL, VK_F10))
        //    {
        //        // handle error
        //    }
        //}

        //private void UnregisterHotKey()
        //{
        //    var helper = new WindowInteropHelper(this);
        //    UnregisterHotKey(helper.Handle, HOTKEY_ID);
        //}

        //private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    const int WM_HOTKEY = 0x0312;

        //    switch (msg)
        //    {
        //        case WM_HOTKEY:
        //            switch (wParam.ToInt32())
        //            {
        //                case HOTKEY_ID:
        //                    OnHotKeyPressed();
        //                    handled = true;
        //                    break;
        //            }
        //            break;
        //    }
        //    return IntPtr.Zero;
        //}

        //private void OnHotKeyPressed()
        //{
        //    App.Current.MainWindow.Show();
        //}

        private List<string> mKeywords = new List<string>();
        public List<string> Keywords
        {
            get { return mKeywords; }
            set { mKeywords = value; }
        }

        public void tb_KeyDown(object sender, KeyEventArgs e)
        {


            //foreach (char zeichen in sz)
            //{
            //    if (TextBox.Text.Contains(zeichen))
            //    {
            //        website = true;
            //    }
            //}

            if (e.Key == Key.Return)
            {
                enter = true;
                string text = TextBox.Text;
                text = text.ToLower();
                trechner.Content = "";
                int c = 0;

                Keywords.Add("starte");
                Keywords.Add("schalte");
                

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Equals(' '))
                    {
                        c = i;
                    }

                    if (text[i].Equals('.'))
                    {
                        website = true;
                    }

                    if (text[i].Equals('+') | text[i].Equals('-') | text[i].Equals('*') | text[i].Equals('/'))
                    {
                        rechner = true;
                    }
                    

                }
                string web = text;
                string befehl = text.Substring(c + 1);
                text = text.Substring(0, c);
                foreach (string s in Keywords)
                {
                    
                    if (DamerauLevenshtein.DamerauLevenshteinDistance(s, text) <= 2)
                    {
                        switch (s.ToLower())
                        {
                            case "starte":
                                starte = true;                             
                                break;
                            case "schalte":
                                schalte = true;
                                break;

                        }
                    }
                }


                    if (website == false && starte == false && rechner == false)
                    {
                        suche = true;
                    }



                try
                {
                    if (TextBox.Text != "")
                    {
                        //string text = TextBox.Text;
                        //text = text.Substring(2);

                        //Webseite aufrufen
                        if (website == true)
                        {
                            Process.Start("http://" + web);
                        }
                        //Google Suche
                        if (suche == true)
                        {
                            Process.Start("http://google.de/search?q=" + web);
                        }
                        //Programm starten
                        if (starte == true)
                        {
                            text = text.Substring(6);
                            Process.Start(befehl + ".exe");                            
                        }
                        //Taschenrechner
                        if (rechner == true)
                        {
                            string[] sNumbers = TextBox.Text.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);

                            Double result = 0;

                            foreach (string number in sNumbers)
                            {
                                if (Char.IsNumber(TextBox.Text[0]))
                                    result += Double.Parse(number);
                                else
                                {
                                    switch (TextBox.Text[0])
                                    {
                                        case '+':
                                            result += Double.Parse(number);
                                            break;
                                        case '-':
                                            result -= Double.Parse(number);
                                            break;
                                        case '*':
                                            result *= Double.Parse(number);
                                            break;
                                        case '/':
                                            result /= Double.Parse(number);
                                            break;
                                    }
                                    TextBox.Text = TextBox.Text.Remove(0, 1);
                                }
                                TextBox.Text = TextBox.Text.Remove(TextBox.Text.IndexOf(number), number.Length);
                            }

                            string ergebnis = result.ToString();
                            trechner.Content = ergebnis;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }


                TextBox.Text = "";
                website = false;
                suche = false;
                starte = false;
                rechner = false;
                

                //if (enter == true)
                //{
                //    App.Current.MainWindow.Hide();
                //}


            }

        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }



    }

    //LevenshteinDistance
    static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }


    }

    public static class DamerauLevenshtein
    {
        public static int DamerauLevenshteinDistanceTo(this string @string, string targetString)
        {
            return DamerauLevenshteinDistance(@string, targetString);
        }

        public static int DamerauLevenshteinDistance(string string1, string string2)
        {
            if (String.IsNullOrEmpty(string1))
            {
                if (!String.IsNullOrEmpty(string2))
                    return string2.Length;

                return 0;
            }

            if (String.IsNullOrEmpty(string2))
            {
                if (!String.IsNullOrEmpty(string1))
                    return string1.Length;

                return 0;
            }

            int length1 = string1.Length;
            int length2 = string2.Length;

            int[,] d = new int[length1 + 1, length2 + 1];

            int cost, del, ins, sub;

            for (int i = 0; i <= d.GetUpperBound(0); i++)
                d[i, 0] = i;

            for (int i = 0; i <= d.GetUpperBound(1); i++)
                d[0, i] = i;

            for (int i = 1; i <= d.GetUpperBound(0); i++)
            {
                for (int j = 1; j <= d.GetUpperBound(1); j++)
                {
                    if (string1[i - 1] == string2[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    del = d[i - 1, j] + 1;
                    ins = d[i, j - 1] + 1;
                    sub = d[i - 1, j - 1] + cost;

                    d[i, j] = Math.Min(del, Math.Min(ins, sub));

                    if (i > 1 && j > 1 && string1[i - 1] == string2[j - 2] && string1[i - 2] == string2[j - 1])
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }
    }

}