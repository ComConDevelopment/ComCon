using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Timers;
using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;


namespace Project42
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
        public SpeechSynthesizer ss = new SpeechSynthesizer();
        public bool startblock;

        public MainWindow()
        {
            InitializeComponent();
            startblock = true;
                     
        }



        //Spracherkennung starten
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (startblock == true)
            {

                //Keywords add start
                Keywords.Add("Computer");
                //Keywords add zeit
                Keywords.Add("Uhrzeit");                
                Keywords.Add("Datum");
                //Keywords add wetter
                Keywords.Add("Wetter");
                //Keywords add screenshot
                Keywords.Add("Screenshot");


                //Locations add
                Locations.Add("Wohnzimmer");
                Locations.Add("Küche");




                sage("Hallo Sir, ich bin nun bereit.");
                sr.SetInputToDefaultAudioDevice();
                sr.LoadGrammar(new DictationGrammar());
                sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
                sr.RecognizeAsync(RecognizeMode.Multiple);
                
                startblock = false;
                
            }
            
        }
            

        //Spracherkennung stoppen
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {            
            sr.RecognizeAsyncStop();
            sage("Ich melde mich nun ab, auf Wiedersehen Sir!");
            this.Close();
        }


        //Sprachausgabe mit "sage"
        public void sage(string input)
        {
            var sayThis = new Prompt(input);
            ss.Speak(sayThis);
        }

        // Funktionen ----------------------------------------------------------------------------------

        //Ordner und Datei Struktur für Screenshots

        public string screenshot
        {
            get
            {
                string date = DateTime.Now.ToString("ddMMyyyy");
                string time = DateTime.Now.ToString("HHmmss");
                string UserName = Environment.UserName;
                string folderName = @"C:\Users";
                string pictures = "Pictures";
                string screenshot = "Screenshot";
                string folderPath = System.IO.Path.Combine(folderName, UserName, pictures, screenshot);
                string fileName = time + " " + date + ".Jpeg";

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo info = Directory.CreateDirectory(folderPath);
                }

                folderPath = System.IO.Path.Combine(folderPath, fileName);
                return folderPath;
            }
        }

        //Screenshot erstellen
        public void makeScreenshot()
        {
            //Größe des Bildes wird an Auflösung angepasst
            Bitmap shot = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            Graphics screenShot = Graphics.FromImage(shot);
            //Screenshot wird erstellt
            screenShot.CopyFromScreen(0, 0, 0, 0, shot.Size);

            //Ablageort wird erstellt

           

            
            //Screenshot wird gepeichert
            shot.Save(screenshot, ImageFormat.Jpeg);
        }






        //----------------------------------------------------------------------------------------------


        //Pool of Words

        private bool mRecognizing;

        private List<string> mRecognizedLocation = new List<string>();

        public List<string> RecognizedLocation
        {
            get { return mRecognizedLocation; }
            set { mRecognizedLocation = value; }
        }

         
        private List<string> mRecognizedOperation = new List<string>();

        public List<string> RecognizedOperation
        {
            get { return mRecognizedOperation; }
            set { mRecognizedOperation = value; }
        }


        private List<string> mRecognizedItem = new List<string>();

        public List<string> RecognizedItem
        {
            get { return mRecognizedItem; }
            set { mRecognizedItem = value; }
        }



        private List<string> mLocations = new List<string>();

        public List<string> Locations
        {
            get { return mLocations; }
            set { mLocations = value; }
        }

        private List<string> mKeywords = new List<string>();

        public List<string> Keywords
        {
            get { return mKeywords; }
            set { mKeywords = value; }
        }

        

        private List<string> mWords = new List<string>();

        public List<string> Words
        {
            get { return mWords; }
            set { mWords = value; }
        }


        //zuhören und umsetzen
        public void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            foreach (RecognizedWordUnit word in e.Result.Words)
            {

                foreach (string s in Keywords)
                {

                    if (s == "Computer")
                    {
                        mRecognizing = true;
                        sage("Was kann ich für Sie tun?");
                    }

                    if (mRecognizing)
                    {
                        TimeSpan timeout = TimeSpan.FromSeconds(10);
                        DateTime start_time = DateTime.Now;
                        if (DateTime.Now - start_time < timeout)
                        {
                            switch (s.ToLower())
                            {
                                case "uhrzeit":
                                    sage("Es ist " + System.DateTime.Now.ToShortTimeString());
                                    break;
                                case "datum":
                                    sage("Heute ist der " + System.DateTime.Now.ToShortDateString());
                                    break;
                                case "wetter":
                                    XPathDocument doc = new XPathDocument("http://weather.yahooapis.com/forecastrss?w=649939u=c");
                                    XPathNavigator navigator = doc.CreateNavigator();
                                    XmlNamespaceManager ns = new XmlNamespaceManager(navigator.NameTable);
                                    ns.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");
                                    XPathNodeIterator nodes = navigator.Select("/rss/channel/item/yweather:condition", ns);
                                    while (nodes.MoveNext())
                                    {
                                        XPathNavigator node = nodes.Current;

                                        sage((node.GetAttribute("text", ns.DefaultNamespace) + "  " + // Wetter
                                            node.GetAttribute("temp", ns.DefaultNamespace) + " Grad")); // für Temperatur

                                        //node.GetAttribute("high", ns.DefaultNamespace) 
                                        //node.GetAttribute("day", ns.DefaultNamespace)
                                        //node.GetAttribute("low", ns.DefaultNamespace) 
                                    }
                                    break;
                                case "screenshot":
                                    makeScreenshot();
                                    string anzeige = screenshot;
                                    sage("Ich habe einen Screenshot erstellt, soll ich ihn anzeigen?");
                                    switch (s.ToLower())
                                    {
                                        case "ja":
                                            sage("Hier ist der eben erstellte Screenshot:");
                                            Process.Start(anzeige);
                                            break;
                                        case "nein":
                                            sage("Kann ich noch etwas für Sie tun?");
                                            break;
                                    }
                                    break;



                                default:
                                    break;

                            }

                        }
                        else
                        {
                            mRecognizing = false;
                        }


                    }

                }

                
            }
        }





    }
}
