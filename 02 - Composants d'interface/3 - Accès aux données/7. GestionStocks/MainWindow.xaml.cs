
using GestionStocks.Controllers;
using GestionStocks.Data;
using GestionStocks.Data.Dtos;
using GestionStocks.Data.Models;
using GestionStocks.Data.Profiles;
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

namespace GestionStocks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyDbContext _context;
        ArticlesController _articlesController;
        public MainWindow()
        {
            InitializeComponent();
            /******** Différence avec une API  ********/
            // Définir un context qui sera envoyé au controller
            _context = new MyDbContext();
            _articlesController = new ArticlesController(_context);
            // On rempli la datagrid
            ListeArticles.ItemsSource = _articlesController.GetAllArticlesAvecLibelleCateg();

        }

        /// <summary>
        /// Méthode qui capte le click sur l'un des boutons d'actions et ouvre le formulaire dans le mode correspondant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActions_Click(object sender, RoutedEventArgs e)
        {
            // On récupère l'article selectionné
            ArticlesDTOAvecLibelleCategorie article = (ArticlesDTOAvecLibelleCategorie)ListeArticles.SelectedItem;
            string nom = (string)((Button)sender).Content;
            // Si pas d'article sélectionné et click sur le bouton modifier ou supprimer, on affiche un message d'erreur
            if (article == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                MessageBox.Show("Pas de sélection");
            }
            else
            {
                // On ouvre la fenêtre de détail
                // Elle prend les arguments suivants : l'action cliqué, la fenêtre mère, l'article selectionné, le context
                FormulaireArticle actions = new FormulaireArticle(nom, this, article,_context);
                this.Opacity = 0.7;
                actions.ShowDialog();
                this.Opacity = 1;
            }
        }

        public void ActionArticle(ArticlesDTOIn article, string action, int id)
        {
            // On met à jour l'article en base de données
            // en fonction de l'action
            switch (action)
            {
                case "Ajouter":
                    _articlesController.CreateArticle(article);
                    break;
                case "Modifier":
                    _articlesController.UpdateArticle(id,article);
                    break;
                case "Supprimer":
                    _articlesController.DeleteArticle(id);
                    break;
            }
            
            ActualiserTableau();
        }

        private void ActualiserTableau()
        {
            // on recharge le datagrid
            ListeArticles.ItemsSource = _articlesController.GetAllArticlesAvecLibelleCateg();
        }
    }
}
