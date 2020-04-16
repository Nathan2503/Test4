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
    public class CommandeDalService : ServiceBase<CommandeDalService>, IRepositories<int, CommandeDal>
    {
        private string connectionString = @"";

        public int Create(CommandeDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddCommandBis2";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.biereId), parametre.biereId);
                    command.Parameters.AddWithValue(nameof(parametre.clientId), parametre.clientId);
                    command.Parameters.AddWithValue(nameof(parametre.commandeDate), parametre.commandeDate);
                    command.Parameters.AddWithValue(nameof(parametre.commandeQuantite), parametre.commandeQuantite);
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
                    command.CommandText = "DeleteCommande";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("commandeId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<CommandeDal> GetAll()
        {
            List<CommandeDal> lb = new List<CommandeDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Commande";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            CommandeDal b = new CommandeDal();
                            if(dataReader["biereId"] is DBNull)
                            {
                                b.biereId = null;
                            }
                            else
                            {
                                b.biereId = (int?)dataReader["biereId"];
                            }
                           if(dataReader["clientId"] is DBNull)
                            {
                                b.clientId = null;
                            }
                            else
                            {
                                b.clientId = (int?)dataReader["clientId"];
                            }
                            b.commandeDate = (DateTime)dataReader["commandeDate"];
                            b.commandeQuantite = (int)dataReader["commandeQuantite"];
                            b.commandeId = (int)dataReader["commandeId"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public CommandeDal GetOne(int id)
        {
            CommandeDal b = new CommandeDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Commande where commandeId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            
                            if (dataReader["biereId"] is DBNull)
                            {
                                b.biereId = null;
                            }
                            else
                            {
                                b.biereId = (int?)dataReader["biereId"];
                            }
                            if (dataReader["clientId"] is DBNull)
                            {
                                b.clientId = null;
                            }
                            else
                            {
                                b.clientId = (int?)dataReader["clientId"];
                            }
                            b.commandeDate = (DateTime)dataReader["commandeDate"];
                            b.commandeQuantite = (int)dataReader["commandeQuantite"];
                            b.commandeId = (int)dataReader["commandeId"];
                        }
                    }
                }
            }
            return b;
        }

        public void Update(CommandeDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditCommande";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.commandeId), parametre.commandeId);
                    command.Parameters.AddWithValue(nameof(parametre.commandeQuantite), parametre.commandeQuantite);
                    command.Parameters.AddWithValue(nameof(parametre.biereId), parametre.biereId);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
