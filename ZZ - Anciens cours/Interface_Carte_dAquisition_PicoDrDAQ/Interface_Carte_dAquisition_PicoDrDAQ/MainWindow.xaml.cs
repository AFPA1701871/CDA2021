using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Runtime.InteropServices;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        uint echantillonnage = 500;
        short handle;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void btnLumiere_Click(object sender, RoutedEventArgs e)
        {
            Lumiere w1 = new Lumiere();
            w1.ShowDialog();
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
        }
        private void btnSon_Click(object sender, RoutedEventArgs e)
        {
            SonFenetre s = new SonFenetre();
            s.ShowDialog();
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
        }
        private void btnTemp_Click(object sender, RoutedEventArgs e)
        {
            TemperatureFenetre t = new TemperatureFenetre();
            t.ShowDialog();
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lumiere2 w2 = new Lumiere2();
            w2.ShowDialog();
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);
        }
    }
}
