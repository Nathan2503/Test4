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
    public class BrasserieDalService : ServiceBase<BrasserieDalService>, IBrasserie<BrasserieDal>
    {
        private string connectionString = @"";
        public BrasserieDal Get()
        {
            BrasserieDal brasserie = new BrasserieDal();
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "Select * from Brasserie";
                    con.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brasserie.brasserieId =(int)reader["brasserieId"];
                            brasserie.brasseriePresentation = (string)reader["brasseriePresentation"];
                            brasserie.mailInfon = (string)reader["mailInfon"];
                            brasserie.mailRecrutement = (string)reader["mailRecrutement"];
                            brasserie.nomBrasserie = (string)reader["nomBrasserie"];
                        }
                    }
                }
            }
            return brasserie;
        }

        public void Update(BrasserieDal parametre)
        {
            using (SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = connectionString;
                using (SqlCommand command = con.CreateCommand())
                {
                    command.CommandText = "EditBrasserie";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(parametre.brasserieId), parametre.brasserieId);
                    command.Parameters.AddWithValue(nameof(parametre.brasseriePresentation), parametre.brasseriePresentation);
                    command.Parameters.AddWithValue("mailIfon", parametre.mailInfon);
                    command.Parameters.AddWithValue(nameof(parametre.mailRecrutement), parametre.mailRecrutement);
                    command.Parameters.AddWithValue(nameof(parametre.nomBrasserie), parametre.nomBrasserie);
                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
