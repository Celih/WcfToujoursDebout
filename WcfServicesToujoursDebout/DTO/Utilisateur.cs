﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.Utilitaire;

namespace WcfServicesToujoursDebout
{
    public class Utilisateur : IEntite<Utilisateur>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Utilisateur()
        {
            Id = 0;
            Nom = string.Empty;
            Prenom = string.Empty;
            AdresseMail = string.Empty;
            Pseudo = string.Empty;
            IdPhoto = 0;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        public Utilisateur(Utilisateur user)
        {
            Id = user.Id;
            Nom = user.Nom;
            Prenom = user.Prenom;
            AdresseMail = user.AdresseMail;
            Pseudo = user.Pseudo;
            IdPhoto = user.IdPhoto;
            IdUserCreation = user.IdUserCreation;
            UserCreation_Libelle = user.UserCreation_Libelle;
            DateCreation = user.DateCreation;
            IdUserModification = user.IdUserModification;
            UserModification_Libelle = user.UserModification_Libelle;
            DateModification = user.DateModification;
        }

        #region Données Utilsateur

        /// <summary>
        /// Id de l'utilisateur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de l'utilisateur.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Adresse mail de l'utilisateur.
        /// </summary>
        public string AdresseMail { get; set; }

        /// <summary>
        /// Pseudo de l'utilisateur.
        /// </summary>
        public string Pseudo { get; set; }

        /// <summary>
        /// Id de la photo.
        /// </summary>
        public int IdPhoto { get; set; }

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
        /// Recupere l'utilisateur.
        /// </summary>
        /// <param name="idUtilisateur">ID de l'utilisateur</param>
        /// <returns>Données de l'utilisateur</returns>
        internal static Utilisateur RecupererUtilisateur(int idUtilisateur)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur)
            };

            return procedure.Execute<Utilisateur>(ListProcedure.RecupererUtilisateur, sqlParam);
        }

        /// <summary>
        /// Inserer un utilisateur.
        /// </summary>
        /// <param name="user">Objet utilisateur</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererUtilisateur(Utilisateur user)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Nom", user.Nom),
                new SqlParameter("@Prenom", user.Prenom),
                new SqlParameter("@AdresseMail", user.AdresseMail),
                new SqlParameter("@Pseudo", user.Pseudo),
                new SqlParameter("@IdPhoto", user.IdPhoto),
                new SqlParameter("@User_Creation", user.IdUserCreation),
            };

            procedure.Execute<Utilisateur>(ListProcedure.InsererUtilisateur, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un utilisateur.
        /// </summary>
        /// <param name="user">Objet utilisateur</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierUtilisateur(Utilisateur user)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Prenom", user.Prenom),
                new SqlParameter("@AdresseMail", user.AdresseMail),
                new SqlParameter("@Pseudo", user.Pseudo),
                new SqlParameter("@IdPhoto", user.IdPhoto),
                new SqlParameter("@User_Modification", user.IdUserModification),
            };

            procedure.Execute<Utilisateur>(ListProcedure.ModifierUtilisateur, sqlParam);

            return true;
        }

        /// <summary>
        /// Supprimer un utilisateur.
        /// </summary>
        /// <param name="idUtilisateur">ID de l'utilisateur</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerUtilisateur(int idUtilisateur)
        {
            return true;
        }

        Utilisateur IEntite<Utilisateur>.Remplire(SqlDataReader data)
        {
            data.Read();
            IDataRecord record = data;
            Utilisateur user = new Utilisateur();

            user.Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"];
            user.Nom = (string)record["Nom"];
            user.Prenom = (string)record["Prenom"];
            user.AdresseMail = (string)record["AdresseMail"];
            user.Pseudo = (string)record["Pseudo"];
            user.IdPhoto = string.IsNullOrEmpty(Convert.ToString(record["IdPhoto"])) ? -1 : (int)record["IdPhoto"];
            user.IdUserCreation = (int)record["User_Creation"];
            user.UserCreation_Libelle = string.Empty;
            user.DateCreation = (DateTime)record["Date_Creation"];
            user.IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["IdPhoto"])) ? -1 : (int)record["User_Modification"];
            user.UserModification_Libelle = string.Empty;
            user.DateModification = (DateTime)record["Date_Modification"];

            return user;
        }

        #endregion
    }
}