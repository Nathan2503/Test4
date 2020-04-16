using DalWpfProjet.Models;
using DalWpfProjet.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Services
{
    public class EvenementDalService : ServiceBase<EvenementDalService>, IRepositories<int, EvenementDal>
    {
        private string connectionString = @"";

        public int Create(EvenementDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddEvenementBis";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.AddWithValue(nameof(parametre.eventDateDebut), parametre.eventDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.eventDateFin), parametre.eventDateFin);
                    command.Parameters.AddWithValue(nameof(parametre.eventDescription), parametre.eventDescription);
                    command.Parameters.Add(pid);
                    con.Open();
                    command.ExecuteNonQuery();
                    int id = (int)command.Parameters["ID"].Value;
                    return id;

                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "DeleteEvenement";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("eventId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<EvenementDal> GetAll()
        {
            List<EvenementDal> lb = new List<EvenementDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Evenement";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            EvenementDal b = new EvenementDal();
                            b.eventId = (int)dataReader["eventId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.eventDateDebut = (DateTime)dataReader["eventDateDebut"];
                            b.eventDateFin = (DateTime)dataReader["eventDateFin"];
                            b.eventDescription = (string)dataReader["eventDescription"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public EvenementDal GetOne(int id)
        {
            EvenementDal b = new EvenementDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Evenement where eventId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            b.eventId = (int)dataReader["eventId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.eventDateDebut = (DateTime)dataReader["eventDateDebut"];
                            b.eventDateFin = (DateTime)dataReader["eventDateFin"];
                            b.eventDescription = (string)dataReader["eventDescription"];
                            
                        }
                    }
                }
            }
            return b;
        }

        public void Update(EvenementDal parametre)
        {
            using(SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditEvenement";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.eventId), parametre.eventId);
                    command.Parameters.AddWithValue(nameof(parametre.eventDateDebut), parametre.eventDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.eventDateFin), parametre.eventDateFin);
                    command.Parameters.AddWithValue(nameof(parametre.eventDescription), parametre.eventDescription);
                    con.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
