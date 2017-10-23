using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.Utilitaire;

namespace WcfServicesToujoursDebout
{
    public class Tag : IEntite<Tag>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Tag()
        {
            Id = 0;
            Libelle = string.Empty;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données Tag

        /// <summary>
        /// Id du tag.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Libelle du tag.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Id du User de creation.
        /// </summary>
        public int IdUserCreation { get; set; }

        /// <summary>
        /// Libelle du user de création (Prénom + Nom)
        /// </summary>
        public string UserCreation_Libelle { get; set; }

        /// <summary>
        /// Date de création.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Id du user de modification.
        /// </summary>
        public int IdUserModification { get; set; }

        /// <summary>
        /// Libelle du user de modification (Prénom + Nom).
        /// </summary>
        public string UserModification_Libelle { get; set; }

        /// <summary>
        /// Date de modification.
        /// </summary>
        public DateTime DateModification { get; set; }

        #endregion

        #region Méthode interne
        /// <summary>
        /// Recupere l'Tag.
        /// </summary>
        /// <param name="idTag">ID du Tag</param>
        /// <returns>Données de l'Tag</returns>
        internal static Tag RecupererTag(int idTag)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idTag)
            };

            return procedure.Execute<Tag>(ListProcedure.RecupererTag, sqlParam)[0];
        }

        internal static List<Tag> RecupererNewTag(int idUtilisateur)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserer un Tag.
        /// </summary>
        /// <param name="tag">Objet Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererTag(Tag tag)
        {
            Procedure procedure = new Procedure();

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Libelle", tag.Libelle),
                new SqlParameter("@User_Creation", tag.IdUserCreation)
            };

            procedure.Execute<Utilisateur>(ListProcedure.InsererTag, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un Tag.
        /// </summary>
        /// <param name="tag">Objet Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierTag(Tag tag)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", tag.Id),
                new SqlParameter("@Libelle", tag.Libelle),
                new SqlParameter("@User_Modification", tag.IdUserCreation),
            };

            procedure.Execute<Tag>(ListProcedure.ModifierTag, sqlParam);

            return true;
        }

        /// <summary>
        /// Supprimer un Tag.
        /// </summary>
        /// <param name="idTag">ID du Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerTag(int idTag)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idTag", idTag),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerTag, sqlParam);

            return true;
        }

        internal static List<Tag> GetListTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                tag = "%";
            }
            else
            {
                tag = string.Format("%{0}%", tag);
            }
            List<Tag> a = new List<Tag>();
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@tag", tag),
            };

            return procedure.Execute<Tag>(ListProcedure.GetListTagTag, sqlParam);
        }

        List<Tag> IEntite<Tag>.Remplire(SqlDataReader data)
        {
            List<Tag> listTag = new List<Tag>();
            while (data.Read())
            {
                IDataRecord record = data;
                Tag tag = new Tag
                {
                    Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"],
                    Libelle = (string)record["Libelle"],
                    IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"],
                    UserCreation_Libelle = string.Empty,
                    DateCreation = (DateTime)record["Date_Creation"],
                    IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"],
                    UserModification_Libelle = string.Empty,
                    DateModification = (DateTime)record["Date_Modification"]
                };
                listTag.Add(tag);
            }

            return listTag;
        }





        #endregion
    }
}