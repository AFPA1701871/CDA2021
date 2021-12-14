using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
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
    /// Logique d'interaction pour Eleves.xaml
    /// </summary>
    public partial class Eleves : Window
    {
        private MainWindow FenetreMere { get; set; }
        private EleveController _EleveController { get; set; }
        public GCantineContext _context { get; set; }


        public Eleves(MainWindow FenetreMere, GCantineContext _ctx)
        {
            InitializeComponent();
            this.FenetreMere = FenetreMere;
            this._context = _ctx;
            Init();
        }

        private void Init()
        {            
            this._EleveController = new EleveController(_context);
            RefreshDG();
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            if (this.Left != this.FenetreMere.Left || this.Top != this.FenetreMere.Top)
            {
                this.FenetreMere.Left = this.Left;
                this.FenetreMere.Top = this.Top;
            }
            this.Close();
        }

        public void RefreshDG()
        {
            this.dg.ItemsSource = _EleveController.GetAllEleve();
        }

        private void Action(object sender, RoutedEventArgs e)
        {
            EleveDTOOut E = (EleveDTOOut)dg.SelectedItem;
            string mode = (string)((Button)sender).Content;
            double left = this.Left;
            double top = this.Top;
            switch (mode)
            {
                case "Ajouter":
                    EleveForm formEleveAdd = new(this, _context, mode);
                    formEleveAdd.Left = left;
                    formEleveAdd.Top = top;
                    this.Visibility = Visibility.Hidden;
                    formEleveAdd.Show();
                    break;
                case "Modifier":
                    if (dg.SelectedItem == null)
                    {
                        //Afficher window Erreur
                    }
                    else
                    {
                        EleveForm formEleveUp = new(this, _context, mode, E);
                        formEleveUp.Left = left;
                        formEleveUp.Top = top;
                        this.Visibility = Visibility.Hidden;
                        formEleveUp.Show();
                    }
                    break;
                case "Supprimer":
                    this.Opacity = 0.25;
                    Suppression windowSupp = new Suppression();
                    windowSupp.Left = left;
                    windowSupp.Top = top;
                    if ((bool)windowSupp.ShowDialog())
                    {
                        _EleveController.DeleteEleve(E.IdEleve);
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
