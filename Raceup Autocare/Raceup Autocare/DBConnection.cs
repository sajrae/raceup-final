using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Raceup_Autocare
{
    class DBConnection
    {
     
        //public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\database\raceup_db_new3.accdb;OLE DB Services=-1";
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\SERVER\Users\SERVER\RaceUp-Autocare\raceup_db_new3.accdb";
        public static OleDbConnection thisConnection = null;

        public OleDbDataReader ConnectToOleDB(String sqlQuery) {
            
            thisConnection = new OleDbConnection(connectionString);
            
            thisConnection.Open();

            OleDbCommand userCommand = new OleDbCommand(sqlQuery, thisConnection);
            OleDbDataReader userReader = userCommand.ExecuteReader();
            
            return userReader;
        }

        public OleDbConnection openConnection() {
            thisConnection = new OleDbConnection(connectionString);
            thisConnection.Open();
            return thisConnection;
        }

        public void CloseConnection() {
            thisConnection.Close();
        }
    }
}
