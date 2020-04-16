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
    public class ClientDalService : ServiceBase<ClientDalService>, IClient<int, ClientDal>
    {
        private string connectionString = @"";

        public int Create(ClientDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddClientBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.clientDateNaissance), parametre.clientDateNaissance);
                    command.Parameters.AddWithValue(nameof(parametre.clientLogin), parametre.clientLogin);
                    command.Parameters.AddWithValue(nameof(parametre.clientNom), parametre.clientNom);
                    command.Parameters.AddWithValue(nameof(parametre.clientPrenom), parametre.clientPrenom);
                    command.Parameters.AddWithValue(nameof(parametre.clientPwd).ToLower(),parametre.clientPwd);
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
                    command.CommandText = "DeleteClient";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("clientId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ClientDal> GetAll()
        {
            List<ClientDal> lb = new List<ClientDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Client";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ClientDal b = new ClientDal();
                            b.clientLogin = (string)dataReader["clientLogin"];
                            b.clientId = (int)dataReader["clientId"];
                            b.clientNom = (string)dataReader["clientNom"];
                            b.clientDateNaissance = (DateTime)dataReader["clientDateNaissance"];
                            b.clientPrenom = (string)dataReader["clientPrenom"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public ClientDal GetOne(int id)
        {
            ClientDal b = new ClientDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Client where clientId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            b.clientLogin = (string)dataReader["clientLogin"];
                            b.clientId = (int)dataReader["clientId"];
                            b.clientNom = (string)dataReader["clientNom"];
                            b.clientDateNaissance = (DateTime)dataReader["clientDateNaissance"];
                            b.clientPrenom = (string)dataReader["clientPrenom"];
                           // b.clientPwd = (string)dataReader["clientpwd"];
                            //lb.Add(b);
                        }
                    }
                }
            }
            return b;
        }
    }
}
