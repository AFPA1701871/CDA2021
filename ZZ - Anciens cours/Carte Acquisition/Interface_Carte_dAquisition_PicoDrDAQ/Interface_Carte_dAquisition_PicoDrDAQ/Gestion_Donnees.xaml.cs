using MySql.Data.MySqlClient;
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

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    /// <summary>
    /// Logique d'interaction pour Gestion_Donnee.xaml
    /// </summary>
    public partial class Gestion_Donnees : Window
    {
        bool boolRbtnLum = false;
        bool boolRbtnCoul = false;
        bool boolRbtnSon = false;
        bool boolRbtnTemp = false;

        public Gestion_Donnees()
        {
            InitializeComponent();
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
        }
        void ChargerDTG()
        {

            if (boolRbtnLum == true)
                dgdAff_Donnee.ItemsSource = Luminosites.GetListLum();
            else if (boolRbtnCoul == true)
                dgdAff_Donnee.ItemsSource = Couleurs.GetListCoul();
            else if (boolRbtnSon == true)
                dgdAff_Donnee.ItemsSource = Sons.GetListSon();
            else if (boolRbtnTemp == true)
                dgdAff_Donnee.ItemsSource = Temperature.GetListTemp();
        }
        private void rbtnLum_Click(object sender, RoutedEventArgs e)
        {
            dgdAff_Donnee.ItemsSource = null;
            boolRbtnLum = true;
            boolRbtnCoul = false;
            boolRbtnSon = false;
            boolRbtnTemp = false;
            ChargerDTG();
            lbl1erDonnee.Visibility = Visibility.Visible;
            tbx1erDonnee.Visibility = Visibility.Visible;
            lbl2emDonnee.Visibility = Visibility.Visible;
            tbx2emDonnee.Visibility = Visibility.Visible;
            lbl3emDonnee.Visibility = Visibility.Visible;
            tbx3emDonnee.Visibility = Visibility.Visible;
            lbl4emDonnee.Visibility = Visibility.Hidden;
            tbx4emDonnee.Visibility = Visibility.Hidden;
            lbl5emDonnee.Visibility = Visibility.Hidden;
            tbx5emDonnee.Visibility = Visibility.Hidden;
            NettoyerChamp();
        }
        private void rbtnCoul_Click(object sender, RoutedEventArgs e)
        {
            dgdAff_Donnee.ItemsSource = null;
            boolRbtnLum = false;
            boolRbtnCoul = true;
            boolRbtnSon = false;
            boolRbtnTemp = false;
            ChargerDTG();
            lbl1erDonnee.Visibility = Visibility.Visible;
            tbx1erDonnee.Visibility = Visibility.Visible;
            lbl2emDonnee.Visibility = Visibility.Visible;
            tbx2emDonnee.Visibility = Visibility.Visible;
            lbl3emDonnee.Visibility = Visibility.Visible;
            tbx3emDonnee.Visibility = Visibility.Visible;
            lbl4emDonnee.Visibility = Visibility.Visible;
            tbx4emDonnee.Visibility = Visibility.Visible;
            lbl5emDonnee.Visibility = Visibility.Visible;
            tbx5emDonnee.Visibility = Visibility.Visible;
            NettoyerChamp();
        }
        private void rbtnSon_Click(object sender, RoutedEventArgs e)
        {
            dgdAff_Donnee.ItemsSource = null;
            boolRbtnLum = false;
            boolRbtnCoul = false;
            boolRbtnSon = true;
            boolRbtnTemp = false;
            ChargerDTG();
            lbl1erDonnee.Visibility = Visibility.Visible;
            tbx1erDonnee.Visibility = Visibility.Visible;
            lbl2emDonnee.Visibility = Visibility.Visible;
            tbx2emDonnee.Visibility = Visibility.Visible;
            lbl3emDonnee.Visibility = Visibility.Visible;
            tbx3emDonnee.Visibility = Visibility.Visible;
            lbl4emDonnee.Visibility = Visibility.Hidden;
            tbx4emDonnee.Visibility = Visibility.Hidden;
            lbl5emDonnee.Visibility = Visibility.Hidden;
            tbx5emDonnee.Visibility = Visibility.Hidden;
            NettoyerChamp();
        }
        private void rbtnTemp_Click(object sender, RoutedEventArgs e)
        {
            dgdAff_Donnee.ItemsSource = null;
            boolRbtnLum = false;
            boolRbtnCoul = false;
            boolRbtnSon = false;
            boolRbtnTemp = true;
            ChargerDTG();
            lbl1erDonnee.Visibility = Visibility.Visible;
            tbx1erDonnee.Visibility = Visibility.Visible;
            lbl2emDonnee.Visibility = Visibility.Visible;
            tbx2emDonnee.Visibility = Visibility.Visible;
            lbl3emDonnee.Visibility = Visibility.Visible;
            tbx3emDonnee.Visibility = Visibility.Visible;
            lbl4emDonnee.Visibility = Visibility.Hidden;
            tbx4emDonnee.Visibility = Visibility.Hidden;
            lbl5emDonnee.Visibility = Visibility.Hidden;
            tbx5emDonnee.Visibility = Visibility.Hidden;
            NettoyerChamp();
        }
        private void dgdAff_Donnee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (boolRbtnLum == true)
            {
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    NettoyerChamp();
                    lbl1erDonnee.Content = "N° enregistrement";
                    lbl2emDonnee.Content = "Date";
                    lbl3emDonnee.Content = "Lumi en %";
                    tbx1erDonnee.Text = Convert.ToString(((Luminosites)dgdAff_Donnee.SelectedValue).Id_luminosite);
                    tbx2emDonnee.Text = Convert.ToString(((Luminosites)dgdAff_Donnee.SelectedValue).Lum_date);
                    tbx3emDonnee.Text = Convert.ToString(((Luminosites)dgdAff_Donnee.SelectedValue).Lumi);
                    btnModifier.IsEnabled = true;
                    btnSupprimer.IsEnabled = true;
                }
            }
            else if (boolRbtnCoul == true)
            {
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    lbl1erDonnee.Content = "";
                    lbl2emDonnee.Content = "";
                    lbl3emDonnee.Content = "";
                    lbl4emDonnee.Content = "";
                    lbl5emDonnee.Content = "";
                    tbx1erDonnee.Text = "";
                    tbx2emDonnee.Text = "";
                    tbx3emDonnee.Text = "";
                    tbx4emDonnee.Text = "";
                    tbx5emDonnee.Text = "";
                    lbl1erDonnee.Content = "N° enregistrement";
                    lbl2emDonnee.Content = "Date";
                    lbl3emDonnee.Content = "Valeur Rouge";
                    lbl4emDonnee.Content = "Valeur Bleu";
                    lbl5emDonnee.Content = "Valeur Vert";
                    tbx1erDonnee.Text = Convert.ToString(((Couleurs)dgdAff_Donnee.SelectedValue).Id_couleur);
                    tbx2emDonnee.Text = Convert.ToString(((Couleurs)dgdAff_Donnee.SelectedValue).Coul_date);
                    tbx3emDonnee.Text = Convert.ToString(((Couleurs)dgdAff_Donnee.SelectedValue).Num_rouge);
                    tbx4emDonnee.Text = Convert.ToString(((Couleurs)dgdAff_Donnee.SelectedValue).Num_bleu);
                    tbx5emDonnee.Text = Convert.ToString(((Couleurs)dgdAff_Donnee.SelectedValue).Num_vert);
                    btnModifier.IsEnabled = true;
                    btnSupprimer.IsEnabled = true;
                }
            }
            else if (boolRbtnSon == true)
            {
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    lbl1erDonnee.Content = "";
                    lbl2emDonnee.Content = "";
                    lbl3emDonnee.Content = "";
                    lbl4emDonnee.Content = "";
                    lbl5emDonnee.Content = "";
                    tbx1erDonnee.Text = "";
                    tbx2emDonnee.Text = "";
                    tbx3emDonnee.Text = "";
                    tbx4emDonnee.Text = "";
                    tbx5emDonnee.Text = "";
                    lbl1erDonnee.Content = "N° enregistrement";
                    lbl2emDonnee.Content = "Date";
                    lbl3emDonnee.Content = "Bruit en dB";
                    tbx1erDonnee.Text = Convert.ToString(((Sons)dgdAff_Donnee.SelectedValue).Id_son);
                    tbx2emDonnee.Text = Convert.ToString(((Sons)dgdAff_Donnee.SelectedValue).Date_son);
                    tbx3emDonnee.Text = Convert.ToString(((Sons)dgdAff_Donnee.SelectedValue).Son);
                    btnModifier.IsEnabled = true;
                    btnSupprimer.IsEnabled = true;
                }
            }
            else if (boolRbtnTemp == true)
            {
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    lbl1erDonnee.Content = "";
                    lbl2emDonnee.Content = "";
                    lbl3emDonnee.Content = "";
                    lbl4emDonnee.Content = "";
                    lbl5emDonnee.Content = "";
                    tbx1erDonnee.Text = "";
                    tbx2emDonnee.Text = "";
                    tbx3emDonnee.Text = "";
                    tbx4emDonnee.Text = "";
                    tbx5emDonnee.Text = "";
                    lbl1erDonnee.Content = "N° enregistrement";
                    lbl2emDonnee.Content = "Date";
                    lbl3emDonnee.Content = "Température en C°";
                    tbx1erDonnee.Text = Convert.ToString(((Temperature)dgdAff_Donnee.SelectedValue).Id_temp);
                    tbx2emDonnee.Text = Convert.ToString(((Temperature)dgdAff_Donnee.SelectedValue).Date_temp);
                    tbx3emDonnee.Text = Convert.ToString(((Temperature)dgdAff_Donnee.SelectedValue).Temp1);
                    btnModifier.IsEnabled = true;
                    btnSupprimer.IsEnabled = true;
                }
            }
        }
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (boolRbtnLum == true)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
                Luminosites l = new Luminosites();
                l.Id_luminosite = ((Luminosites)dgdAff_Donnee.SelectedValue).Id_luminosite;
                if (tbx1erDonnee.Text != "" && tbx2emDonnee.Text != "" && tbx3emDonnee.Text != "")
                {
                    try
                    {
                        l.Id_luminosite = Convert.ToInt32(tbx1erDonnee.Text);
                        l.Lum_date = Convert.ToDateTime(tbx2emDonnee.Text);
                        l.Lumi = Convert.ToInt32(tbx3emDonnee.Text);
                        l.Update();
                    }
                    catch (Exception)
                    {

                        
                    }
                }
                ChargerDTG();
            }
            else if (boolRbtnCoul == true)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
                Couleurs c = new Couleurs();
                c.Id_couleur = ((Couleurs)dgdAff_Donnee.SelectedValue).Id_couleur;
                if (tbx1erDonnee.Text != "" && tbx2emDonnee.Text != "" && tbx3emDonnee.Text != "" && tbx4emDonnee.Text != "" && tbx5emDonnee.Text != "")
                {
                    try
                    {
                        c.Id_couleur = Convert.ToInt32(tbx1erDonnee.Text);
                        c.Coul_date = Convert.ToDateTime(tbx2emDonnee.Text);
                        c.Num_rouge = Convert.ToInt32(tbx3emDonnee.Text);
                        c.Num_bleu = Convert.ToInt32(tbx4emDonnee.Text);
                        c.Num_vert = Convert.ToInt32(tbx5emDonnee.Text);
                        c.Update();
                    }
                    catch (Exception)
                    {

                       
                    }
                }
                ChargerDTG();
            }
            else if (boolRbtnSon == true)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
                Sons s = new Sons();
                s.Id_son = ((Sons)dgdAff_Donnee.SelectedValue).Id_son;
                if (tbx1erDonnee.Text != "" && tbx2emDonnee.Text != "" && tbx3emDonnee.Text != "")
                {
                    try
                    {
                        s.Id_son = Convert.ToInt32(tbx1erDonnee.Text);
                        s.Date_son = Convert.ToDateTime(tbx2emDonnee.Text);
                        s.Son = Convert.ToInt32(tbx3emDonnee.Text);
                        s.Update();
                    }
                    catch (Exception)
                    {

                        
                    }
                }
                ChargerDTG();
            }
            else if (boolRbtnTemp == true)
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
                Temperature t = new Temperature();
                t.Id_temp = ((Temperature)dgdAff_Donnee.SelectedValue).Id_temp;
                if (tbx1erDonnee.Text != "" && tbx2emDonnee.Text != "" && tbx3emDonnee.Text != "")
                {
                    try
                    {
                        t.Id_temp = Convert.ToInt32(tbx1erDonnee.Text);
                        t.Date_temp = Convert.ToDateTime(tbx2emDonnee.Text);
                        t.Temp1 = Convert.ToInt32(tbx3emDonnee.Text);
                        t.Update();
                    }
                    catch (Exception)
                    {

                        
                    }
                }
                ChargerDTG();
            }
        }
        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            btnModifier.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
            if (boolRbtnLum == true)
            {
                Luminosites l = new Luminosites();
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    l.Id_luminosite = ((Luminosites)dgdAff_Donnee.SelectedValue).Id_luminosite;
                    l.Delete();
                    ChargerDTG();
                }
            }
            else if (boolRbtnCoul == true)
            {
                Couleurs c = new Couleurs();
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    c.Id_couleur = ((Couleurs)dgdAff_Donnee.SelectedValue).Id_couleur;
                    c.Delete();
                    ChargerDTG();
                }
            }
            else if (boolRbtnSon == true)
            {
                Sons s = new Sons();
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    s.Id_son = ((Sons)dgdAff_Donnee.SelectedValue).Id_son;
                    s.Delete();
                    ChargerDTG();
                }
            }
            else if (boolRbtnTemp == true)
            {
                Temperature t = new Temperature();
                if (dgdAff_Donnee.SelectedValue != null)
                {
                    t.Id_temp = ((Temperature)dgdAff_Donnee.SelectedValue).Id_temp;
                    t.Delete();
                    ChargerDTG();
                }
            }
        }
        private void NettoyerChamp()
        {
            lbl1erDonnee.Content = "";
            lbl2emDonnee.Content = "";
            lbl3emDonnee.Content = "";
            lbl4emDonnee.Content = "";
            lbl5emDonnee.Content = "";
            tbx1erDonnee.Text = "";
            tbx2emDonnee.Text = "";
            tbx3emDonnee.Text = "";
            tbx4emDonnee.Text = "";
            tbx5emDonnee.Text = "";
        }
    }
}
