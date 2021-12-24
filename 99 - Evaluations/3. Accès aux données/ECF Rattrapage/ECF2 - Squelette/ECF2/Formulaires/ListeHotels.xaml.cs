using ECF.Controllers;
using ECF2.Data;
using ECF2.Data.Dtos;
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

namespace ECF.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour ListeHotels.xaml
    /// </summary>
    public partial class ListeHotels : Window
    {

        Ecf2Context _context;
        HotelsController _hotelsController;

        public ListeHotels(Ecf2Context context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _context = context;
            _hotelsController = new HotelsController(_context);
            // On rempli la datagrid
            DgListeHotels.ItemsSource = _hotelsController.GetAllHotels();

        }

        /// <summary>
        /// Méthode qui capte le click sur l'un des boutons d'actions et ouvre le formulaire dans le mode correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActions_Click(object sender, RoutedEventArgs e)
        {
            // On récupère l'article selectionné
            HotelsDTOOut chambre = (HotelsDTOOut)DgListeHotels.SelectedItem;
            string nom = (string)((Button)sender).Content;
            // Si pas d'article sélectionné et click sur le bouton modifier ou supprimer, on affiche un message d'erreur
            if (chambre == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                MessageBox.Show("Vous devez sélectionner une ligne", "Erreur de sélection",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // On ouvre la fenêtre de détail
                // Elle prend les arguments suivants : l'action cliqué, la fenêtre mère, l'article selectionné, le context
                FormulaireHotel actions = new FormulaireHotel(nom, this, chambre, _context);
                this.Opacity = 0.7;
                actions.ShowDialog();
                this.Opacity = 1;
            }
        }

        public void ActionHotel(HotelsDTOIn chambre, string action, int id)
        {
            // On met à jour le chambre en base de données
            // en fonction de l'action
            switch (action)
            {
                case "Ajouter":
                    _hotelsController.CreateHotel(chambre);
                    break;
                case "Modifier":
                    _hotelsController.UpdateHotel(id, chambre);
                    break;
                case "Supprimer":
                    _hotelsController.DeleteHotel(id);
                    break;
            }

            ActualiserTableau();
        }

        private void ActualiserTableau()
        {
            // on recharge le datagrid
            DgListeHotels.ItemsSource = _hotelsController.GetAllHotels();
        }

        public void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

