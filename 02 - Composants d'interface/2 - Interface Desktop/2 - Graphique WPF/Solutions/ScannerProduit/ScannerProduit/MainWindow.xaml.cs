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

namespace ScannerProduit
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChargerFichier();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            Enregistrement enreg = new Enregistrement(CodeBarre.Text, Produit.Text);
            enreg.AjoutEnregistrement();
            ChargerFichier();
        }
        private void ChargerFichier()
        {
            ContenuFichier.ItemsSource = Enregistrement.ListeEnreg();
        }

        private void Rechercher_Click(object sender, RoutedEventArgs e)
        {
            ContenuFichier.ItemsSource = Enregistrement.ChercherEnreg(CodeBarre.Text);
        }
    }
}
