using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Data.Models;
using GestionCantine.Listes;
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

namespace GestionCantine.Formulaires
{
    /// <summary>
    /// Logique d'interaction pour ModeDePaiementForm.xaml
    /// </summary>
    public partial class ModeDePaiementForm : Window
    {
        private ModeDePaiementController _ModeDePaiementController { get; set; }
        private GCantineContext _context { get; set; }
        private ModeDePaiements _FenetreMere { get; set; }
        public string _Mode { get; set; }
        public ModeDePaiementDTOOut _ModePaiement { get; set; }

        public ModeDePaiementForm(ModeDePaiements FenetreMere, GCantineContext _ctx, string Mode)
        {
            _Mode = Mode;
            _FenetreMere = FenetreMere;
            _context = _ctx;
            InitializeComponent();
            Init();
        }
        public ModeDePaiementForm(ModeDePaiements FenetreMere, GCantineContext _ctx, string Mode,ModeDePaiementDTOOut M)
        {   
            _context = _ctx;
            _FenetreMere = FenetreMere;
            _Mode = Mode;
            _ModePaiement = M;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this._ModeDePaiementController = new ModeDePaiementController(_context);
            if (_Mode == "Modifier")
            {
                this.Libelle.Text = _ModePaiement.LibelleModeDePaiement;
            }
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            string LibelleModeDePaiement = this.Libelle.Text;
            ModeDePaiementDTOIn E = new();
            E.LibelleModeDePaiement = LibelleModeDePaiement;
            if (_Mode == "Ajouter")
            {
                _ModeDePaiementController.CreateModeDePaiement(E);
            }
            else if (_Mode == "Modifier")
            {
                _ModeDePaiementController.UpdateModeDePaiement(_ModePaiement.IdModeDePaiement, E);
            }


            if (this.Left != this._FenetreMere.Left || this.Top != this._FenetreMere.Top)
            {
                this._FenetreMere.Left = this.Left;
                this._FenetreMere.Top = this.Top;
            }
            this._FenetreMere.Visibility = Visibility.Visible;
            _FenetreMere.RefreshDG();
            this.Close();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (this.Left != this._FenetreMere.Left || this.Top != this._FenetreMere.Top)
            {
                this._FenetreMere.Left = this.Left;
                this._FenetreMere.Top = this.Top;
            }
            this._FenetreMere.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
