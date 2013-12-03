using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Speech.Recognition;

namespace Spracherkennung
{
    public class Program
    {
        static SpeechRecognizer sr = new SpeechRecognizer();
        static void Main(string[] args)
        {


            sr.AllRecognized += new SpeechRecognizer.AllRecognizedHandler(sr_AllRecognized);
            sr.Start();
            
        }

        static void sr_AllRecognized(object sender, EventArgs args)
        {
            switch (sr.RecognizedOperation)
            {
                case Operation.SET_ON:
                    sr.RecognizedLocation.Items[sr.RecognizedLocation.Items.IndexOf(sr.RecognizedItem)].SetState(State.ON);
                    break;
                case Operation.SET_OFF:
                    sr.RecognizedLocation.Items[sr.RecognizedLocation.Items.IndexOf(sr.RecognizedItem)].SetState(State.OFF);
                    break;
            }
        }
    }

} 
