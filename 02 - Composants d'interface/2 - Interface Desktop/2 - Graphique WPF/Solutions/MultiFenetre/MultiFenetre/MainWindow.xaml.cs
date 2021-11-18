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

namespace MultiFenetre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        public Mainwindow()
        {
            InitializeComponent();
        }

        

        private void btnNvFenetre_Click(object sender, RoutedEventArgs e)
        {
            Fenetre2 f = new Fenetre2(tbxMot.Text, this);
            this.Opacity = 0.7;
            this.Visibility = Visibility.Hidden;
            f.ShowDialog();

            this.Visibility = Visibility.Visible;
            this.Opacity = 1;

        }
        public void MAJRetour(string valeur)
        {
            this.lblRetour.Content = valeur;
        }
    }
}
