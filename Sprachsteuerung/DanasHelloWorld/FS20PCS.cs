


namespace Sprachsteuerung
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UsbLibrary;


public class FS20PCSDevice
    {
        private UsbHidPort usb;

        public FS20PCSDevice()
        {
            this.usb = new UsbHidPort();            
            this.usb.VendorId = 0x18EF; // VendorID von ELV z.B. aus Windows Gerätemanager zu entnehmen
            this.usb.ProductId = 0xE015; // ProductID des FS20 PCSz.B. aus Windows Gerätemanager zu entnehmen
            this.usb.OnSpecifiedDeviceArrived += new EventHandler(this.OnSpecifiedDeviceArrived);
            
            // Prüfen ob Gerät angeschlossen
            this.usb.CheckDevicePresent();
        }

        public event DataRecievedEventHandler ReportReceived;

        public event EventHandler DeviceDisconnected;

        public bool DeviceConnected
        {
            get
            {
                return this.usb.SpecifiedDevice != null;
            }
        }

        public void GetFirmwareVersion()
        {
            byte[] commandbytes = new byte[11]; // Reports des FS20PCS immer 11 Byte Gesamtlänge
            commandbytes[0] = 0x01; // HIDReportID
            commandbytes[1] = 0x01; // Byte Anzahl
            commandbytes[2] = 0xF0; // BefehlID

            this.WriteToDevice(commandbytes);
        }

        public void SendFS20Command(FS20Command fs20command)
        {
            byte[] commandbytes = new byte[11]; // Reports des FS20PCS immer 11 Byte Gesamtlänge
            commandbytes[0] = 0x01; // HIDReportID
            commandbytes[1] = 0x06; // Byte Anzahl
            commandbytes[2] = 0xF1; // BefehlID
            fs20command.CommandToBytes().CopyTo(commandbytes, 3);

            this.WriteToDevice(commandbytes);
        }

        public void SendFS20Command(FS20Command fs20command, int sendcounter)
        {
            byte[] commandbytes = new byte[11]; // Reports des FS20PCS immer 11 Byte Gesamtlänge
            commandbytes[0] = 0x01; // HIDReportID
            commandbytes[1] = 0x07; // Byte Anzahl
            commandbytes[2] = 0xF2; // BefehlID
            fs20command.CommandToBytes().CopyTo(commandbytes, 3);
            commandbytes[8] = (byte)sendcounter;

            this.WriteToDevice(commandbytes);
        }

        public void StopSending()
        {
            byte[] commandbytes = new byte[11]; // Reports des FS20PCS immer 11 Byte Gesamtlänge
            commandbytes[0] = 0x01; // HIDReportID
            commandbytes[1] = 0x01; // Byte Anzahl
            commandbytes[2] = 0xF3; // BefehlID

            this.WriteToDevice(commandbytes);
        }

        private void OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            this.usb.SpecifiedDevice.DataRecieved += new DataRecievedEventHandler(this.SpecifiedDevice_DataRecieved);
            this.usb.SpecifiedDevice.OnDeviceRemoved += new EventHandler(this.SpecifiedDevice_OnDeviceRemoved);
        }

        private void SpecifiedDevice_DataRecieved(object sender, DataRecievedEventArgs args)
        {
            // Event weitergeben z.B. für das Hauptfenster
            if (this.ReportReceived != null)
            {
                this.ReportReceived(this, args);
            }
        }

        private void SpecifiedDevice_OnDeviceRemoved(object sender, EventArgs e)
        {
            // Prüfen ob Gerät angeschlossen
            this.usb.CheckDevicePresent();

            // Event weitergeben z.B. für das Hauptfenster
            if (this.DeviceDisconnected != null)
            {
                this.DeviceDisconnected(this, e);
            }
        }

        private void WriteToDevice(byte[] outputReportBuffer)
        {
            // Verbindung vor dem Senden prüfen, ggf. versuchen diese aufzubauen
            if (!this.DeviceConnected)
            {
                this.usb.CheckDevicePresent();
            }

            try
            {
                if (this.usb.SpecifiedDevice != null)
                {
                    this.usb.SpecifiedDevice.SendData(outputReportBuffer);
                }
                else
                {
                    MessageBox.Show("Es wurde kein Gerät gefunden.\r\nÜberprüfen Sie die Verbindung zum Gerät.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler in Kommunikation mit dem Gerät\r\n" + ex.Message);
            }
        }
    }
}