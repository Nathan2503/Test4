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
    public class RecompenseDalService : ServiceBase<RecompenseDalService>, IRepositories<int, RecompenseDal>
    {
        private string connectionString = @"";

        public int Create(RecompenseDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddRecompenseBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.recompenseNom), parametre.recompenseNom);
                    command.Parameters.AddWithValue(nameof(parametre.biereId), parametre.biereId);
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
                    command.CommandText = "DeleteRecompense";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("recompenseId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<RecompenseDal> GetAll()
        {
            List<RecompenseDal> lb = new List<RecompenseDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Recompense";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            RecompenseDal b = new RecompenseDal();
                            b.recompenseId = (int)dataReader["recompenseId"];
                            b.biereId = (int?)dataReader["biereId"];
                            b.recompenseNom = (string)dataReader["recompenseNom"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public RecompenseDal GetOne(int id)
        {
            RecompenseDal b = new RecompenseDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Recompense where recompenseId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            b.recompenseId = (int)dataReader["recompenseId"];
                            b.biereId = (int?)dataReader["biereId"];
                            b.recompenseNom = (string)dataReader["recompenseNom"];
                        }
                    }
                }
            }
            return b;
        }

        public void Update(RecompenseDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditRecompense";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.recompenseId), parametre.recompenseId);
                    command.Parameters.AddWithValue(nameof(parametre.recompenseNom), parametre.recompenseNom);
                    command.Parameters.AddWithValue(nameof(parametre.biereId), parametre.biereId);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
