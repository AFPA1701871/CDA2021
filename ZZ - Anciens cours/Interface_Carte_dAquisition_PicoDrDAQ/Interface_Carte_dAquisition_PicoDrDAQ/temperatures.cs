using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    class Temperature
    {
        private int id_temp;
        private DateTime date_temp;
        private float temp1;
        private MySqlConnection con; // contient la connexion à la base de données
        public int Id_temp { get => id_temp; set => id_temp = value; }
        public DateTime Date_temp { get => date_temp; set => date_temp = value; }
        public float Temp1 { get => temp1; set => temp1 = value; }
        public enum listeDesChamps { id_temp, date_temp, temp1 }
        // L'énumération permet de faire réfernce aux colonnes en s'abstenant de connaitre l'ordre de celles-ci
        // L'ordre de l'enum doit être identique à l'ordre des colonnes dans la table
        public Temperature()
        {
            DBConnect db = new DBConnect();
            con = db.Connexion;
        }
        public static string DateSQL(DateTime d)
        {
            string dformat = d.Year + "-" + d.Month + "-" + d.Day + "-" + d.Hour + "-" + d.Minute + "-" + d.Second + "-" + d.Millisecond;
            return dformat;
        }
        public static List<Temperature> GetListTemp()
        {
            List<Temperature> listeTemp = new List<Temperature>();
            DBConnect db = new DBConnect();
            MySqlConnection connexion = db.Connexion;
            String sqlQuery = "select * from temperatures";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, connexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Temperature tem = new Temperature();
                tem.id_temp = (Int32)dr[(int)listeDesChamps.id_temp];
                // on fait référence à la colonne grâce au nom dans l'enum
                tem.date_temp = Convert.ToDateTime(dr[(int)listeDesChamps.date_temp]);
                tem.temp1 = (float)dr[(int)listeDesChamps.temp1];
                listeTemp.Add(tem);
            }
            return listeTemp;
        }
        public void FindById()
        {
            DataRow dr;
            String sqlQuery = "select * from temperatures where id_temp = " + id_temp;
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dr = dt.Rows[0];
            this.id_temp = (Int32)dr[(int)listeDesChamps.id_temp];
            // on fait référence à la colonne grâce au nom dans l'enum
            this.date_temp = Convert.ToDateTime(dr[(int)listeDesChamps.date_temp]);
            this.temp1 = (float)dr[(int)listeDesChamps.temp1];
        }
        public void Insert()
        {
            float aux = (temp1 / (float)10.0);
            String sqlQuery = "INSERT INTO temperatures (temp1) VALUES ( " + aux + " );";
            sqlQuery = sqlQuery.Replace(',', '.');
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();

        }
        public void Update()
        {
            float aux = temp1/10;
            String sqlQuery = "UPDATE temperatures SET temp1 = " + aux + " WHERE id_temp = " + id_temp;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();

        }
        public void Delete()
        {
            String sqlQuery = "DELETE FROM temperatures WHERE id_temp = " + id_temp;
            MySqlCommand com = new MySqlCommand(sqlQuery, con);
            MySqlDataReader read;
            read = com.ExecuteReader();
        }
    }
}
