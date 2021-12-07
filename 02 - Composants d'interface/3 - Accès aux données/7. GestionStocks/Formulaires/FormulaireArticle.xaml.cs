using GestionStocks.Controllers;
using GestionStocks.Data;
using GestionStocks.Data.Dtos;
using GestionStocks.Data.Models;
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

namespace GestionStocks
{
    /// <summary>
    /// Logique d'interaction pour FormulaireArticle.xaml
    /// </summary>

    public partial class FormulaireArticle : Window
    {
        // Attributs
        MainWindow Window; // fenêtre d'appel
        ArticlesDTOAvecLibelleCategorie Article;
        CategoriesController CategorieController;
        string Action;
        int Id;

        // Constructeurs
        public FormulaireArticle(string action, MainWindow window, ArticlesDTOAvecLibelleCategorie article, MyDbContext _context)
        {
            InitializeComponent();
            this.Article = article;
            this.Window = window;
            // on récupère l'id de l'article, null si pas d'article
            this.Id = (article == null) ? 0 : article.IdArticle;
            // On récupère le type d'action Ajouter, Modifier, Supprimer à partir de l'information du bouton cliqué
            this.Action = action;

            CategorieController = new CategoriesController(_context);

            InitPage();
        }

        //Autres méthodes

        /// <summary>
        /// Méthode qui permet de remplir le formulaire à partir des données de la classe
        /// </summary>
        private void InitPage()
        {

            //on met à jour le titre de la fenetre
            labTitreFormulaire.Content = this.Action + " un article";

            // on rempli la combobox categorie
            cbCategorie.ItemsSource = CategorieController.GetAllCategoriesModel();
            cbCategorie.DisplayMemberPath = "LibelleCategorie"; //Valeur a afficher dans la combobox
            cbCategorie.SelectedValuePath = "IdCategorie"; // Valeur de la combobox
            //Button valider
            btn_Valider.Click += (s, e) => ActionArticle(); // On affecte la fonction au bouton
            btn_Valider.Content = this.Action;


            switch (this.Action)
            {
                case "Ajouter":
                    // rien à faire
                    break;
                case "Modifier":
                    //Libelle
                    txbLibelle.Text = Article.LibelleArticle;
                    //Quantité
                    txbQuantite.Text = Article.QuantiteStockee.ToString();
                    //Categorie
                    // On sélectionne par défaut la valeur de la catégorie actuelle de l'article
                    cbCategorie.SelectedValue = Article.IdCategorie;
                    break;
                case "Supprimer":
                    // Tous les champs ne sont pas modifiable

                    //Libelle
                    txbLibelle.Text = Article.LibelleArticle;
                    txbLibelle.IsEnabled = false;
                    //Quantité
                    txbQuantite.Text = Article.QuantiteStockee.ToString();
                    txbQuantite.IsEnabled = false;
                    //Categorie
                    cbCategorie.SelectedValue = Article.IdCategorie;
                    cbCategorie.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ActionArticle()
        {
            ArticlesDTOIn article = new ArticlesDTOIn
            {
                LibelleArticle = txbLibelle.Text,
                QuantiteStockee = int.Parse(txbQuantite.Text),
                IdCategorie = (int)cbCategorie.SelectedValue
            };
            // on appelle la méthode de la fenêtre mère (parce qu'elle contient le controller)
            this.Window.ActionArticle(article, this.Action, this.Id);
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
