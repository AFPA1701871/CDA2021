using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Listes;
using GestionCantine.MessageDErreur;
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
    /// Logique d'interaction pour PaiementForm.xaml
    /// </summary>
    public partial class PaiementForm : Window
    {
        private Paiements FenetreMere { get; set; }
        private PaiementDTOOut Paiement { get; set; }
        private ModeDePaiementController ModeDePaiementController { get; set; }
        private EleveController EleveController { get; set; }
        private string Action { get; set; }
        public int Id { get; set; }
        public PaiementForm(string action, Paiements fenetreMere, PaiementDTOOut paiement, GCantineContext _ctx)
        {
            InitializeComponent();
            this.FenetreMere = fenetreMere;
            this.Paiement = paiement;
            this.ModeDePaiementController = new ModeDePaiementController(_ctx);
            this.EleveController = new EleveController(_ctx);
            this.Action = action;
            this.Id = paiement == null ? 0 : paiement.IdPaiement;
            Init();
        }

        private void Init()
        {
            FpEleve.ItemsSource = this.EleveController.GetAllEleve();
            FpModeDePaiement.ItemsSource = this.ModeDePaiementController.GetAllModeDePaiement();
            FpModeDePaiement.DisplayMemberPath = "LibelleModeDePaiement";
            FpModeDePaiement.SelectedValuePath = "IdModeDePaiement";
            FpEleve.SelectedValuePath = "IdEleve";

            if (this.Action== "Modifier")
            {
                FpMontant.Text = "" + this.Paiement.MontantPaiement;
                FpDate.SelectedDate = DateTime.Parse(this.Paiement.DatePaiement);
                FpModeDePaiement.SelectedValue = Paiement.IdModeDePaiement;
                FpEleve.SelectedValue = Paiement.IdEleve;
            }
            
        }

        private void Valider(object sender, RoutedEventArgs e)
        {
            if (ControlSaisieCorrect())
            {
                PaiementDTOIn paiement = new PaiementDTOIn
                {
                    MontantPaiement = double.Parse(FpMontant.Text),
                    DatePaiement = FpDate.SelectedDate,
                    IdEleve = (int)FpEleve.SelectedValue,
                    IdModeDePaiement = (int)FpModeDePaiement.SelectedValue
                };
                this.FenetreMere.ActionPaiement(paiement, this.Action, this.Id);
                this.Fermer();
            }
            else
            {
                new SaisieFormIncorrect().ShowDialog();
            }  
        }
        private void Retour(object sender, RoutedEventArgs e)
        {

            this.Fermer();
        }
        private void Fermer()
        {
            this.Close();
        }
        private bool ControlSaisieCorrect()
        {
            FpMontant.Text=FpMontant.Text.Replace('.', ',');
            return double.TryParse(FpMontant.Text, out double sortie) && FpDate.SelectedDate != null && FpEleve.SelectedValue != null && FpModeDePaiement.SelectedValue != null;
        }
    }
}
