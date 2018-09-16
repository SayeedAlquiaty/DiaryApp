using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ClassRoomApp.SchoolRepository
{
    public class SchoolRepo
    {
        public static string connectionString = @"server=localhost;user id=root; Pwd = Thisisme1 database=modelhighschool;persistsecurityinfo=True";
        public void ConnectToMyDB()
        {
        

            try {

            }
            catch(Exception) {}
        }
            
      
        
    }
}
