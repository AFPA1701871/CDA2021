using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    class Couleurs
    {
        private int id_couleur;
        private DateTime coul_date;        
        private int num_rouge;
        private int num_bleu;
        private int num_vert;
        private MySqlConnection con; // contient la connexion à la base de données
        public int Id_couleur { get => id_couleur; set => id_couleur = value; }
        public DateTime Coul_date { get => coul_date; set => coul_date = value; }
        public int Num_rouge { get => num_rouge; set => num_rouge = value; }
        public int Num_bleu { get => num_bleu; set => num_bleu = value; }
        public int Num_vert { get => num_vert; set => num_vert = value; }
        public enum listeDesChamps { id_couleur, coul_date, num_rouge, num_bleu, num_vert }
        // L'énumération permet de faire réfernce aux colonnes en s'abstenant de connaitre l'ordre de celles-ci
        // L'ordre de l'enum doit être identique à l'ordre des colonnes dans la table
        public Couleurs()
        {
            DBConnect db = new DBConnect();
            con = db.Connexion;
        }
        public static string DateSQL(DateTime d)
        {
            string dformat = d.Year + "-" + d.Month + "-" + d.Day + "-" + d.Hour + "-" + d.Minute + "-" + d.Second + "-" + d.Millisecond;
            return dformat;
        }
        public static List<Couleurs> GetListCoul()
        {
            List<Couleurs> listeLum = new List<Couleurs>();
            DBConnect db = new DBConnect();
            MySqlConnection connexion = db.Connexion;
            String sqlQuery = "select * from Couleurs";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, connexion);


            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Couleurs c = new Couleurs();
                c.id_couleur = (Int32)dr[(int)listeDesChamps.id_couleur];
                // on fait référence à la colonne grâce au nom dans l'enum
                c.coul_date = Convert.ToDateTime(dr[(int)listeDesChamps.coul_date]);
                c.num_rouge = (Int32)dr[(int)listeDesChamps.num_rouge];
                c.num_bleu = (Int32)dr[(int)listeDesChamps.num_bleu];
                c.num_vert = (Int32)dr[(int)listeDesChamps.num_vert];
                listeLum.Add(c);
            }
            return listeLum;
        }
        public void FindById()
        {
            DataRow dr;
            String sqlQuery = "select * from Couleurs where id_couleur = " + id_couleur;
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dr = dt.Rows[0];
            this.id_couleur = (Int32)dr[(int)listeDesChamps.id_couleur];
            // on fait référence à la colonne grâce au nom dans l'enum
            this.coul_date = Convert.ToDateTime(dr[(int)listeDesChamps.coul_date]);
            this.num_rouge = (Int32)dr[(int)listeDesChamps.num_rouge];
            this.num_bleu = (Int32)dr[(int)listeDesChamps.num_bleu];
            this.num_vert = (Int32)dr[(int)listeDesChamps.num_vert];
        }
        public void Insert(int rouge,int bleu,int vert)
        {
            num_rouge = rouge;
            num_bleu = bleu;
            num_vert = vert;
            String sqlQuery = "INSERT INTO Couleurs (num_rouge,num_bleu,num_vert) VALUES ( " +  num_rouge + " ," + num_bleu + " ," + num_vert + " );";
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
        public void Update()
        {
            String sqlQuery = "UPDATE Couleurs SET Num_rouge = " + Num_rouge + "' , Num_bleu = " + Num_bleu + "' , Num_vert = " + Num_vert + " WHERE id_couleur = " + id_couleur;

            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();

        }
        public void Delete()
        {
            String sqlQuery = "DELETE FROM Couleurs WHERE id_couleur = " + id_couleur;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
    }
}