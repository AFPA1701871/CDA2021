using ECF.Controllers;
using ECF.Data;
using ECF.Data.Dtos;
using ECF.Data.Models;
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
    /// Logique d'interaction pour FormulaireMusicien.xaml
    /// </summary>

    public partial class FormulaireMusicien : Window
    {
        // Attributs
        ListeMusiciens FenetreAppel; // fenêtre d'appel
        MusiciensDTOOutAvecGroupe Musicien;
        GroupesController GroupesController;
        string Action;
        int Id;

        // Constructeurs
        public FormulaireMusicien(string action, ListeMusiciens window, MusiciensDTOOutAvecGroupe musicien, EcfContext _context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Musicien = musicien;
            this.FenetreAppel = window;
            // on récupère l'id de l'musicien, null si pas d'musicien
            this.Id = (musicien == null) ? 0 : musicien.IdMusicien;
            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;

            GroupesController = new GroupesController(_context);

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

            // on rempli la combobox categorie
            cbGroupe.ItemsSource = GroupesController.GetAllGroupes();
            cbGroupe.DisplayMemberPath = "NomDuGroupe"; //Valeur a afficher dans la combobox
            cbGroupe.SelectedValuePath = "IdGroupe"; // Valeur de la combobox
            //Button valider
            btn_Valider.Click += (s, e) => ActionMusicien(); // On affecte la fonction au bouton
            btn_Valider.Content = this.Action;


            switch (this.Action)
            {
                case "Ajouter":
                    // rien à faire
                    break;
                case "Modifier":
                    txbNom.Text = Musicien.Nom;
                    txbPrenom.Text = Musicien.Prenom;
                    txbInstrument.Text = Musicien.Instrument;
                    //Groupe
                    // On sélectionne par défaut la valeur du groupe actuel du musicien
                    cbGroupe.SelectedValue = Musicien.IdGroupe;
                    break;
                case "Supprimer":
                    // Tous les champs ne sont pas modifiable
                    txbNom.Text = Musicien.Nom;
                    txbPrenom.Text = Musicien.Prenom;
                    txbInstrument.Text = Musicien.Instrument;
                    cbGroupe.SelectedValue = Musicien.IdGroupe;

                    txbNom.IsEnabled = false;
                    txbPrenom.IsEnabled = false;
                    txbInstrument.IsEnabled = false;
                    cbGroupe.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ActionMusicien()
        {
            MusiciensDTOIn musicien = new MusiciensDTOIn
            {
                IdMusicien = this.Id,
                Nom = txbNom.Text,
                Prenom = txbPrenom.Text,
                Instrument = txbInstrument.Text,
                IdGroupe = (int)cbGroupe.SelectedValue,
            };
            // on appelle la méthode de la fenêtre mère (parce qu'elle contient le controller)
            this.FenetreAppel.ActionMusicien(musicien, this.Action, this.Id);
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
    }
}
