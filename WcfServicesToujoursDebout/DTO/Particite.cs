using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout.DTO
{
    public class Particite : IEntite<Particite>
    {
        public int IdEvenement { get; set; }

        public int IdUtilisateur { get; set; }

        public string Statut { get; set; }

        public List<Particite> Remplire(SqlDataReader data)
        {
            List<Particite> listParticipe = new List<Particite>();
            while (data.Read())
            {
                IDataRecord record = data;
                Particite participe = new Particite
                {
                    IdEvenement = string.IsNullOrEmpty(Convert.ToString(record["IdEvenement"])) ? -1 : (int)record["IdEvenement"],
                    IdUtilisateur = string.IsNullOrEmpty(Convert.ToString(record["IdUtilisateur"])) ? -1 : (int)record["IdUtilisateur"],
                    Statut = (string)record["Statut"]
                };
                listParticipe.Add(participe);
            }
            return listParticipe;
        }
    }




}