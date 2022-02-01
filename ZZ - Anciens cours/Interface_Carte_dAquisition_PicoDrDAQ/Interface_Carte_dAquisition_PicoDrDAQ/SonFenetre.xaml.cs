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
namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    /// <summary>
    /// Logique d'interaction pour Son.xaml
    /// </summary>
    public partial class SonFenetre : Window
    {
        short handle;
        uint echantillonnage = 500;
        ushort overflow;
        short value;
        short son;       
        List<Double> x = new List<Double>();
        List<Double> y = new List<Double>();
        public SonFenetre()
        {
            InitializeComponent();
            //init
            Imports.OpenUnit(out handle);
            Imports.Run(handle, echantillonnage, Imports._BLOCK_METHOD.BM_STREAM);            
            // puissance sonore
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_LEVEL, out value, out overflow);
            // Forme d'onde
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_WAVE, out value, out overflow);
            // Imports.GetValues Niveau sonore (handle,out capteurs,ref nvalue,out overflow,out index); 
            System.Windows.Threading.DispatcherTimer dispatcherTimer1 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer1.Tick += dispatcherTimer_Tick1;
            dispatcherTimer1.Interval = TimeSpan.FromMilliseconds(300);
            dispatcherTimer1.Start();
            // Imports.GetValues Forme d'onde (handle,out capteurs,ref nvalue,out overflow,out index); 
            System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer2.Tick += dispatcherTimer_Tick2;
            dispatcherTimer2.Interval = TimeSpan.FromMilliseconds(5);
            dispatcherTimer2.Start();
        }
        public void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_LEVEL, out son, out overflow);
            tbxNvSon.Text = Convert.ToString(Convert.ToDouble(son) / 10);
        }
        public void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            double Y = Convert.ToDouble(son);
            if (x.Count < 100) x.Add(x.Count);
            y.Add(Convert.ToDouble(son));
            if (y.Count > 100) y.RemoveAt(0);
            linegraph.Plot(x, y);
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

        private void btnEnregistrement_Son_Click(object sender, RoutedEventArgs e)
        {
            Sons s = new Sons();
            s.Son = son;
            s.Insert();
        }

    }
}

