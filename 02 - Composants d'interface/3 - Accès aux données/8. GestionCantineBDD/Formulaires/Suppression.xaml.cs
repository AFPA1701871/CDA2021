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

namespace GestionCantine.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour Suppression.xaml
    /// </summary>
    public partial class Suppression : Window
    {
        public Suppression()
        {
            InitializeComponent();
        }

        public void init()
        {
            this.DialogResult = false;
        }

        private void Continuer(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Fermer();
        }

        private void Annuler(object sender, RoutedEventArgs e)
        {
            this.Fermer();
        }
        private void Fermer()
        {
            this.Close();
        }
    }
}
