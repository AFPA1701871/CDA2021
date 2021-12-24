using ECF.Controllers;
using ECF2.Data;
using ECF2.Data.Dtos;
using ECF2.Data.Models;
using ECF.Formulaires;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Logique d'interaction pour FormulaireChambre.xaml
    /// </summary>

    public partial class FormulaireChambre : Window
    {
        // Attributs
        ListeChambres FenetreAppel; // fenêtre d'appel
        ChambresDTOOutAvecHotel Chambre;
        HotelsController HotelsController;
        string Action;
        int Id;

        // Constructeurs
        public FormulaireChambre(string action, ListeChambres window, ChambresDTOOutAvecHotel chambre, Ecf2Context _context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Chambre = chambre;
            this.FenetreAppel = window;
            // on récupère l'id de l'chambre, null si pas d'chambre
            this.Id = (chambre == null) ? 0 : chambre.IdChambre;
            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;

            HotelsController = new HotelsController(_context);

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

            // on rempli la combobox hotel
            cbHotel.ItemsSource = HotelsController.GetAllHotels();
            cbHotel.DisplayMemberPath = "NomHotel"; //Valeur a afficher dans la combobox
            cbHotel.SelectedValuePath = "IdHotel"; // Valeur de la combobox
            //Button valider
            btn_Valider.Click += (s, e) => ActionChambre(); // On affecte la fonction au bouton
            btn_Valider.Content = this.Action;


            switch (this.Action)
            {
                case "Ajouter":
                    // rien à faire
                    break;
                case "Modifier":
                    txbTypeChambre.Text = Chambre.TypeChambre.ToString();
                    txbCapaciteChambre.Text = Chambre.CapaciteChambre.ToString();
                    txbNumeroChambre.Text = Chambre.NumChambre.ToString();
                    //Hotel
                    // On sélectionne par défaut la valeur du hotel actuel du chambre
                    cbHotel.SelectedValue = Chambre.IdHotel;
                    break;
                case "Supprimer":
                    // Tous les champs ne sont pas modifiable
                    txbTypeChambre.Text = Chambre.TypeChambre.ToString();
                    txbCapaciteChambre.Text = Chambre.CapaciteChambre.ToString();
                    txbNumeroChambre.Text = Chambre.NumChambre.ToString();
                    cbHotel.SelectedValue = Chambre.IdHotel;

                    txbTypeChambre.IsEnabled = false;
                    txbCapaciteChambre.IsEnabled = false;
                    txbNumeroChambre.IsEnabled = false;
                    cbHotel.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ActionChambre()
        {
            ChambresDTOIn chambre = new ChambresDTOIn
            {
                IdChambre = this.Id,
                TypeChambre = Int32.Parse(txbTypeChambre.Text),
                CapaciteChambre = Int32.Parse(txbCapaciteChambre.Text),
                NumChambre = Int32.Parse(txbNumeroChambre.Text),
                IdHotel = (int)cbHotel.SelectedValue,
            };
            chambre.Dump();
            // on appelle la méthode de la fenêtre mère (parce qu'elle contient le controller)
            this.FenetreAppel.ActionChambre(chambre, this.Action, this.Id);
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
