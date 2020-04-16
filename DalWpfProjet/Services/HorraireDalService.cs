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
    public class HorraireDalService : ServiceBase<HorraireDalService>, IRepositories<int, HorraireDal>
    {
        private string connectionString = @"";

        public int Create(HorraireDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddHorraireBis";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.AddWithValue(nameof(parametre.horraireDateDebut), parametre.horraireDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.horraireDateFin), parametre.horraireDateFin);
                    command.Parameters.AddWithValue(nameof(parametre.heureOuverture), parametre.heureOuverture);
                    command.Parameters.AddWithValue(nameof(parametre.heureFermeture), parametre.heureFermeture);
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
                    command.CommandText = "DeleteHorraire";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("horraireId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<HorraireDal> GetAll()
        {
            List<HorraireDal> lb = new List<HorraireDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Horraire";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            HorraireDal b = new HorraireDal();
                            b.horraireId = (int)dataReader["horraireId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.horraireDateDebut = (DateTime)dataReader["horraireDateDebut"];
                            b.horraireDateFin = (DateTime)dataReader["horraireDateFin"];
                            b.heureOuverture = (string)dataReader["heureOuverture"].ToString();
                            b.heureFermeture = (string)dataReader["heureFermeture"].ToString();
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public HorraireDal GetOne(int id)
        {
            HorraireDal b = new HorraireDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Horraire where horraireId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            b.horraireId = (int)dataReader["horraireId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.horraireDateDebut = (DateTime)dataReader["horraireDateDebut"];
                            b.horraireDateFin = (DateTime)dataReader["horraireDateFin"];
                            b.heureOuverture = (string)dataReader["heureOuverture"].ToString();
                            b.heureFermeture = (string)dataReader["heureFermeture"].ToString();
                            
                        }
                    }
                }
            }
            return b;
        }

        public void Update(HorraireDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditHorraire";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.horraireId), parametre.horraireId);
                    command.Parameters.AddWithValue(nameof(parametre.horraireDateDebut), parametre.horraireDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.horraireDateFin), parametre.horraireDateFin);
                    command.Parameters.AddWithValue(nameof(parametre.heureOuverture), parametre.heureOuverture);
                    command.Parameters.AddWithValue(nameof(parametre.heureFermeture), parametre.heureFermeture);
                    con.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
