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
   
    public partial class Menus : Window
    {
        private MainWindow FenetreMere { get; set; }
        private MenuController _MenuController { get; set; }
        public GCantineContext _context { get; set; } 

        public Menus(MainWindow FenetreMere, GCantineContext __context)
        {
            InitializeComponent();
            _context = new GCantineContext();
            this.FenetreMere = FenetreMere;
            this._MenuController = new MenuController(_context);
            Init();
        }

        private void Init()
        {
            dgMenus.ItemsSource = _MenuController.GetAllMenu();
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

        private void Button_Actions_Click(object sender, RoutedEventArgs e)
        {
            MenuDTOOut menu = (MenuDTOOut)dgMenus.SelectedItem;
            string nom = (string)((Button)sender).Content;
           
            if (menu == null && (nom == "Modifier" || nom == "Supprimer"))
            {
                new PasDeSelection().ShowDialog();
            }
            else
            {
                
                MenusForm actions = new MenusForm(nom, this, menu, _context);
                this.Opacity = 0.7;
                actions.ShowDialog();
                this.Opacity = 1;
            }
        }

        private void Button_Action(object sender, RoutedEventArgs e)
        {
            MenuDTOOut menu = (MenuDTOOut)dgMenus.SelectedItem;
            string action = (string)((Button)sender).Content;

            if (menu == null && (action == "Modifier" || action == "Supprimer"))
            {
                new PasDeSelection().ShowDialog();
            }
            else if (action == "Supprimer")
            {
                Suppression windowSupp = new Suppression();
                if ((bool)windowSupp.ShowDialog())
                {
                    _MenuController.DeleteMenu(menu.IdMenu);
                    Init();
                }
            }
            else
            {

            }
        }
            public void ActionMenu(MenuDTOIn menu, string action, int id)
            {
                switch (action)
                {
                    case "Ajouter":
                        _MenuController.CreateMenu(menu);
                        break;
                    case "Modifier":
                        _MenuController.UpdateMenu(id, menu);
                        break;
                }

                ActualiseDgMenus();
            }
        
        private void ActualiseDgMenus()
        {
            dgMenus.ItemsSource = _MenuController.GetAllMenu();
        }
    }
}
