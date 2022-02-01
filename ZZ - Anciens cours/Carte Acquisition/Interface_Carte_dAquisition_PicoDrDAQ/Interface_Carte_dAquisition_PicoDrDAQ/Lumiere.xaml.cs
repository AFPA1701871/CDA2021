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


namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    /// <summary>
    /// Logique d'interaction pour Lumiere.xaml
    /// </summary>
    public partial class Lumiere : Window
    {
        short handle;
        ushort red;
        ushort blue;
        ushort green;
        uint echantillonnage = 500;
        short capteurs;
        ushort overflow;
        uint index;
        uint nvalue;
        short value;
        short tempe;
        short dec;
        short lum;      
        public Lumiere()
        {
            InitializeComponent();
            //init
            Imports.OpenUnit(out handle);
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
            //couleurs
            Imports.EnableRGBLED(handle, 1);
            Imports.SetRGBLED(handle, red, green, blue);
            //luminosité
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_LIGHT, out value, out overflow);
            // Imports.GetValues(handle,out capteurs,ref nvalue,out overflow,out index); 
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
            dispatcherTimer.Start();
        }
        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_LIGHT, out lum, out overflow);
            
        }
        private void Bleu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush maCouleur = new SolidColorBrush();
            maCouleur.Color = Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
            blue = Convert.ToUInt16(Bleu.Value);
            Imports.SetRGBLED(handle, red, green, blue);
            ampoule1.Fill = maCouleur;
            ampoule2.Fill = maCouleur;
            ampoule3.Fill = maCouleur;
        }
        private void Vert_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush maCouleur = new SolidColorBrush();
            maCouleur.Color = Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
            green = Convert.ToUInt16(Vert.Value);
            Imports.SetRGBLED(handle, red, green, blue);
            ampoule1.Fill = maCouleur;
            ampoule2.Fill = maCouleur;
            ampoule3.Fill = maCouleur;
        }
        private void Rouge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush maCouleur = new SolidColorBrush();
            maCouleur.Color = Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
            red = Convert.ToUInt16(Rouge.Value);
            Imports.SetRGBLED(handle, red, green, blue);
            ampoule1.Fill = maCouleur;
            ampoule2.Fill = maCouleur;
            ampoule3.Fill = maCouleur;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Imports.CloseUnit(handle);
        }

        private void btnGestion_Click(object sender, RoutedEventArgs e)
        {
            Gestion_Donnees g = new Gestion_Donnees();
            g.ShowDialog();
        }

        private void btnEnregistrement_coul_Click(object sender, RoutedEventArgs e)
        {
            Couleurs coul = new Couleurs();
            SolidColorBrush maCouleur = new SolidColorBrush();
            red = Convert.ToUInt16(Rouge.Value);
            blue = Convert.ToUInt16(Bleu.Value);
            green = Convert.ToUInt16(Vert.Value);            
            maCouleur.Color = Color.FromRgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
            coul.Insert(red,blue,green);            
        }
    }
}
