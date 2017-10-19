using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout.DTO
{
    public class EstAbonne : IEntite<EstAbonne>
    {
        public int IdUtilisateur { get; set; }

        public int IdTag { get; set; }

        public List<EstAbonne> Remplire(SqlDataReader data)
        {
            List<EstAbonne> listEstAbonne = new List<EstAbonne>();
            while (data.Read())
            {
                IDataRecord record = data;
                EstAbonne estAbonne = new EstAbonne
                {
                    IdUtilisateur = string.IsNullOrEmpty(Convert.ToString(record["IdUtilisateur"])) ? -1 : (int)record["IdUtilisateur"],
                    IdTag = string.IsNullOrEmpty(Convert.ToString(record["IdTag"])) ? -1 : (int)record["IdTag"]
                };
                listEstAbonne.Add(estAbonne);
            }
            return listEstAbonne;
        }
    }
}