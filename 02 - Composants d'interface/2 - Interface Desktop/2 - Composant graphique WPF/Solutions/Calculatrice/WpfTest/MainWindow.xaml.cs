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

namespace WpfTest
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void btnNumerique_Click(object sender, RoutedEventArgs e)
        {
            // sender est l'élément qui a déclenché l'événement
            tbxResultat.Text += ((Button)sender).Content;
        }

        private void btnInit_Click(object sender, RoutedEventArgs e)
        {
            tbxResultat.Text = "";
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           double w= Application.Current.MainWindow.Width;
            double h = Application.Current.MainWindow.Height;
            tbxResultat.Text = "w " + w + ", h " + h;
            btn1.FontSize = h/20 ;
        }
    }
}
