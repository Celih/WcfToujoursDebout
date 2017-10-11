using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout
{
    public class FAQ : IEntite<FAQ>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public FAQ()
        {
            Id = 0;
            Titre = string.Empty;
            Texte = string.Empty;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données FAQ

        /// <summary>
        /// Id de la FAQ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de la FAQ.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Texte de la FAQ.
        /// </summary>
        public string Texte { get; set; }

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
        /// Recupere l'FAQ.
        /// </summary>
        /// <param name="idFAQ">ID de la FAQ</param>
        /// <returns>Données de la FAQ</returns>
        internal static FAQ RecupererFAQ(int idFAQ)
        {
            return new FAQ();
        }

        /// <summary>
        /// Inserer un FAQ.
        /// </summary>
        /// <param name="faq">Objet FAQ</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererFAQ(FAQ faq)
        {
            return true;
        }

        /// <summary>
        /// Modifier un FAQ.
        /// </summary>
        /// <param name="faq">Objet FAQ</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierFAQ(FAQ faq)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un FAQ.
        /// </summary>
        /// <param name="idFAQ">ID de la FAQ</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerFAQ(int idFAQ)
        {
            return true;
        }

        FAQ IEntite<FAQ>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}