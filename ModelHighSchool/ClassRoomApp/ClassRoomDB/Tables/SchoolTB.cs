using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassRoomDB.Tables
{
    

    [Serializable()]
    public class School_row
    {
        public int School_id { get; set; }
        public string School_name { get; set; }
        public string School_cityname { get; set; }
        public string School_date_created { get; set; }
        public string School_date_deleted { get; set; }
    }
    [Serializable()]
    public class School_Info
    {
        public string School_id { get; set; }
        public string School_name { get; set; }
    }
    [Serializable()]
    public class CitySchools_list
    {
        public string School_cityname { get; set; }
        public List<string> School_name { get; set; }
    }

    [Serializable()]
    public class CitySchoolsInfo_list
    {
        public string School_cityname { get; set; }
        public List<School_Info> School_info { get; set; }
    }
    public class SchoolTB
    {
        public static string coonectionStr = "";

        public List<School_row> GetSchools(string _cityName, string _schoolName="")
        {
            List<School_row> _listOfSchool = new List<School_row>();
            //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["SchoolDB"];
            //Data Source=ALQUIATY-PC;Initial Catalog=ModelHighSchool;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
            var connectionString = String.Format("Data Source=ALQUIATY-PC;Initial Catalog=ModelHighSchool;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");// conSettings.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "dbo.uspGetSchoolId"
                };

                //var parameter1 = new SqlParameter("@school_id", SqlDbType.Int) { Value = 0};
                var parameter2 = new SqlParameter("@schoolname", SqlDbType.VarChar) { Value = _schoolName };
                var parameter3 = new SqlParameter("@cityname", SqlDbType.VarChar) { Value = _cityName };
                //command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);

                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                
                while (reader.Read())
                {
                    School_row _row = new School_row{
                        School_id = int.Parse(reader["school_id"].ToString()),
                        School_name = reader["school_name"].ToString(),
                        School_cityname = reader["school_cityname"].ToString(),
                        School_date_created = reader["school_date_created"].ToString(),
                        School_date_deleted = reader["school_date_deleted"].ToString()
                    };
                    _listOfSchool.Add(_row);
                }
            }

            return _listOfSchool;
        }

        public  CitySchools_list GetSchoolsInCity(string _cityName, string _schoolName = "")
        {
            
            List<string> _school_name = new List<string>();
            //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["SchoolDB"];
            //Data Source=ALQUIATY-PC;Initial Catalog=ModelHighSchool;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
            var connectionString = String.Format("Data Source=ALQUIATY-PC; Initial Catalog=ModelHighSchool; Integrated Security=true; Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");// conSettings.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "dbo.uspGetSchoolId"
                };

                //var parameter1 = new SqlParameter("@school_id", SqlDbType.Int) { Value = 0};
                var parameter2 = new SqlParameter("@schoolname", SqlDbType.VarChar) { Value = _schoolName };
                var parameter3 = new SqlParameter("@cityname", SqlDbType.VarChar) { Value = _cityName };
                //command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);

                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    _school_name.Add( reader["school_name"].ToString());
                }
            }
            CitySchools_list _listOfSchools = new CitySchools_list
            {
                School_cityname = _cityName,
                School_name = _school_name
            };

            return _listOfSchools;
        }

        public CitySchoolsInfo_list GetCitySchoolsInfo(string _cityName, string _schoolName = "")
        {

            List<School_Info> _school_info = new List<School_Info>();
            //ConnectionStringSettings conSettings = ConfigurationManager.ConnectionStrings["SchoolDB"];
            //Data Source=ALQUIATY-PC;Initial Catalog=ModelHighSchool;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False
            var connectionString = String.Format("Data Source=ALQUIATY-PC; Initial Catalog=ModelHighSchool; Integrated Security=true; Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");// conSettings.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "dbo.uspGetSchoolId"
                };

                //var parameter1 = new SqlParameter("@school_id", SqlDbType.Int) { Value = 0};
                var parameter2 = new SqlParameter("@schoolname", SqlDbType.VarChar) { Value = _schoolName };
                var parameter3 = new SqlParameter("@cityname", SqlDbType.VarChar) { Value = _cityName };
                //command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);

                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    School_Info _temp = new School_Info();
                    _temp.School_id = reader["school_id"].ToString();
                    _temp.School_name = reader["school_name"].ToString();
                    _school_info.Add(_temp);
                }
            }
            CitySchoolsInfo_list _listOfSchools = new CitySchoolsInfo_list
            {
                School_cityname = _cityName,
                School_info = _school_info
            };

            return _listOfSchools;
        }
    }
}
