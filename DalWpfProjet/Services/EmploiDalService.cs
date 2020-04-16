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
    public class EmploiDalService : ServiceBase<EmploiDalService>, IRepositories<int, EmploiDal>
    {
        private string connectionString = @"";

        public int Create(EmploiDal parametre)
        {
            using(SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddOffreEmploiBis";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.AddWithValue(nameof(parametre.fonction), parametre.fonction);
                    command.Parameters.AddWithValue(nameof(parametre.jobDescription), parametre.jobDescription);
                    command.Parameters.AddWithValue(nameof(parametre.diplomeMin), parametre.diplomeMin);
                    command.Parameters.AddWithValue(nameof(parametre.experienceMin), parametre.experienceMin);
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
                    command.CommandText = "DeleteOffreEmploi";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("offreEmploiId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<EmploiDal> GetAll()
        {
            List<EmploiDal> lb = new List<EmploiDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from OffreEmploi";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            EmploiDal b = new EmploiDal();
                            b.offreEmploiId = (int)dataReader["offreEmploiId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.jobDescription = (string)dataReader["jobDescription"];
                            b.fonction = (string)dataReader["fonction"];
                            b.diplomeMin = (string)dataReader["diplomeMin"];
                            b.experienceMin = (int)dataReader["experienceMin"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public EmploiDal GetOne(int id)
        {
            EmploiDal b = new EmploiDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from OffreEmploi where offreEmploiId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            b.offreEmploiId = (int)dataReader["offreEmploiId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.jobDescription = (string)dataReader["jobDescription"];
                            b.fonction = (string)dataReader["fonction"];
                            b.diplomeMin = (string)dataReader["diplomeMin"];
                            b.experienceMin = (int)dataReader["experienceMin"];
                            
                        }
                    }
                }
            }
            return b;
        }

        public void Update(EmploiDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditOffreEmploi";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.offreEmploiId), parametre.offreEmploiId);
                    command.Parameters.AddWithValue(nameof(parametre.fonction), parametre.fonction);
                    command.Parameters.AddWithValue(nameof(parametre.jobDescription), parametre.jobDescription);
                    command.Parameters.AddWithValue(nameof(parametre.diplomeMin), parametre.diplomeMin);
                    command.Parameters.AddWithValue(nameof(parametre.experienceMin), parametre.experienceMin);
                    con.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
