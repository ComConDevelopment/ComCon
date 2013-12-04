namespace Sprachsteuerung
{
    using System;

    public class FS20Command : DependencyObject
    {
        // optionale timerzeit, wenn gesetzt dann Rampenzeit
        public const byte Off = 0x00;

        // optionale timerzeit, wenn gesetzt dann Rampenzeit
        // Dimmstufen, je Stufe 6,25%, STEP16 = ON 100%
        public const byte OnStep1 = 0x01;
        public const byte OnStep2 = 0x02;
        public const byte OnStep3 = 0x03;
        public const byte OnStep4 = 0x04;
        public const byte OnStep5 = 0x05;
        public const byte OnStep6 = 0x06;
        public const byte OnStep7 = 0x07;
        public const byte OnStep8 = 0x08;
        public const byte OnStep9 = 0x09;
        public const byte OnStep10 = 0x0A;
        public const byte OnStep11 = 0x0B;
        public const byte OnStep12 = 0x0C;
        public const byte OnStep13 = 0x0D;
        public const byte OnStep14 = 0x0E;
        public const byte OnStep15 = 0x0F;
        public const byte OnStep16 = 0x10;

        // optionale timerzeit, wenn gesetzt dann Rampenzeit
        public const byte OnOld = 0x11;

        // optionale timerzeit, wenn gesetzt dann Anschaltdauer, bei Toggle-An
        public const byte Toggle = 0x12;

        // optionale timerzeit, wenn gesetzt dann dauer, aber wenn aus durch dim_down bleibt aus
        public const byte DimUp = 0x13;
        public const byte DimDown = 0x14;
        public const byte DimUpDown = 0x15;

        // optionale timerzeit, neuer timer wert, sonst Start bzw. Ende der Timerprogrammierung
        public const byte TimeSet = 0x16;

        public const byte SendStatus = 0x17;

        // braucht timerzeit
        public const byte OffForTimeOld = 0x18;
        public const byte OnForTimeOff = 0x19;
        public const byte OnOldForTimeOff = 0x1A;

        public const byte Reset = 0x1B;

        // braucht timerzeit
        public const byte SetDimUpTime = 0x1C;
        public const byte SetDimDownTime = 0x1D;

        // optional timerzeit, ohne timerzeit wird interner timer genutzt
        public const byte OnForTimeOld = 0x1E;
        public const byte OnOldForTimeOld = 0x1F;

        // wird gesetzt, wenn timerzeit übertragen wird
        public const byte AddonBit = 0x20;

        // nicht verwendet Code
        public const byte NoUse = 0xFF;

        // Using a DependencyProperty as the backing store for HouseCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HouseCodeProperty =
            DependencyProperty.Register("HouseCode", typeof(string), typeof(FS20Command), new UIPropertyMetadata("11111111"));

        // Using a DependencyProperty as the backing store for Adress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdressProperty =
            DependencyProperty.Register("Adress", typeof(string), typeof(FS20Command), new UIPropertyMetadata("1111"));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(byte), typeof(FS20Command), new UIPropertyMetadata((byte)0));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(byte), typeof(FS20Command), new UIPropertyMetadata((byte)0));

        // Using a DependencyProperty as the backing store for CommandString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandStringProperty =
            DependencyProperty.Register("CommandString", typeof(string), typeof(FS20Command), new UIPropertyMetadata(string.Empty));

        // Using a DependencyProperty as the backing store for Ergebnis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErgebnisProperty =
            DependencyProperty.Register("Ergebnis", typeof(string), typeof(FS20Command), new UIPropertyMetadata(string.Empty));

        // Using a DependencyProperty as the backing store for Event.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventProperty =
            DependencyProperty.Register("Event", typeof(string), typeof(FS20Command), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// Initialisiert eine Instanz eines FS20Commands
        /// </summary>
        public FS20Command()
        {
            this.HouseCode = "11111111";
            this.Adress = "1111";
            this.Command = FS20Command.Off;
        }

        public string Ergebnis
        {
            get { return (string)GetValue(ErgebnisProperty); }
            set { SetValue(ErgebnisProperty, value); }
        }

        public string Event
        {
            get { return (string)GetValue(EventProperty); }
            set { SetValue(EventProperty, value); }
        }

        public string HouseCode
        {
            get
            {
                string temp = (string)GetValue(HouseCodeProperty);
                for (int i = temp.Length; i < 8; i++)
                {
                    temp = "1" + temp;
                }

                SetValue(HouseCodeProperty, temp);

                return temp;
            }

            set
            {
                string temp = (string)value;
                for (int i = temp.Length; i < 8; i++)
                {
                    temp = "1" + temp;
                }

                SetValue(HouseCodeProperty, temp);
            }
        }

        public string Adress
        {
            get
            {
                string temp = (string)GetValue(AdressProperty);
                for (int i = temp.Length; i < 4; i++)
                {
                    temp = "1" + temp;
                }

                SetValue(AdressProperty, temp);

                return temp;
            }

            set
            {
                string temp = value;
                for (int i = temp.Length; i < 4; i++)
                {
                    temp = "1" + temp;
                }

                SetValue(AdressProperty, temp);
            }
        }

        public byte Command
        {
            get
            {
                return (byte)GetValue(CommandProperty);
            }

            set
            {
                SetValue(CommandProperty, value);
                SetValue(CommandStringProperty, CommandToString(value));
            }
        }

        public byte Time
        {
            get
            {
                return (byte)GetValue(TimeProperty);
            }

            set
            {
                SetValue(TimeProperty, value);
            }
        }

        public string TimeString
        {
            get
            {
                return this.TimeToString();
            }
        }

        public string CommandString
        {
            get
            {
                return (string)GetValue(CommandStringProperty);
            }

            set
            {
                SetValue(CommandStringProperty, value);
                SetValue(CommandProperty, StringToCommand(value));
            }
        }

        public static FS20Command BytesToFS20Command(byte[] commandBytes)
        {
            FS20Command temp = new FS20Command();
            temp.HouseCode = ByteToFS20String(commandBytes[0]) + ByteToFS20String(commandBytes[1]);
            temp.Adress = ByteToFS20String(commandBytes[2]);
            temp.Command = commandBytes[3];
            if (commandBytes.Length > 4)
            {
                temp.Time = commandBytes[4];
            }

            return temp;
        }

        public static string CommandToString(byte command)
        {
            return FS20Command.CommandToString(command, Properties.Resources.Code2X_3X);
        }

        public static string CommandToString(byte command, string timer)
        {
            string temp = string.Empty;
            switch (command)
            {
                case Off:
                    return Properties.Resources.Code00;
                case OnStep1:
                    return Properties.Resources.Code01;
                case OnStep2:
                    return Properties.Resources.Code02;
                case OnStep3:
                    return Properties.Resources.Code03;
                case OnStep4:
                    return Properties.Resources.Code04;
                case OnStep5:
                    return Properties.Resources.Code05;
                case OnStep6:
                    return Properties.Resources.Code06;
                case OnStep7:
                    return Properties.Resources.Code07;
                case OnStep8:
                    return Properties.Resources.Code08;
                case OnStep9:
                    return Properties.Resources.Code09;
                case OnStep10:
                    return Properties.Resources.Code0A;
                case OnStep11:
                    return Properties.Resources.Code0B;
                case OnStep12:
                    return Properties.Resources.Code0C;
                case OnStep13:
                    return Properties.Resources.Code0D;
                case OnStep14:
                    return Properties.Resources.Code0E;
                case OnStep15:
                    return Properties.Resources.Code0F;
                case OnStep16:
                    return Properties.Resources.Code10;
                case OnOld:
                    return Properties.Resources.Code11;
                case Toggle:
                    return Properties.Resources.Code12;
                case DimUp:
                    return Properties.Resources.Code13;
                case DimDown:
                    return Properties.Resources.Code14;
                case DimUpDown:
                    return Properties.Resources.Code15;
                case TimeSet:
                    return Properties.Resources.Code16;
                case SendStatus:
                    return Properties.Resources.Code17;
                case OffForTimeOld:
                    return Properties.Resources.Code18;
                case OnForTimeOff:
                    return Properties.Resources.Code19;
                case OnOldForTimeOff:
                    return Properties.Resources.Code1A;
                case Reset:
                    return Properties.Resources.Code1B;
                case OnForTimeOld:
                    return Properties.Resources.Code1E;
                case OnOldForTimeOld:
                    return Properties.Resources.Code1F;

                case Off + AddonBit:
                    return Properties.Resources.Code20 + timer;
                case OnStep1 + AddonBit:
                    return Properties.Resources.Code21 + timer;
                case OnStep2 + AddonBit:
                    return Properties.Resources.Code22 + timer;
                case OnStep3 + AddonBit:
                    return Properties.Resources.Code23 + timer;
                case OnStep4 + AddonBit:
                    return Properties.Resources.Code24 + timer;
                case OnStep5 + AddonBit:
                    return Properties.Resources.Code25 + timer;
                case OnStep6 + AddonBit:
                    return Properties.Resources.Code26 + timer;
                case OnStep7 + AddonBit:
                    return Properties.Resources.Code27 + timer;
                case OnStep8 + AddonBit:
                    return Properties.Resources.Code28 + timer;
                case OnStep9 + AddonBit:
                    return Properties.Resources.Code29 + timer;
                case OnStep10 + AddonBit:
                    return Properties.Resources.Code2A + timer;
                case OnStep11 + AddonBit:
                    return Properties.Resources.Code2B + timer;
                case OnStep12 + AddonBit:
                    return Properties.Resources.Code2C + timer;
                case OnStep13 + AddonBit:
                    return Properties.Resources.Code2D + timer;
                case OnStep14 + AddonBit:
                    return Properties.Resources.Code2E + timer;
                case OnStep15 + AddonBit:
                    return Properties.Resources.Code2F + timer;
                case OnStep16 + AddonBit:
                    return Properties.Resources.Code30 + timer;
                case OnOld + AddonBit:
                    return Properties.Resources.Code31 + timer;
                case Toggle + AddonBit:
                    return Properties.Resources.Code32 + timer;
                case DimUp + AddonBit:
                    return Properties.Resources.Code33 + timer + Properties.Resources.Code39_3A;
                case DimDown + AddonBit:
                    return Properties.Resources.Code34 + timer + Properties.Resources.Code39_3A;
                case DimUpDown + AddonBit:
                    return Properties.Resources.Code35 + timer;
                case TimeSet + AddonBit:
                    return Properties.Resources.Code36 + timer;
                case OffForTimeOld + AddonBit:
                    return Properties.Resources.Code38 + timer + Properties.Resources.Code3E_3F;
                case OnForTimeOff + AddonBit:
                    return Properties.Resources.Code39 + timer + Properties.Resources.Code39_3A;
                case OnOldForTimeOff + AddonBit:
                    return Properties.Resources.Code3A + timer + Properties.Resources.Code39_3A;
                case SetDimUpTime + AddonBit:
                    return Properties.Resources.Code3C + timer;
                case SetDimDownTime + AddonBit:
                    return Properties.Resources.Code3D + timer;
                case OnForTimeOld + AddonBit:
                    return Properties.Resources.Code3E + timer + Properties.Resources.Code3E_3F;
                case OnOldForTimeOld + AddonBit:
                    return Properties.Resources.Code3F + timer + Properties.Resources.Code3E_3F;

                default:
                    return Properties.Resources.CodeFF;
            }
        }

        public static byte StringToCommand(string value)
        {
            byte temp = 0xFF;
            if (!value.StartsWith("unbekannter"))
            {
                for (int i = 0; i < 64; i++)
                {
                    if (value == CommandToString((byte)i))
                    {
                        temp = (byte)i;
                        break;
                    }
                }
            }

            return temp;
        }

        public static byte FS20StringToByte(string value)
        {
            byte temp = 0x00;
            int tempValue = int.Parse(value);
            temp += (byte)((tempValue % 10) - 1);
            tempValue = (tempValue - (tempValue % 10)) / 10;
            temp += (byte)(((tempValue % 10) - 1) * 4);
            tempValue = (tempValue - (tempValue % 10)) / 10;
            temp += (byte)(((tempValue % 10) - 1) * 16);
            tempValue = (tempValue - (tempValue % 10)) / 10;
            temp += (byte)(((tempValue % 10) - 1) * 64);

            return temp;
        }

        public static string ByteToFS20String(byte value)
        {
            string temp = string.Empty;
            temp += ((int)((value >> 6 & 0x03) + 1)).ToString();
            temp += ((int)((value >> 4 & 0x03) + 1)).ToString();
            temp += ((int)((value >> 2 & 0x03) + 1)).ToString();
            temp += ((int)((value & 0x03) + 1)).ToString();

            return temp;
        }

        public static byte GetTimeFromSeconds(int time)
        {
            for (int i = 0; i < 256; i++)
            {
                int highnibble = i / 16;
                int lownibble = i % 16;
                int tempTime = (int)(Math.Pow(2.0, highnibble) * lownibble);

                if (tempTime == time)
                {
                    return (byte)i;
                }
            }

            return 0x00; // Zeit nicht gefunden
        }

        public override string ToString()
        {
            return this.HouseCode + " " + this.Adress + " " + CommandToString(this.Command, " " + this.TimeToString());
        }

        public string TimeToString()
        {
            string timeAsString = string.Empty;
            int highnibble = (int)this.Time;
            int lownibble = highnibble % 16;
            highnibble = (highnibble - lownibble) / 16;
            double tempTime = Math.Pow(2.0, highnibble) * lownibble * 0.25;
            double seconds = tempTime % 60;
            double minutes = (tempTime - seconds) / 60;
            minutes = minutes % 60;
            double hours = (tempTime - (minutes * 60) - seconds) / 3600;

            if (hours != 0)
            {
                timeAsString = hours.ToString() + "h ";
            }

            if (minutes != 0 || hours != 0)
            {
                timeAsString += minutes.ToString() + "m ";
            }

            timeAsString += seconds.ToString() + "s";

            return timeAsString;
        }

        public byte[] CommandToBytes()
        {
            byte[] result = new byte[5];
            result[0] = FS20StringToByte(this.HouseCode.Substring(0, 4));
            result[1] = FS20StringToByte(this.HouseCode.Substring(4, 4));
            result[2] = FS20StringToByte(this.Adress);
            result[3] = this.Command;
            if (this.Command >= FS20Command.AddonBit)
            {
                result[4] = this.Time;
            }

            return result;
        }

        public FS20Command Clone()
        {
            FS20Command temp = new FS20Command();
            temp.HouseCode = this.HouseCode;
            temp.Adress = this.Adress;
            temp.Command = this.Command;
            temp.Time = this.Time;
            temp.Ergebnis = this.Ergebnis;
            temp.Event = this.Event;

            return temp;
        }
    }
}
