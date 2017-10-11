using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Classe;

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
            return new Commentaire();
        }

        /// <summary>
        /// Inserer un Commentaire.
        /// </summary>
        /// <param name="commentaire">Objet Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererCommentaire(Commentaire commentaire)
        {
            return true;
        }

        /// <summary>
        /// Modifier un Commentaire.
        /// </summary>
        /// <param name="commentaire">Objet Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierCommentaire(Commentaire commentaire)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un Commentaire.
        /// </summary>
        /// <param name="idCommentaire">ID du Commentaire</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerCommentaire(int idCommentaire)
        {
            return true;
        }

        Commentaire IEntite<Commentaire>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}