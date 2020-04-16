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
    public class MessageDalService : ServiceBase<MessageDalService>, IRepositories<int, MessageDal>
    {
        private string connectionString = @"";

        public int Create(MessageDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddMessageAlertBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.messageContenu), parametre.messageContenu);
                    command.Parameters.AddWithValue(nameof(parametre.messageDateDebut), parametre.messageDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.messageDateFin), parametre.messageDateFin);
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
                    command.CommandText = "DeletMessageAlert";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("messageALertId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<MessageDal> GetAll()
        {
            List<MessageDal> lb = new List<MessageDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from MessageAlert";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            MessageDal b = new MessageDal();
                            b.messageAlertId = (int)dataReader["messageAlertId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.messageDateDebut = (DateTime)dataReader["messageDateDebut"];
                            b.messageDateFin = (DateTime)dataReader["messageDateFin"];
                            b.messageContenu = (string)dataReader["messageContenu"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public MessageDal GetOne(int id)
        {
            MessageDal b = new MessageDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from MessageAlert where messageAlertId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            b.messageAlertId = (int)dataReader["messageAlertId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.messageDateDebut = (DateTime)dataReader["messageDateDebut"];
                            b.messageDateFin = (DateTime)dataReader["messageDateFin"];
                            b.messageContenu = (string)dataReader["messageContenu"];
                        }
                    }
                }
            }
            return b;
        }

        public void Update(MessageDal parametre)
        {
            using(SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditMessageAlert";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.messageAlertId), parametre.messageAlertId);
                    command.Parameters.AddWithValue(nameof(parametre.messageContenu), parametre.messageContenu);
                    command.Parameters.AddWithValue(nameof(parametre.messageDateDebut), parametre.messageDateDebut);
                    command.Parameters.AddWithValue(nameof(parametre.messageDateFin), parametre.messageDateFin);
                    con.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
