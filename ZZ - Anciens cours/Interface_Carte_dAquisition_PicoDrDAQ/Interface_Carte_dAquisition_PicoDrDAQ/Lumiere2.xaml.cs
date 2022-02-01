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
    /// Logique d'interaction pour Lumiere2.xaml
    /// </summary>
    public partial class Lumiere2 : Window
    {
        short handle;       
        uint echantillonnage = 500;
        short capteurs;
        ushort overflow;
        uint index;
        uint nvalue;
        short value;
        short tempe;
        short dec;
        short lum;
        int lumi;
        public Lumiere2()
        {
            InitializeComponent();
            
            //init
            Imports.OpenUnit(out handle);
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
            //couleurs
            
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
            grdPiece.Opacity = Convert.ToDouble(lum) / 100;
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

        private void btnEnregistrement_Lum_Click(object sender, RoutedEventArgs e)
        {
            Luminosites l = new Luminosites();
            l.Lumi = lum;
            l.Insert();
        }
    }
}
