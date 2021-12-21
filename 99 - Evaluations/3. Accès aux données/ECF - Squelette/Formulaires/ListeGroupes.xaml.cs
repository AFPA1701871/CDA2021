using ECF.Controllers;
using ECF.Data;
using ECF.Data.Dtos;
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
    /// Logique d'interaction pour ListeGroupes.xaml
    /// </summary>
    public partial class ListeGroupes : Window
    {

        EcfContext _context;
        GroupesController _groupesController;

        public ListeGroupes(EcfContext context)
        {
            InitializeComponent();
            // centrer la fenetre
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _context = context;
            _groupesController = new GroupesController(_context);
            // On rempli la datagrid
            DgListeGroupes.ItemsSource = _groupesController.GetAllGroupes();

        }

        /// <summary>
        /// Méthode qui capte le click sur l'un des boutons d'actions et ouvre le formulaire dans le mode correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActions_Click(object sender, RoutedEventArgs e)
        {
            // On récupère l'article selectionné
            GroupesDTOOut musicien = (GroupesDTOOut)DgListeGroupes.SelectedItem;
            string nom = (string)((Button)sender).Content;
            // Si pas d'article sélectionné et click sur le bouton modifier ou supprimer, on affiche un message d'erreur
            if (musicien == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                MessageBox.Show("Vous devez sélectionner une ligne", "Erreur de sélection",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // On ouvre la fenêtre de détail
                // Elle prend les arguments suivants : l'action cliqué, la fenêtre mère, l'article selectionné, le context
                FormulaireGroupe actions = new FormulaireGroupe(nom, this, musicien, _context);
                this.Opacity = 0.7;
                actions.ShowDialog();
                this.Opacity = 1;
            }
        }

        public void ActionGroupe(GroupesDTOIn musicien, string action, int id)
        {
            // On met à jour le musicien en base de données
            // en fonction de l'action
            switch (action)
            {
                case "Ajouter":
                    _groupesController.CreateGroupe(musicien);
                    break;
                case "Modifier":
                    _groupesController.UpdateGroupe(id, musicien);
                    break;
                case "Supprimer":
                    _groupesController.DeleteGroupe(id);
                    break;
            }

            ActualiserTableau();
        }

        private void ActualiserTableau()
        {
            // on recharge le datagrid
            DgListeGroupes.ItemsSource = _groupesController.GetAllGroupes();
        }

        public void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

