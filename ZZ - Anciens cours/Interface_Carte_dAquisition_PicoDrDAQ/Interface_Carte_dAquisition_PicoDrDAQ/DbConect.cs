using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Interface_Carte_dAquisition_PicoDrDAQ
{
    class DBConnect
    {
        // Attributs permettant de générer la chaine de connection
        static private string DatabaseServer = "localhost";
        static private string DatabaseName = "drdac_donnee";
        static private string DatabaseUser = "root";
        static private string DatabasePwd = "";
        MySqlConnection connexion;
        public MySqlConnection Connexion { get => connexion; set => connexion = value; }
        /// <summary>
        /// Permet d'établir une connection avec la base de données
        /// </summary>
        /// <returns></returns>
        public  DBConnect()
        {
            string connexionString = "server=" + DatabaseServer + ";database=" + DatabaseName + ";uid=" + DatabaseUser + ";pwd=" + DatabasePwd + ";SslMode=none";
            connexion = new MySqlConnection(connexionString);
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not open connection ! ");
            }

        }
    }
}
