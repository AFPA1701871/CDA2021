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
    /// Logique d'interaction pour MenusForm.xaml
    /// </summary>
    public partial class MenusForm : Window
    {
        private Menus MainMenu { get; set; }
        private MenuDTOOut Menu { get; set; }
        private string Action { get; set; }
        private int Id { get; set; }

        public MenusForm(string action, Menus mainMenu, MenuDTOOut menu, GCantineContext _context)
        {
            InitializeComponent();

            this.MainMenu = mainMenu;
            this.Menu = menu;
            this.Action = action;
            this.Id = (menu == null) ? 0 : menu.IdMenu;

            InitPage();
        }

        private void InitPage()
        {
            Button_Valider.Click += (s, e) => ActionMenu(); // On affecte la fonction au bouton
            Button_Valider.Content = this.Action;

            switch (this.Action)
            {
                case "Ajouter":
                    
                    break;
                case "Modifier":
                    DPDateMenu.SelectedDate = DateTime.Parse(Menu.DateMenu);
                    TextLibelleMenu.Text = Menu.LibelleMenu;
                    TextPrixMenu.Text = Menu.PrixMenu.ToString();
                    break;
               
                default:
                    break;
            }
        }
        private void ActionMenu()
        {
            if (ControlSaisieCorrect())
            {
                MenuDTOIn menu = new MenuDTOIn
                {
                    DateMenu = DateTime.Parse(DPDateMenu.Text),
                    LibelleMenu = TextLibelleMenu.Text,
                    PrixMenu = double.Parse(TextPrixMenu.Text)
                };
                //appel du controller de la fenêtre mère
                this.MainMenu.ActionMenu(menu, this.Action, this.Id);
                Retour();
            }
            else
            {
                new SaisieFormIncorrect().ShowDialog();
            }
        }
        public void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Retour()
        {
            this.Close();
        }

        private bool ControlSaisieCorrect()
        {
            TextPrixMenu.Text = TextPrixMenu.Text.Replace('.', ',');
            return double.TryParse(TextPrixMenu.Text, out double sortie) && DPDateMenu.SelectedDate != null && TextLibelleMenu.Text != null;
        }
    }

}

