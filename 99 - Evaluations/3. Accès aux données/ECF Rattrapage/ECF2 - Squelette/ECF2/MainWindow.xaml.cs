
using ECF.Controllers;
using ECF2.Data;
using ECF2.Data.Dtos;
using ECF2.Data.Models;
using ECF2.Data.Profiles;
using ECF.Formulaires;
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

namespace ECF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ecf2Context _context;
        public MainWindow()
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _context = new Ecf2Context();
        }


        private void btnChambre_Click(object sender, RoutedEventArgs e)
        {
            ListeChambres actions = new ListeChambres(_context);

            this.Opacity = 0.7;
            actions.ShowDialog();
            this.Opacity = 1;
        }

        private void btnHotel_Click(object sender, RoutedEventArgs e)
        {
            ListeHotels actions = new ListeHotels(_context);

            this.Opacity = 0.7;
            actions.ShowDialog();
            this.Opacity = 1;
        }
    }
}
