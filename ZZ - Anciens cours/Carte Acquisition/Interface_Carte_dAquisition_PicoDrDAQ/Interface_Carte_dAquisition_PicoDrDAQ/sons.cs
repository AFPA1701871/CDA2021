using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    class Sons
    {
        private int id_son;
        private DateTime date_son;
        private int nv_son;
        private MySqlConnection con; // contient la connexion à la base de données
        public int Id_son { get => id_son; set => id_son = value; }
        public DateTime Date_son { get => date_son; set => date_son = value; }
        public int Son { get => nv_son; set => nv_son = value; }
        public enum listeDesChamps { id_son, date_son, nv_son }
        // L'énumération permet de faire réfernce aux colonnes en s'abstenant de connaitre l'ordre de celles-ci
        // L'ordre de l'enum doit être identique à l'ordre des colonnes dans la table
        public Sons()
        {
            DBConnect db = new DBConnect();
            con = db.Connexion;
        }
        public static string DateSQL(DateTime d)
        {
            string dformat = d.Year + "-" + d.Month + "-" + d.Day + "-" + d.Hour + "-" + d.Minute + "-" + d.Second + "-" + d.Millisecond;
            return dformat;
        }
        public static List<Sons> GetListSon()
        {
            List<Sons> listeSon = new List<Sons>();
            DBConnect db = new DBConnect();
            MySqlConnection connexion = db.Connexion;
            String sqlQuery = "select * from sons";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, connexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Sons s = new Sons();
                s.id_son = (Int32)dr[(int)listeDesChamps.id_son];
                // on fait référence à la colonne grâce au nom dans l'enum
                s.date_son = Convert.ToDateTime(dr[(int)listeDesChamps.date_son]);
                s.nv_son = (Int32)dr[(int)listeDesChamps.nv_son];
                listeSon.Add(s);
            }
            return listeSon;

        }
        public void FindById()
        {
            DataRow dr;
            String sqlQuery = "select * from sons where id_son = " + id_son;
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dr = dt.Rows[0];
            this.id_son = (Int32)dr[(int)listeDesChamps.id_son];
            // on fait référence à la colonne grâce au nom dans l'enum
            this.date_son = Convert.ToDateTime(dr[(int)listeDesChamps.date_son]);
            this.nv_son = (Int32)dr[(int)listeDesChamps.nv_son];
        }
        public void Insert()
        {
            String sqlQuery = "INSERT INTO sons (niv_son) VALUES ( " + nv_son/10 + " );";
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
        public void Update()
        {
            String sqlQuery = "UPDATE sons SET niv_son = " + nv_son + " WHERE id_son = " + id_son;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
        public void Delete()
        {
            String sqlQuery = "DELETE FROM sons WHERE id_son = " + id_son;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
    }
}