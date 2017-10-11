using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            return new MotCle();
        }

        /// <summary>
        /// Inserer un MotCle.
        /// </summary>
        /// <param name="motCle">Objet MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererMotCle(MotCle motCle)
        {
            return true;
        }

        /// <summary>
        /// Modifier un MotCle.
        /// </summary>
        /// <param name="motCle">Objet MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierMotCle(MotCle motCle)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un MotCle.
        /// </summary>
        /// <param name="idMotCle">ID du MotCle</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerMotCle(int idMotCle)
        {
            return true;
        }

        MotCle IEntite<MotCle>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}