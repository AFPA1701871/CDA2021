using ECF.Controllers;
using ECF2.Data;
using ECF2.Data.Dtos;
using ECF2.Data.Models;
using ECF.Formulaires;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace ECF
{
    /// <summary>
    /// Logique d'interaction pour FormulaireHotel.xaml
    /// </summary>

    public partial class FormulaireHotel : Window
    {
        // Attributs
        ListeHotels FenetreAppel; // fenêtre d'appel
        HotelsDTOOut Hotel;
        string Action;
        int Id;

        // Constructeurs
        public FormulaireHotel(string action, ListeHotels window, HotelsDTOOut hotel, Ecf2Context _context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.FenetreAppel = window;
            // on récupère l'id de l'article, null si pas d'article
            this.Id = (hotel == null) ? 0 : hotel.IdHotel;
            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;
            this.Hotel = hotel;

            InitPage();
        }

        //Autres méthodes

        /// <summary>
        /// Méthode qui permet de remplir le formulaire à partir des données de la classe
        /// </summary>
        private void InitPage()
        {

            //on met à jour le titre de la fenetre
            labTitreFormulaire.Content = this.Action + " un membre";

            //Button valider
            btn_Valider.Content = this.Action;


            switch (this.Action)
            {
                case "Ajouter":
                    // rien à faire
                    break;
                case "Modifier":
                    txbNomHotel.Text = Hotel.NomHotel;
                    txbCategorieHotel.Text = Hotel.CategorieHotel.ToString();
                    txbAdresse.Text = Hotel.AdresseHotel;
                    txbVille.Text = Hotel.VilleHotel;

                    break;
                case "Supprimer":
                    // Tous les champs ne sont pas modifiable
                    txbNomHotel.Text = Hotel.NomHotel;
                    txbCategorieHotel.Text = Hotel.CategorieHotel.ToString();
                    txbAdresse.Text = Hotel.AdresseHotel;
                    txbVille.Text = Hotel.VilleHotel;

                    txbNomHotel.IsEnabled = false;
                    txbCategorieHotel.IsEnabled = false;
                    txbAdresse.IsEnabled = false;
                    txbVille.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }


        private void ActionHotel(object sender, RoutedEventArgs e)
        {
            HotelsDTOIn hotel = new HotelsDTOIn
            {
                NomHotel = txbNomHotel.Text,
                CategorieHotel = Int32.Parse(txbCategorieHotel.Text),
                AdresseHotel = txbAdresse.Text,
                VilleHotel = txbVille.Text,
            };
            this.FenetreAppel.ActionHotel(hotel, this.Action, this.Id);
            Retour();
        }

        public void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Retour()
        {
            this.Close();
        }

        private void txbNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Int32.TryParse(((TextBox)sender).Text, out Int32 result))
            {
                ((TextBox)sender).Text = "";
                MessageBox.Show("Cette valeur doit être un entier", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
