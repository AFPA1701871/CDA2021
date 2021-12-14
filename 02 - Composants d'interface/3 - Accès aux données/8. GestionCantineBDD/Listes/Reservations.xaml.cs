using GestionCantine.Controllers;
using GestionCantine.Data;
using GestionCantine.Formulaires;
using GestionCantine.Data.Dtos;
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
using GestionCantine.Data.Models;
using GestionCantine.MessageDErreur;

namespace GestionCantine.Listes
{
    /// <summary>
    /// Logique d'interaction pour Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        private MainWindow _FenetreMere { get; set; }
        private ReservationController _ReservationController { get; set; }
        private EleveController _EleveController { get; set; }
        private GCantineContext _Ctx { get; set; }

        public Reservations(MainWindow _FenetreMere, GCantineContext _ctx)
        {
            InitializeComponent();
            this._FenetreMere = _FenetreMere;
            this._Ctx = _ctx;
            Init();
        }

        public void Init()
        {
            this._ReservationController = new ReservationController(_Ctx);
            this._EleveController = new EleveController(_Ctx);
            dg.ItemsSource = _ReservationController.GetAllReservation();
        }



        private void Back(object sender, RoutedEventArgs e)
        {
            if (this.Left != this._FenetreMere.Left || this.Top != this._FenetreMere.Top)
            {
                this._FenetreMere.Left = this.Left;
                this._FenetreMere.Top = this.Top;
            }
            this.Close();
        }

        private void Button_Action(object sender, RoutedEventArgs e)
        {
            ReservationDTOOut reservation = (ReservationDTOOut)dg.SelectedItem;

            string action = (string)((Button)sender).Content;

            if (reservation == null && (action == "Modifier" || action == "Supprimer"))
            {
                PasDeSelection formulaire = new PasDeSelection();
                formulaire.ShowDialog();
            }
            else if (action == "Supprimer")
            {
                Suppression fautsuppr = new Suppression();
                if ((bool)fautsuppr.ShowDialog())
                {
                    if (DateTime.Now < DateTime.Parse(reservation.DateMenu))
                    { 
                        _EleveController.UpdateSoldeEleve((int) reservation.IdEleve, (double) reservation.PrixMenu);
                        
                    } else
                    {
                        MessageBox.Show("La réservation a été supprimée mais la personne n'est pas recréditée car la date du menu est inférieure à la date d'aujourd'hui");
                    }
                    _ReservationController.DeleteReservation(reservation.IdReservation);
                    Init();
                }
            }
            else
            {
                if (action == "Modifier" && DateTime.Now > DateTime.Parse(reservation.DateMenu))
                {
                    MessageBox.Show("Impossible de modifier une réservation d'un menu déjà passé.");
                } else
                {
                    ReservationsForm reservationForm = new((string)((Button)sender).Content, this, (ReservationDTOOut)dg.SelectedItem, _Ctx);
                    reservationForm.Left = this.Left;
                    reservationForm.Top = this.Top;
                    this.Visibility = Visibility.Hidden;
                    reservationForm.ShowDialog();
                    this.Init();
                }


                //if (DateTime.Now < DateTime.Parse(reservation.DateMenu))
                //{
                //    ReservationsForm reservationForm = new((string)((Button)sender).Content, this, (ReservationDTOOut)dg.SelectedItem, _Ctx);
                //    reservationForm.Left = this.Left;
                //    reservationForm.Top = this.Top;
                //    this.Visibility = Visibility.Hidden;
                //    reservationForm.ShowDialog();
                //    this.Init();
                //} else
                //{
                //    MessageBox.Show("Impossible de modifier une réservation d'un menu déjà passé.");
                //}
            }

        }
    }
}
