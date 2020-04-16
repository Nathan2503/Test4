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
    public class TypeBiereDalService : ServiceBase<TypeBiereDalService>, IRepositories<int, TypeBiereDal>
    {
        private string connectionString = @"";

        public int Create(TypeBiereDal parametre)
        {
            using(SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddTypeBiereBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereNom), parametre.typeBiereNom);
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereDefinition), parametre.typeBiereDefinition);
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
                    command.CommandText = "DeleteTypeBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("typeBiereId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<TypeBiereDal> GetAll()
        {
            List<TypeBiereDal> lb = new List<TypeBiereDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from TypeBiere";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            TypeBiereDal b = new TypeBiereDal();
                            b.typeBiereId = (int)dataReader["typeBiereId"];
                            b.typeBiereDefinition = (string)dataReader["typeBiereDefinition"];
                            b.typeBiereNom = (string)dataReader["typeBiereNom"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public TypeBiereDal GetOne(int id)
        {
            TypeBiereDal b = new TypeBiereDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from TypeBiere where typeBiereId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            
                            b.typeBiereId = (int)dataReader["typeBiereId"];
                            b.typeBiereDefinition = (string)dataReader["typeBiereDefinition"];
                            b.typeBiereNom = (string)dataReader["typeBiereNom"];
                        }
                    }
                }
            }
            return b;
        }

        public void Update(TypeBiereDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditTypeBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereId), parametre.typeBiereId);
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereNom), parametre.typeBiereNom);
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereDefinition), parametre.typeBiereDefinition);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
