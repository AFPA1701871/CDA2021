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
    public partial class Son : Window
    {
        short handle;
        uint echantillonnage = 500;
        ushort overflow;
        short value;
        short son;
        int i = 10;
        List<Double> x = new List<Double>();
        List<Double> y = new List<Double>();

       public Son()
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
// Rempli ();
            // Imports.GetValues Forme d'onde (handle,out capteurs,ref nvalue,out overflow,out index); 
            System.Windows.Threading.DispatcherTimer dispatcherTimer2 = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer2.Tick += dispatcherTimer_Tick2;
            dispatcherTimer2.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer2.Start();
        }

        public void dispatcherTimer_Tick1(object sender, EventArgs e)
        {
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_LEVEL, out son, out overflow);
            tbxNvSon.Text = Convert.ToString(Convert.ToDouble(son) / 10) + " dB";
        }
        public void dispatcherTimer_Tick2(object sender, EventArgs e)
        {
            
            //    var x = Enumerable.Range(0, 1001).Select(i => i / 10).ToArray();
            //   var y = Enumerable.Range(-100, 100).Select(i => Y).ToArray();
            //   Double[] x = Enumerable.Range(0, 100).Select(i => i / 10.0).ToArray();
            // Double[] y = Enumerable.Range(-100, 100).Select(i => Y).ToArray();
            /* if (i >= 100) i = 0; else i += 10;

             x[i] = i;
             y[i] = Convert.ToDouble(son);
             */
         //   DecalerTableau();
            Imports.GetSingle(handle, Imports.Inputs.USB_DRDAQ_CHANNEL_MIC_WAVE, out son, out overflow);
             double Y = Convert.ToDouble(son);
            if (x.Count<100)  x.Add(x.Count);

            y.Add(Convert.ToDouble(son));
            if (y.Count > 100) y.RemoveAt(0);
         
            linegraph.Plot(x, y);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Imports.CloseUnit(handle);
        }
    }
}

