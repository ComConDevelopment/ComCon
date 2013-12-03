using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace Spracherkennung
{
    public class SpeechRecognizer
    {

        public delegate void AllRecognizedHandler(object sender, EventArgs args);
        public event AllRecognizedHandler AllRecognized;

        public void OnAllRecognized(object sender, EventArgs args)
        {
            if (AllRecognized != null)
            {
                AllRecognized(sender, args);
            }
        }

        public SpeechRecognizer()
        {
            foreach (ILocation loc in Locations)
            {
                loc.Items.Add(new Item("Licht"));
                loc.Items.Add(new Item("Fernseher"));
                
                
            }
        }

        private ILocation mRecognizedLocation;

        public ILocation RecognizedLocation
        {
            get { return mRecognizedLocation; }
            set { mRecognizedLocation = value; }
        }


        private Operation mRecognizedOperation;

        public Operation RecognizedOperation
        {
            get { return mRecognizedOperation; }
            set { mRecognizedOperation = value; }
        }


        private IItem mRecognizedItem;

        public IItem RecognizedItem
        {
            get { return mRecognizedItem; }
            set { mRecognizedItem = value; }
        }

        private List<ILocation> Locations = new List<ILocation>()
        {
            new Location("Wohnzimmer"),
            new Location("Flur"),
            new Location("Eingang"),
            new Location("Schlafzimmer"),
            new Location("Bad"),
        };        

        private SpeechRecognitionEngine mSpeech = new SpeechRecognitionEngine();

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

        public bool isStopped = true;

        public void Start()
        {
            Keywords.Add("Licht");
            Keywords.Add("Fernseher");
            Keywords.Add("Schlafzimmer");
            Keywords.Add("An");
            Keywords.Add("Ausschalten");
            Keywords.Add("Wohnzimmer");
            Keywords.Add("Flur");
            Keywords.Add("Wohnung");
            Keywords.Add("Hallo");
            Keywords.Add("Auf wiedersehen");



            Console.WriteLine("Bitte enter drücken und sprechen");
            Console.ReadLine();
            try
            {
                mSpeech.SetInputToDefaultAudioDevice();
                mSpeech.LoadGrammar(new DictationGrammar());
                mSpeech.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(mSpeech_SpeechRecognized);
                mSpeech.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(mSpeech_SpeechHypothesized);
                mSpeech.RecognizeAsync(RecognizeMode.Multiple);
                Console.WriteLine("Gestartet. Enter drücken zum Stopp");
                Console.ReadLine();
                mSpeech.RecognizeAsyncStop();
                Console.WriteLine("Gestoppt");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        void mSpeech_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            
        }

        void mSpeech_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Erkannt: " + e.Result.Text);

            foreach (RecognizedWordUnit recWord in e.Result.Words)
            {

                foreach (string s in Keywords)
                {

                    if (DamerauLevenshtein.DamerauLevenshteinDistance(s, recWord.Text) <= 2)
                    {
                        try
                        {
                            if (RecognizedLocation == null)
                                RecognizedLocation = Locations.SingleOrDefault(x => x.Name.ToLower() == s.ToLower());
                            if (RecognizedOperation == Operation.NONE)
                            {
                                switch (s.ToLower())
                                {
                                    case "an":
                                        RecognizedOperation = Operation.SET_ON;
                                        break;
                                    case "ausschalten":
                                        RecognizedOperation = Operation.SET_OFF;
                                        break;
                                    default:
                                        RecognizedOperation = Operation.NONE;
                                        break;
                                }
                            }

                            if (RecognizedItem == null)
                                RecognizedItem = RecognizedLocation.Items.SingleOrDefault(x => x.Name.ToLower() == s.ToLower());


                        }
                        catch (Exception)
                        {

                        }

                        if (RecognizedLocation != null && RecognizedItem != null && RecognizedOperation != Operation.NONE)
                        {
                            OnAllRecognized(this, new EventArgs());
                            WipeData();
                        }
                        
                    }
                }
            }

        }

        public void WipeData()
        {
            RecognizedOperation =  Operation.NONE;
            RecognizedItem = null;
            RecognizedLocation = null;
        }
    }


    /// <summary>
    /// Contains approximate string matching
    /// </summary>
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
