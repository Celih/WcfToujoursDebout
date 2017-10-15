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
    public class Publication : IEntite<Publication>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Publication()
        {
            Id = 0;
            IdEvenement = 0;
            Texte = string.Empty;
            IdUtilisateur = 0;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données Publication

        /// <summary>
        /// Id de la publication.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id de l'évenement.
        /// </summary>
        public int IdEvenement { get; set; }

        /// <summary>
        /// Texte de l'évenement.
        /// </summary>
        public string Texte { get; set; }

        /// <summary>
        /// Id de l'utilisateuur.
        /// </summary>
        public int IdUtilisateur { get; set; }

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
        /// Recupere l'Publication.
        /// </summary>
        /// <param name="idPublication">ID de la Publication</param>
        /// <returns>Données de la Publication</returns>
        internal static Publication RecupererPublication(int idPublication)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idPublication)
            };

            return procedure.Execute<Publication>(ListProcedure.RecupererPublication, sqlParam);
        }

        /// <summary>
        /// Inserer un Publication.
        /// </summary>
        /// <param name="publication">Objet Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererPublication(Publication publication)
        {
            Procedure procedure = new Procedure();

            //user.IdPhoto = user.IdPhoto != 0 ? user.IdPhoto : null; 

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Nom", publication.Texte)
            };

            procedure.Execute<Publication>(ListProcedure.InsererPublication, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un Publication.
        /// </summary>
        /// <param name="publication">Objet Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierPublication(Publication publication)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", publication.Id),
            };

            procedure.Execute<Publication>(ListProcedure.ModifierPublication, sqlParam);

            return true;
        }

        /// <summary>
        /// Supprimer un Publication.
        /// </summary>
        /// <param name="idPublication">ID de la Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerPublication(int idPublication)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idPublication),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerPublication, sqlParam);
            return true;
        }

        Publication IEntite<Publication>.Remplire(SqlDataReader data)
        {
            data.Read();
            IDataRecord record = data;
            Publication publication = new Publication();

            publication.Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"];
            publication.IdEvenement = string.IsNullOrEmpty(Convert.ToString(record["IdEvenement"])) ? -1 : (int)record["IdEvenement"];
            publication.Texte = (string)record["Texte"];
            publication.IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"];
            publication.UserCreation_Libelle = string.Empty;
            publication.DateCreation = (DateTime)record["Date_Creation"];
            publication.IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"];
            publication.UserModification_Libelle = string.Empty;
            publication.DateModification = (DateTime)record["Date_Modification"];

            return publication;
        }



        #endregion
    }
}