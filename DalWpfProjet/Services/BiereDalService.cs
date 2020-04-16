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
    public class BiereDalService : ServiceBase<BiereDalService> IBiere<int, BiereDal>
    {
        private string connectionString = @"";

        public void Activer(int id)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "ActiverBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("biereId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public int Create(BiereDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "AddBiereBis";
                    SqlParameter pid = new SqlParameter();
                    pid.ParameterName = "ID";
                    pid.Value = 0;
                    pid.Direction = System.Data.ParameterDirection.Output;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.biereDescription), parametre.biereDescription);
                    command.Parameters.AddWithValue(nameof(parametre.biereImage), parametre.biereImage);
                    command.Parameters.AddWithValue(nameof(parametre.biereNom), parametre.biereNom);
                    command.Parameters.AddWithValue(nameof(parametre.bierePrix), parametre.bierePrix);
                    command.Parameters.AddWithValue(nameof(parametre.pourcentageAlcool), parametre.pourcentageAlcool);
                    command.Parameters.AddWithValue(nameof(parametre.biereRobe), parametre.biereRobe);
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereId),parametre.typeBiereId);
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
                    command.CommandText = "deleteBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("biereId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Desactiver(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "DesactiverBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("biereId", id);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<BiereDal> GetAll()
        {
            List<BiereDal> lb = new List<BiereDal>();
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Biere";
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            BiereDal b = new BiereDal();
                            b.biereDescription = (string)dataReader["biereDescription"];
                            b.biereId = (int)dataReader["biereId"];
                            b.biereImage = (string)dataReader["biereImage"];
                            b.biereIsDispo = (bool)dataReader["biereIsDispo"];
                            b.biereNom = (string)dataReader["biereNom"];
                            b.bierePrix = (decimal)dataReader["bierePrix"];
                            b.biereRobe = (string)dataReader["biereRobe"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.pourcentageAlcool = (decimal)dataReader["pourcentageAlcool"];
                            if(dataReader["typeBiereId"] is DBNull)
                            {
                                b.typeBiereId = null;
                            }
                            else
                            {
                                b.typeBiereId = (int?)dataReader["typeBiereId"];
                            }
                            lb.Add(b);
                        }
                    }
                }
            }
            return lb;
        }

        public BiereDal GetOne(int id)
        {
            BiereDal b = new BiereDal();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Biere where biereId=@id";
                    command.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            b.biereDescription = (string)dataReader["biereDescription"];
                            b.biereId = (int)dataReader["biereId"];
                            b.biereImage = (string)dataReader["biereImage"];
                            b.biereIsDispo = (bool)dataReader["biereIsDispo"];
                            b.biereNom = (string)dataReader["biereNom"];
                            b.bierePrix = (decimal)dataReader["bierePrix"];
                            b.biereRobe = (string)dataReader["biereRobe"];
                            b.brasserieId = (int?)dataReader["brasserieId"];
                            b.pourcentageAlcool = (decimal)dataReader["pourcentageAlcool"];
                            if (dataReader["typeBiereId"] is DBNull)
                            {
                                b.typeBiereId = null;
                            }
                            else
                            {
                                b.typeBiereId = (int?)dataReader["typeBiereId"];
                            }
                        }
                    }
                }
            }
            return b;
        }

        public void Update(BiereDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditBiere";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.biereId), parametre.biereId);
                    command.Parameters.AddWithValue(nameof(parametre.biereDescription), parametre.biereDescription);
                    command.Parameters.AddWithValue(nameof(parametre.biereImage), parametre.biereImage);
                    command.Parameters.AddWithValue(nameof(parametre.biereNom), parametre.biereNom);
                    command.Parameters.AddWithValue(nameof(parametre.bierePrix), parametre.bierePrix);
                    command.Parameters.AddWithValue(nameof(parametre.pourcentageAlcool), parametre.pourcentageAlcool);
                    command.Parameters.AddWithValue(nameof(parametre.biereRobe), parametre.biereRobe);
                    command.Parameters.AddWithValue(nameof(parametre.typeBiereId), parametre.typeBiereId);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
