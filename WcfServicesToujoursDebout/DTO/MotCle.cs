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
    public class MotCle : IEntite<MotCle>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public MotCle()
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

        #region Données Mot clé

        /// <summary>
        /// Id du mot clé.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Libelle du mot clé.
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
        /// Recupere l'MotCle.
        /// </summary>
        /// <param name="idMotCle">ID du MotCle</param>
        /// <returns>Données du MotCle</returns>
        internal static MotCle RecupererMotCle(int idMotCle)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idMotCle", idMotCle)
            };

            return procedure.Execute<MotCle>(ListProcedure.RecupererMotCle, sqlParam);
        }

        /// <summary>
        /// Inserer un MotCle.
        /// </summary>
        /// <param name="motCle">Objet MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererMotCle(MotCle motCle)
        {
            Procedure procedure = new Procedure();

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Libelle", motCle.Libelle),
                new SqlParameter("@User_Creation", motCle.IdUserCreation)
            };

            procedure.Execute<MotCle>(ListProcedure.InsererMotCle, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un MotCle.
        /// </summary>
        /// <param name="motCle">Objet MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierMotCle(MotCle motCle)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", motCle.Id),
                new SqlParameter("@Libelle", motCle.Libelle),
                new SqlParameter("@User_Modification", motCle.IdUserModification),
            };

            procedure.Execute<MotCle>(ListProcedure.ModifierMotCle, sqlParam);
            return true;
        }

        /// <summary>
        /// Supprimer un MotCle.
        /// </summary>
        /// <param name="idMotCle">ID du MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerMotCle(int idMotCle)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idMotCle", idMotCle),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerMotCle, sqlParam);

            return true;
        }

        MotCle IEntite<MotCle>.Remplire(SqlDataReader data)
        {
            data.Read();
            IDataRecord record = data;
            MotCle motcle = new MotCle();

            motcle.Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"];
            motcle.Libelle = (string)record["Libelle"];
            motcle.IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"];
            motcle.UserCreation_Libelle = string.Empty;
            motcle.DateCreation = (DateTime)record["Date_Creation"];
            motcle.IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"];
            motcle.UserModification_Libelle = string.Empty;
            motcle.DateModification = (DateTime)record["Date_Modification"];

            return motcle;
        }



        #endregion
    }
}