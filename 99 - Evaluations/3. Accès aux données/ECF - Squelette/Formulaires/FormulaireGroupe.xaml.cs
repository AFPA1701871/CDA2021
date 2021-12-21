using ECF.Controllers;
using ECF.Data;
using ECF.Data.Dtos;
using ECF.Data.Models;
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
    /// Logique d'interaction pour FormulaireGroupe.xaml
    /// </summary>

    public partial class FormulaireGroupe : Window
    {
        // Attributs
        ListeGroupes FenetreAppel; // fenêtre d'appel
        GroupesDTOOut Groupe;
        string Action;
        int Id;

        // Constructeurs
        public FormulaireGroupe(string action, ListeGroupes window, GroupesDTOOut groupe, EcfContext _context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.FenetreAppel = window;
            // on récupère l'id de l'article, null si pas d'article
            this.Id = (groupe == null) ? 0 : groupe.IdGroupe;
            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;
            this.Groupe = groupe;

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
                    txbNomDuGroupe.Text = Groupe.NomDuGroupe;
                    txbNombreDeFollowers.Text = Groupe.NombreDeFollowers.ToString();
                    txbLogo.Text = Groupe.Logo;
                    ChargerImage(true);

                    break;
                case "Supprimer":
                    // Tous les champs ne sont pas modifiable
                    txbNomDuGroupe.Text = Groupe.NomDuGroupe;
                    txbNombreDeFollowers.Text = Groupe.NombreDeFollowers.ToString();
                    txbLogo.Text = Groupe.Logo;
                    ChargerImage(true);

                    txbNomDuGroupe.IsEnabled = false;
                    txbNombreDeFollowers.IsEnabled = false;
                    txbLogo.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }


        private void ActionGroupe(object sender, RoutedEventArgs e)
        {
            GroupesDTOIn groupe = new GroupesDTOIn
            {
                NomDuGroupe = txbNomDuGroupe.Text,
                NombreDeFollowers = Int32.Parse(txbNombreDeFollowers.Text),
                Logo = txbLogo.Text,
            };
            // on appelle la méthode de la fenêtre mère (parce qu'elle contient le controller)
            this.FenetreAppel.ActionGroupe(groupe, this.Action, this.Id);
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

        private void txbNombreDeFollowers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Int32.TryParse(txbNombreDeFollowers.Text, out Int32 result))
            {
                txbNombreDeFollowers.Text = "";
                MessageBox.Show("Nombre de Followers doit être un entier", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txbLogo_TextChanged(object sender, TextChangedEventArgs e)
        {

            lblInfoLogo.Content = "";
            ChargerImage(true);

        }
        private void ChargerImage(bool flag)
        {
            if (flag)
            {
                Uri uri = new Uri(@"/Images/" + txbLogo.Text, UriKind.RelativeOrAbsolute);
                imgLogo.Source = new BitmapImage(uri);
            }
            else
            {
                imgLogo.Source = null;
            }
        }
        string path = "Images/";
    }
}
