
using ECF.Controllers;
using ECF.Data;
using ECF.Data.Dtos;
using ECF.Data.Models;
using ECF.Data.Profiles;
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
        EcfContext _context;
        public MainWindow()
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _context = new EcfContext();
        }


        private void btnMusicien_Click(object sender, RoutedEventArgs e)
        {
            ListeMusiciens actions = new ListeMusiciens(_context);

            this.Opacity = 0.7;
            actions.ShowDialog();
            this.Opacity = 1;
        }

        private void btnGroupe_Click(object sender, RoutedEventArgs e)
        {
            ListeGroupes actions = new ListeGroupes(_context);

            this.Opacity = 0.7;
            actions.ShowDialog();
            this.Opacity = 1;
        }
    }
}
