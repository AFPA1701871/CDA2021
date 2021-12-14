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
    /// Logique d'interaction pour EleveForm.xaml
    /// </summary>
    public partial class EleveForm : Window
    {
        //private MainWindow FenetreMere { get; set; }
        private EleveController _EleveController { get; set; }
        private GCantineContext _context { get; set; }
        private Eleves _FenetreMere { get; set; }
        public string _Mode { get; set; }
        public EleveDTOOut _Eleve { get; set; }

        public EleveForm(Eleves FenetreMere,GCantineContext _ctx,string mode)
        {

            _context = _ctx;
            _FenetreMere = FenetreMere;
            _Mode = mode;
            InitializeComponent();
            Init();
        }
        public EleveForm(Eleves FenetreMere, GCantineContext _ctx, string mode, EleveDTOOut E)
        {

            _context = _ctx;
            _FenetreMere = FenetreMere;
            _Mode = mode;
            _Eleve = E;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this._EleveController = new EleveController(_context);
            if (_Mode == "Modifier")
            {
                this.Prenom.Text = _Eleve.PrenomEleve;
                this.Nom.Text = _Eleve.NomEleve;
                this.DateDeNaissance.SelectedDate = DateTime.Parse(_Eleve.DDNEleve);
            }
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            string NomEleve = this.Nom.Text;
            string PrenomEleve = this.Prenom.Text;
            DateTime DDNEleve = (DateTime)this.DateDeNaissance.SelectedDate;
            EleveDTOIn E = new EleveDTOIn();
            E.NomEleve = NomEleve;
            E.PrenomEleve = PrenomEleve;
            E.DDNEleve = DDNEleve;
            if (_Mode == "Ajouter")
            {
            _EleveController.CreateEleve(E);
            }
            else if (_Mode == "Modifier")
            {
                _EleveController.UpdateEleve(_Eleve.IdEleve , E);
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
