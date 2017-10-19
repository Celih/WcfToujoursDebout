using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Classe;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.Utilitaire;

namespace WcfServicesToujoursDebout.DTO
{
    public class Commentaire : IEntite<Commentaire>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Commentaire()
        {
            Id = 0;
            Texte = string.Empty;
            IdPere = 0;
            TypeCommentaire = null;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données Commentaire

        /// <summary>
        /// Id du commentaire.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Texte du Commentaire.
        /// </summary>
        public string Texte { get; set; }

        /// <summary>
        /// Id du père.
        /// </summary>
        public int IdPere { get; set; }

        /// <summary>
        /// Type de commentaire.
        /// </summary>
        public TypeCommentaire TypeCommentaire { get; set; }

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
        /// Recupere l'Commentaire.
        /// </summary>
        /// <param name="idCommentaire">ID du Commentaire</param>
        /// <returns>Données du Commentaire</returns>
        internal static Commentaire RecupererCommentaire(int idCommentaire)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idCommentaire)
            };

            return procedure.Execute<Commentaire>(ListProcedure.RecupererCommentaire, sqlParam)[0];
        }

        /// <summary>
        /// Inserer un Commentaire.
        /// </summary>
        /// <param name="commentaire">Objet Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererCommentaire(Commentaire commentaire)
        {
            Procedure procedure = new Procedure();

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Texte", commentaire.Texte),
                new SqlParameter("@idPere", commentaire.IdPere),
                new SqlParameter("@Type", commentaire.TypeCommentaire),
                new SqlParameter("@User_Creation", commentaire.IdUserCreation)
            };

            procedure.Execute<Commentaire>(ListProcedure.InsererCommentaire, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un Commentaire.
        /// </summary>
        /// <param name="commentaire">Objet Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierCommentaire(Commentaire commentaire)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", commentaire.Id),
                new SqlParameter("@Texte", commentaire.Texte),
                new SqlParameter("@User_Modification", commentaire.IdUserModification),
            };

            procedure.Execute<Commentaire>(ListProcedure.ModifierCommentaire, sqlParam);

            return true;
        }

        /// <summary>
        /// Supprimer un Commentaire.
        /// </summary>
        /// <param name="idCommentaire">ID du Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerCommentaire(int idCommentaire)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idCommenatire", idCommentaire),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerCommentaire, sqlParam);

            return true;
        }

        List<Commentaire> IEntite<Commentaire>.Remplire(SqlDataReader data)
        {
            List<Commentaire> listCommentaire = new List<Commentaire>();
            while (data.Read())
            {
                IDataRecord record = data;
                Commentaire commentaire = new Commentaire
                {
                    Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"],
                    Texte = (string)record["Texte"],
                    IdPere = string.IsNullOrEmpty(Convert.ToString(record["IdPere"])) ? -1 : (int)record["IdPere"],
                    TypeCommentaire = (TypeCommentaire)record["TypeCommentaire"],
                    IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"],
                    UserCreation_Libelle = string.Empty,
                    DateCreation = (DateTime)record["Date_Creation"],
                    IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"],
                    UserModification_Libelle = string.Empty,
                    DateModification = (DateTime)record["Date_Modification"]
                };
                listCommentaire.Add(commentaire);
            }

            return listCommentaire;
        }



        #endregion
    }
}