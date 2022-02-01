using System;
using System.Text;
using System.Windows;
using System.Xml;

namespace DRDAQ
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public short handle;
        public MainWindow()
        {
            InitializeComponent();
            openDrDAQ();
            LogBox.Text = "Date \t\t Intensite Lumière\t Temperature \t Intensite Sonore\n";
        }
        private void openDrDAQ()
        {
            short handleDAQ;
            System.Text.StringBuilder line = new System.Text.StringBuilder(80);
            short requiredSize;

            while (Imports.OpenUnit(out handleDAQ) == 0)
            {
                Imports.GetUnitInfo(handleDAQ, line, 80, out requiredSize, Imports.Info.USBDrDAQ_BATCH_AND_SERIAL);
                handle = handleDAQ;
                txtNumSerie.Text = line.ToString();
            }
        }
        private void closeDrDAQ()
        {
            Imports.CloseUnit(handle);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {

         
            short lightLevel = 0;
            short soundLevel = 0;
            short temp = 0;
            ushort overflow = 0;
            uint totalSamples = 200;
            short[] data = new short[totalSamples];
            short isReady = 0;
            uint us_for_block = 100000;

            Imports.Inputs[] channels = { Imports.Inputs.USB_DRDAQ_CHANNEL_LIGHT };
            short numChannels = (short)channels.Length;
            uint numSamplesPerChannel = totalSamples / (uint)numChannels;
            uint numSamplesCollected = numSamplesPerChannel; // If collecting data in a loop, reset this value each time as it could be modified in the call to GetValues()
                                                             //On désactive les paramètres de collecte automatique par défaut
            Imports.SetTrigger(handle, 0, 0, 0, 0, 0, 0, 0, 0);

            Imports.SetInterval(handle, ref us_for_block, numSamplesPerChannel, ref channels[0], numChannels);
            //On demande à démarrer l'acquisition
            Imports.Run(handle, totalSamples, Imports._BLOCK_METHOD.BM_STREAM);
            //On attend que la carte soit prête à démarrer l'acquisition
            while (isReady == 0)
            {
                Imports.Ready(handle, out isReady);
            }
            //on collecte les données
        //    Imports.GetValues(handle, out data[0], ref numSamplesCollected, out overflow, out triggerIndex);

            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_LIGHT, out lightLevel, out overflow);
            //pour obtenir les des degrés celsius par rapport aux milliVolts
            //il faut multiplier par 80 et diviser par 1000

            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_TEMP, out temp, out overflow);
            temp = (short)(temp * 80 / 1000);

            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_LEVEL, out soundLevel, out overflow);

            LogBox.Text += DateTime.Now.ToLocalTime() + "\t" + lightLevel + "\t\t" + temp + "\t\t" + soundLevel + "\n";
        }
        private void Led_Click(object sender, RoutedEventArgs e)
        {
            changeLed();
        }
            private void changeLed()
        {
            ushort red = (ushort)Rouge.Value;
            ushort green = (ushort)Vert.Value;
            ushort blue = (ushort)Bleu.Value;
            Imports.EnableRGBLED(handle, 1);

            
            //on affecte une couleur à la led par rapport aux paramètres RGB
            Imports.SetRGBLED(handle, red, green, blue);

        }

        private void Bleu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeLed();
        }
        private void Vert_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeLed();
        }
        private void Rouge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            changeLed();
        }
    }


}
