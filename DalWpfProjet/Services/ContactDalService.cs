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
    public class ContactDalService : ServiceBase<ContactDalService>, IRepositories<int, ContactDal>
    {
        private string connectionString = @"";

        public int Create(ContactDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddContactBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.adCodePostal), parametre.adCodePostal);
                    command.Parameters.AddWithValue(nameof(parametre.adNumero), parametre.adNumero);
                    command.Parameters.AddWithValue(nameof(parametre.adRue), parametre.adRue);
                    command.Parameters.AddWithValue(nameof(parametre.adVille), parametre.adVille);
                    command.Parameters.AddWithValue(nameof(parametre.telephone), parametre.telephone);
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
                using(SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "deleteContact";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("contactId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ContactDal> GetAll()
        {
            List<ContactDal> lb = new List<ContactDal>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Contact";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ContactDal b = new ContactDal();
                            b.contactId = (int)dataReader["contactId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.adCodePostal = (string)dataReader["adCodePostal"];
                            b.adNumero = (string)dataReader["adNumero"];
                            b.adRue = (string)dataReader["adRue"];
                            b.adVille = (string)dataReader["adVille"];
                            b.telephone = (string)dataReader["telephone"];
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public ContactDal GetOne(int id)
        {
            ContactDal b = new ContactDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Contact where contactId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            
                            b.contactId = (int)dataReader["contactId"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.adCodePostal = (string)dataReader["adCodePostal"];
                            b.adNumero = (string)dataReader["adNumero"];
                            b.adRue = (string)dataReader["adRue"];
                            b.adVille = (string)dataReader["adVille"];
                            b.telephone = (string)dataReader["telephone"];
                        }
                    }
                }
            }
            return b;
        }

        public void Update(ContactDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditContact";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.contactId), parametre.contactId);
                    command.Parameters.AddWithValue(nameof(parametre.adCodePostal), parametre.adCodePostal);
                    command.Parameters.AddWithValue(nameof(parametre.adNumero), parametre.adNumero);
                    command.Parameters.AddWithValue(nameof(parametre.adRue), parametre.adRue);
                    command.Parameters.AddWithValue(nameof(parametre.adVille), parametre.adVille);
                    command.Parameters.AddWithValue(nameof(parametre.telephone), parametre.telephone);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
