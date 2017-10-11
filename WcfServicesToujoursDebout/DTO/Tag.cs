﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            return new Tag();
        }

        /// <summary>
        /// Inserer un Tag.
        /// </summary>
        /// <param name="tag">Objet Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererTag(Tag tag)
        {
            return true;
        }

        /// <summary>
        /// Modifier un Tag.
        /// </summary>
        /// <param name="tag">Objet Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierTag(Tag tag)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un Tag.
        /// </summary>
        /// <param name="idTag">ID du Tag</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerTag(int idTag)
        {
            return true;
        }

        Tag IEntite<Tag>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}