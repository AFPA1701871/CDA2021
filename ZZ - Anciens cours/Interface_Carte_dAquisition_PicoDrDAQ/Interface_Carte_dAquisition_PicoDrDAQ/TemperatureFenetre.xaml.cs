using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    /// <summary>
    /// Logique d'interaction pour Temperature.xaml
    /// </summary>
    public partial class TemperatureFenetre : Window
    {
        uint echantillonnage = 500;
        short handle;
        ushort overflow;
        short temp;
        short value;
        

        public TemperatureFenetre()
        {
            InitializeComponent();
            //init
            Imports.OpenUnit(out handle);
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
            //température
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_TEMP, out value, out overflow);
            // Imports.GetValues Niveau sonore (handle,out capteurs,ref nvalue,out overflow,out index); 
            System.Windows.Threading.DispatcherTimer dispatcherTimer3 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer3.Tick += dispatcherTimer_Tick3;
            dispatcherTimer3.Interval = TimeSpan.FromMilliseconds(300);
            dispatcherTimer3.Start();
        }
        public void dispatcherTimer_Tick3(object sender, EventArgs e)
        {
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_TEMP, out temp, out overflow);
            tbxTempPiece.Text = Convert.ToString(temp / 10) + "°C";
            prgbrTemp.Value = temp / 10;
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

        private void btnEnregistrement_Temp_Click(object sender, RoutedEventArgs e)
        {
            Temperature t = new Temperature();
            t.Temp1 = temp;
            t.Insert();
        }

    }
}

