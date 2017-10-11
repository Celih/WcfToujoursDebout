using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            return new Publication();
        }

        /// <summary>
        /// Inserer un Publication.
        /// </summary>
        /// <param name="publication">Objet Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererPublication(Publication publication)
        {
            return true;
        }

        /// <summary>
        /// Modifier un Publication.
        /// </summary>
        /// <param name="publication">Objet Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierPublication(Publication publication)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un Publication.
        /// </summary>
        /// <param name="idPublication">ID de la Publication</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerPublication(int idPublication)
        {
            return true;
        }

        Publication IEntite<Publication>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}