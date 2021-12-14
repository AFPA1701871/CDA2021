using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Formulaires;
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

namespace GestionCantine.Listes
{
    /// <summary>
    /// Logique d'interaction pour ModeDePaiement.xaml
    /// </summary>
    public partial class ModeDePaiements : Window
    {
        private MainWindow FenetreMere { get; set; }
        private ModeDePaiementController _ModeDePaiementController { get; set; }
        public GCantineContext _context { get; set; }


        public ModeDePaiements(MainWindow FenetreMere, GCantineContext _ctx)
        {
            InitializeComponent();
            this.FenetreMere = FenetreMere;
            this._context = _ctx;
            Init();
        }

        private void Init()
        {
            this._ModeDePaiementController = new ModeDePaiementController(_context);
            RefreshDG();
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            if (this.Left != this.FenetreMere.Left || this.Top != this.FenetreMere.Top)
            {
                this.FenetreMere.Left = this.Left;
                this.FenetreMere.Top = this.Top;
            }
            this.FenetreMere.Visibility = Visibility.Visible;
            this.Close();
        }

        public void RefreshDG()
        {
            this.dg.ItemsSource = _ModeDePaiementController.GetAllModeDePaiement();
        }

        private void Action(object sender, RoutedEventArgs e)
        {
            ModeDePaiementDTOOut M = (ModeDePaiementDTOOut)dg.SelectedItem;
            string mode = (string)((Button)sender).Content;
            double left = this.Left;
            double top = this.Top;
            switch (mode)
            {
                case "Ajouter":
                    ModeDePaiementForm formModeDePaiementAdd = new(this, _context, mode, M);
                    formModeDePaiementAdd.Left = left;
                    formModeDePaiementAdd.Top = top;
                    this.Visibility = Visibility.Hidden;
                    formModeDePaiementAdd.Show();
                    break;
                case "Modifier":
                    if (dg.SelectedItem == null)
                    {
                        //Afficher window Erreur
                    }
                    else
                    {
                        ModeDePaiementForm formModeDePaiementUp = new(this, _context, mode, M);
                        formModeDePaiementUp.Left = left;
                        formModeDePaiementUp.Top = top;
                        this.Visibility = Visibility.Hidden;
                        formModeDePaiementUp.Show();
                    }
                    break;
                case "Supprimer":
                    this.Opacity = 0.25;
                    Suppression windowSupp = new Suppression();
                    windowSupp.Left = left;
                    windowSupp.Top = top;
                    if ((bool)windowSupp.ShowDialog())
                    {
                        _ModeDePaiementController.DeleteModeDePaiement(M.IdModeDePaiement);
                        Init();
                    }
                    this.Opacity = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
