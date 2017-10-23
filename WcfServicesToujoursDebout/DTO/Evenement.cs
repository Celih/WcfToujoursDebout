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
            Date = new DateTime();
            Description = string.Empty;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
            Statut = string.Empty;
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
        public DateTime Date { get; set; }

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

        public string Statut { get; set; }

        #endregion

        #region Méthode interne
        /// <summary>
        /// Recupere l'Evenement.
        /// </summary>
        /// <param name="idEvenement">ID de l'Evenement</param>
        /// <returns>Données de l'Evenement</returns>
        internal static Evenement RecupererEvenement(int idEvenement)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idEvenement", idEvenement)
            };

            return procedure.Execute<Evenement>(ListProcedure.RecupererEvenement, sqlParam)[0];
        }

        internal static List<Evenement> RecupererListEvenement(int idUtilisateur)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idUtilisateur)
            };

            procedure.Execute<Evenement>(ListProcedure.RecupererListeEvenement, sqlParam);

            return new List<Evenement>();
        }

        /// <summary>
        /// Inserer un Evenement.
        /// </summary>
        /// <param name="evenement">Objet Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererEvenement(Evenement evenement)
        {
            Procedure procedure = new Procedure();

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Titre", evenement.Titre),
                new SqlParameter("@Adresse", evenement.Adresse),
                new SqlParameter("@Date", evenement.Date.Date),
                new SqlParameter("@Heure", evenement.Date.TimeOfDay),
                new SqlParameter("@Description", evenement.Description),
                new SqlParameter("@User_Creation", evenement.IdUserCreation)
            };

            procedure.Execute<Evenement>(ListProcedure.InsererEvenement, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un Evenement.
        /// </summary>
        /// <param name="evenement">Objet Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierEvenement(Evenement evenement)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", evenement.Id),
                new SqlParameter("@Titre", evenement.Titre),
                new SqlParameter("@Adresse", evenement.Adresse),
                new SqlParameter("@Date", evenement.Date.Date),
                new SqlParameter("@Heure", evenement.Date.TimeOfDay),
                new SqlParameter("@Description", evenement.Description),
                new SqlParameter("@User_Modification", evenement.IdUserModification),
            };

            procedure.Execute<Evenement>(ListProcedure.ModifierEvenement, sqlParam);
            return true;
        }

        /// <summary>
        /// Supprimer un Evenement.
        /// </summary>
        /// <param name="idEvenement">ID de l'Evenement</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerEvenement(int idEvenement)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idEvenement", idEvenement),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerEvenement, sqlParam);

            return true;
        }

        internal static bool LierTagEvenement(int idEvenement, int idTag)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idEvenement", idEvenement),
                new SqlParameter("@idTag", idTag),
            };

            procedure.Execute<Utilisateur>(ListProcedure.LierTagEvenement, sqlParam);
            return true; 
        }

        internal static List<Tag> GetListTag(int idEvenement)
        {
            List<Tag> listTag = new List<Tag>();

            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idEvenement", idEvenement)
            };

            List<TagEvenement> listTagEvenement = new List<TagEvenement>();
            listTagEvenement = procedure.Execute<TagEvenement>(ListProcedure.RecupererListTagEvenement, sqlParam);

            for (int i = 0; i < listTagEvenement.Count; i++)
            {
                procedure = new Procedure();
                sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idTag", listTagEvenement[i].IdTag)
            };

                listTag.Add(procedure.Execute<Tag>(ListProcedure.RecupererTag, sqlParam)[0]);
            }

            return listTag;
        }

        List<Evenement> IEntite<Evenement>.Remplire(SqlDataReader data)
        {
            List<Evenement> listEvenement = new List<Evenement>();
            while (data.Read())
            {
                IDataRecord record = data;
                Evenement evenement = new Evenement
                {
                    Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"],
                    Titre = (string)record["Titre"],
                    Adresse = (string)record["Adresse"],
                    Date = (DateTime)record["Date_Creation"],
                    Description = (string)record["Adresse"],
                    IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"],
                    UserCreation_Libelle = string.Empty,
                    DateCreation = (DateTime)record["Date_Creation"],
                    IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"],
                    UserModification_Libelle = string.Empty,
                    DateModification = (DateTime)record["Date_Modification"]
                };
                listEvenement.Add(evenement);
            }

            return listEvenement;
        }



        #endregion
    }
}