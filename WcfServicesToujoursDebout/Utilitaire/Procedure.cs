using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WcfServicesToujoursDebout.Constante;

namespace WcfServicesToujoursDebout.Utilitaire
{
    public class Procedure
    {
        const string StringConnection = "Data Source=DESKTOP-LCTLVSO;Integrated Security=False;User ID=Connection1;Password=test ;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Procedure()
        { }

        /// <summary>
        /// Execute la requete.
        /// </summary>
        /// <typeparam name="T">Type de l'objet</typeparam>
        /// <param name="procedureNom">Nom de la requete</param>
        /// <param name="listParameterSql">Liste des parametres</param>
        /// <returns></returns>
        public List<T> Execute<T>(string procedureNom, List<SqlParameter> listParameterSql) where T : IEntite<T>, new()
        {
            List<T> objet = new List<T>();

            try
            {
                SqlConnection connection = new SqlConnection(StringConnection);
                SqlCommand command = new SqlCommand
                {
                    CommandText = procedureNom,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                foreach (var parameter in listParameterSql)
                {
                    command.Parameters.Add(parameter);
                }

                connection.Open();
                SqlDataReader data = command.ExecuteReader();
                if (data.HasRows)
                {
                    objet.AddRange(new T().Remplire(data));
                }
            }
            catch (SqlException e)
            {
                throw new FaultException(e.Errors[0].Message);
            }
            return objet;
        }

        public void Execute(string procedureNom, List<SqlParameter> listParameterSql)
        {
            try
            {
                SqlConnection connection = new SqlConnection(StringConnection);
                SqlCommand command = new SqlCommand
                {
                    CommandText = procedureNom,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                foreach (var parameter in listParameterSql)
                {
                    command.Parameters.Add(parameter);
                }

                connection.Open();
                SqlDataReader data = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                throw new FaultException(e.Errors[0].Message);
            }
        }


    }
}