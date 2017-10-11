using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout
{
    public class Evenement : IEntite<Evenement>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Evenement()
        {
            Id = 0;
            Titre = string.Empty;
            Adresse = string.Empty;
            DateFmtDateTime = new DateTime();
            Description = string.Empty;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données Evenement

        /// <summary>
        /// Id de l'évenement.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de l'évenement.
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Adresse de l'évenement.
        /// </summary>
        public string Adresse { get; set; }

        /// <summary>
        /// Date de l'évenement (Format DateTime).
        /// </summary>
        public DateTime DateFmtDateTime { get; set; }

        /// <summary>
        /// Date de l'évenement (Format String).
        /// </summary>
        public string Date
        {
            get
            {
                if (DateFmtDateTime != DateTime.MinValue)
                {
                    return DateFmtDateTime.Date.ToString();
                }
                return string.Empty;
            }
            set
            { }
        }

        /// <summary>
        /// Heure de l'évenement (Format String).
        /// </summary>
        public string Heure
        {
            get
            {
                if (DateFmtDateTime != DateTime.MinValue)
                {
                    return DateFmtDateTime.TimeOfDay.ToString();
                }
                return string.Empty;
            }
            set
            { }
        }

        /// <summary>
        /// Description de l'évenement.
        /// </summary>
        public string Description { get; set; }

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
        /// Recupere l'Evenement.
        /// </summary>
        /// <param name="idEvenement">ID de l'Evenement</param>
        /// <returns>Données de l'Evenement</returns>
        internal static Evenement RecupererEvenement(int idEvenement)
        {
            return new Evenement();
        }

        /// <summary>
        /// Inserer un Evenement.
        /// </summary>
        /// <param name="evenement">Objet Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererEvenement(Evenement evenement)
        {
            return true;
        }

        /// <summary>
        /// Modifier un Evenement.
        /// </summary>
        /// <param name="evenement">Objet Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierEvenement(Evenement evenement)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un Evenement.
        /// </summary>
        /// <param name="idEvenement">ID de l'Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerEvenement(int idEvenement)
        {
            return true;
        }

        Evenement IEntite<Evenement>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}