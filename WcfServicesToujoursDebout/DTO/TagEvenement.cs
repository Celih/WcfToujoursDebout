using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout.DTO
{
    public class TagEvenement : IEntite<TagEvenement>
    {
        public int IdEvenement { get; set; }

        public int IdTag { get; set; }

        public List<TagEvenement> Remplire(SqlDataReader data)
        {
            List<TagEvenement> listEstAbonne = new List<TagEvenement>();
            while (data.Read())
            {
                IDataRecord record = data;
                TagEvenement estAbonne = new TagEvenement
                {
                    IdEvenement = string.IsNullOrEmpty(Convert.ToString(record["IdEvenemenet"])) ? -1 : (int)record["IdEvenemenet"],
                    IdTag = string.IsNullOrEmpty(Convert.ToString(record["IdTag"])) ? -1 : (int)record["IdTag"]
                };
                listEstAbonne.Add(estAbonne);
            }
            return listEstAbonne;

        }
    }
}