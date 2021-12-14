using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Data.Dtos;
using GestionCantine.Formulaires;
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

namespace GestionCantine.Listes
{
    /// <summary>
    /// Logique d'interaction pour Paiements.xaml
    /// </summary>
    public partial class Paiements : Window
    {
        private MainWindow FenetreMere { get; set; }
        private PaiementController _PaiementController { get; set; }
        private EleveController _EleveController { get; set; }

        public Paiements(MainWindow FenetreMere, GCantineContext _ctx)
        {
            InitializeComponent();
            this.FenetreMere = FenetreMere;
            this._PaiementController = new PaiementController(_ctx);
            this._EleveController = new EleveController(_ctx);
            Init();
        }

        private void Init()
        {
            dgPaiements.ItemsSource = _PaiementController.GetAllPaiement();
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

        private void Button_Action(object sender, RoutedEventArgs e)
        {
            PaiementDTOOut paiement = (PaiementDTOOut)dgPaiements.SelectedItem;
            string action = (string)((Button)sender).Content;

            if (paiement==null &&(action!= "Ajouter"))
            {
                new PasDeSelection().ShowDialog();
            }
            else if (action == "Supprimer")
            {
                Suppression fautsuppr = new Suppression();
                if ((bool)fautsuppr.ShowDialog())
                {
                    _EleveController.UpdateSoldeEleve(paiement.IdEleve, (double) - paiement.MontantPaiement);
                    _PaiementController.DeletePaiement(paiement.IdPaiement);
                    Init();
                }
            }
            else
            {
                PaiementForm formulaire = new PaiementForm(action, this, paiement, FenetreMere._context);
                formulaire.ShowDialog();
            }
            
        }

        public void ActionPaiement(PaiementDTOIn Paiement, string action, int id)
        {
            // On met à jour l'Paiement en base de données
            // en fonction de l'action
            switch (action)
            {
                case "Ajouter":
                    _EleveController.UpdateSoldeEleve(Paiement.IdEleve, (double)Paiement.MontantPaiement);
                    _PaiementController.CreatePaiement(Paiement);
                    break;
                case "Modifier":
                    _EleveController.UpdateSoldeEleve(_PaiementController.GetPaiementById(id).IdEleve, (double) - _PaiementController.GetPaiementById(id).MontantPaiement);
                    _EleveController.UpdateSoldeEleve(Paiement.IdEleve, (double)Paiement.MontantPaiement);
                    _PaiementController.UpdatePaiement(id, Paiement);
                    break;
            }
            Init();
        }


    }
}
