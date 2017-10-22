using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.DTO;
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
        public int? IdPhoto { get; set; }

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

        private string password { get; set; }
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

            return procedure.Execute<Utilisateur>(ListProcedure.RecupererUtilisateur, sqlParam)[0];
        }

        internal static List<Evenement> GetListEvenement (int idUtilisateur)
        {
            List<Evenement> listEvenement = new List<Evenement>();

            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur)
            };

            List<Particite> listParticipe = new List<Particite>();
            listParticipe = procedure.Execute<Particite>(ListProcedure.RecupererListeEvenement, sqlParam);

            for (int i = 0; i < listParticipe.Count; i++)
            {
                procedure = new Procedure();
                sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idEvenement", listParticipe[i].IdEvenement)
            };

                listEvenement.Add(procedure.Execute<Evenement>(ListProcedure.RecupererEvenement, sqlParam)[0]);
                listEvenement[listEvenement.Count - 1].Statut = listParticipe[i].Statut;
            }

            return listEvenement;
        }

        internal static List<Tag> GetListTag(int idUtilisateur)
        {
            List<Tag> listTag = new List<Tag>();

            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur)
            };

            List<EstAbonne> listEstAbonne = new List<EstAbonne>();
            listEstAbonne = procedure.Execute<EstAbonne>(ListProcedure.RecupererListeTag, sqlParam);

            for (int i = 0; i < listEstAbonne.Count; i++)
            {
                procedure = new Procedure();
                sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idTag", listEstAbonne[i].IdTag)
            };

                listTag.Add(procedure.Execute<Tag>(ListProcedure.RecupererTag, sqlParam)[0]);
            }

            return listTag;
        }

        /// <summary>
        /// Inserer un utilisateur.
        /// </summary>
        /// <param name="user">Objet utilisateur</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererUtilisateur(Utilisateur user)
        {
            Procedure procedure = new Procedure();

            //user.IdPhoto = user.IdPhoto != 0 ? user.IdPhoto : null; 

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
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerUtilisateur, sqlParam);

            return true;
        }

        internal static bool UtilisateurParticipeEven(int idUtilisateur, int idEvenemenet, string statut)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur),
                new SqlParameter("@idEvenemenet", idEvenemenet),
                new SqlParameter("@statut", statut),
            };

            procedure.Execute<Utilisateur>(ListProcedure.UtilisateurParticipeEven, sqlParam);
            return true;
        }

        internal static List<News> GetListNews(int idUtilisateur, string recherche)
        {
            List<News> listNews = new List<News>();

            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur),
                new SqlParameter("@recherche", recherche)
            };

            listNews = procedure.Execute<News>(ListProcedure.RecupererListeNews, sqlParam);



            return listNews;
        }

        internal static bool ParticipationEvenement(int idUtilisateur, int idEvenement)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur),
                new SqlParameter("@idEvenement", idEvenement)
            };

            List<Particite> a = procedure.Execute<Particite>(ListProcedure.ParticipeUtilisateur, sqlParam);
            bool b = false;
            if (a.Count > 0)
            {
                b = true;
            }
            return b;
        }

        internal static bool Connection(string mail, string pseudo, string passward)
        {
            bool connection = false;

            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@mail", mail),
                new SqlParameter("@pseudo", pseudo)
            };

            List<Utilisateur> a = procedure.Execute<Utilisateur>(ListProcedure.Connection, sqlParam);
            foreach (var item in a)
            {
                if (item.password == passward)
                {
                    connection = true;
                }
            }

            return connection;
        }

        List<Utilisateur> IEntite<Utilisateur>.Remplire(SqlDataReader data)
        {
            List<Utilisateur> listUser = new List<Utilisateur>();
            while (data.Read())
            {
                IDataRecord record = data;
                Utilisateur user = new Utilisateur
                {
                    Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"],
                    Nom = (string)record["Nom"],
                    Prenom = (string)record["Prenom"],
                    AdresseMail = (string)record["AdresseMail"],
                    Pseudo = (string)record["Pseudo"],
                    IdPhoto = string.IsNullOrEmpty(Convert.ToString(record["IdPhoto"])) ? -1 : (int)record["IdPhoto"],
                    IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"],
                    UserCreation_Libelle = string.Empty,
                    DateCreation = (DateTime)record["Date_Creation"],
                    IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"],
                    UserModification_Libelle = string.Empty,
                    DateModification = (DateTime)record["Date_Modification"],
                    password = (string)record["Password"]
                };
                listUser.Add(user);
            }

            return listUser;
        }

        #endregion
    }
}