using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    class Luminosites
    {
        private int id_luminosite;
        private DateTime lum_date;
        private int lumi;
        private MySqlConnection con; // contient la connexion à la base de données
        public int Id_luminosite { get => id_luminosite; set => id_luminosite = value; }
        public DateTime Lum_date { get => lum_date; set => lum_date = value; }
        public int Lumi { get => lumi; set => lumi = value; }
        public enum listeDesChamps { id_luminosite, lum_date, lumi }
        // L'énumération permet de faire réfernce aux colonnes en s'abstenant de connaitre l'ordre de celles-ci
        // L'ordre de l'enum doit être identique à l'ordre des colonnes dans la table
        public Luminosites()
        {
            DBConnect db = new DBConnect();
            con = db.Connexion;
        }
        public static string DateSQL(DateTime d)
        {
            string dformat = d.Year + "-" + d.Month + "-" + d.Day + "-" + d.Hour + "-" + d.Minute + "-" + d.Second + "-" + d.Millisecond;
            return dformat;
        }
        public static List<Luminosites> GetListLum()
        {
            List<Luminosites> listeLum = new List<Luminosites>();
            DBConnect db = new DBConnect();
            MySqlConnection connexion = db.Connexion;
            String sqlQuery = "select * from luminosites";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, connexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Luminosites lum = new Luminosites();
                lum.id_luminosite = (Int32)dr[(int)listeDesChamps.id_luminosite];
                // on fait référence à la colonne grâce au nom dans l'enum
                lum.lum_date = Convert.ToDateTime(dr[(int)listeDesChamps.lum_date]);
                lum.lumi = (Int32)dr[(int)listeDesChamps.lumi];
                listeLum.Add(lum);
            }
            return listeLum;
        }
        public void FindById()
        {
            DataRow dr;
            String sqlQuery = "select * from luminosites where id_luminosite = " + id_luminosite;
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dr = dt.Rows[0];
            this.id_luminosite = (Int32)dr[(int)listeDesChamps.id_luminosite];
            // on fait référence à la colonne grâce au nom dans l'enum
            this.lum_date = Convert.ToDateTime(dr[(int)listeDesChamps.lum_date]);
            this.lumi = (Int32)dr[(int)listeDesChamps.lumi];
        }
        public void Insert()
        {
            String sqlQuery = "INSERT INTO luminosites (lumi) VALUES ('" + lumi + "');";
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
        public void Update()
        {
            String sqlQuery = "UPDATE luminosites SET  lumi = " + lumi + " WHERE id_luminosite = " + id_luminosite;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
        public void Delete()
        {
            String sqlQuery = "DELETE FROM luminosites WHERE id_luminosite = " + id_luminosite;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
    }
}