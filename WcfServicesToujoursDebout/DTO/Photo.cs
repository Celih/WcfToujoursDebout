using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Serialization;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.Utilitaire;

namespace WcfServicesToujoursDebout
{
    public class Photo : IEntite<Photo>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public Photo()
        {
            Id = 0;
            //Image = null;
            Description = string.Empty;
            IdUserCreation = 0;
            UserCreation_Libelle = string.Empty;
            DateCreation = new DateTime();
            IdUserModification = 0;
            UserModification_Libelle = string.Empty;
            DateModification = new DateTime();
        }

        #region Données Photo

        /// <summary>
        /// Id de la photo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Image.
        /// </summary>
        //public Image Image { get; set; }

        /// <summary>
        /// Description de la photo.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id du User de creation.
        /// </summary>
        public int IdUserCreation { get; set; }

        /// <summary>
        /// Libelle du user de création (Prénom + Nom)
        /// </summary>
        [DataMember]
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
        /// Recupere l'Photo.
        /// </summary>
        /// <param name="idPhoto">ID de la Photo</param>
        /// <returns>Données de la Photo</returns>
        internal static Photo RecupererPhoto(int idPhoto)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idPhoto)
            };

            return procedure.Execute<Photo>(ListProcedure.RecupererPhoto, sqlParam)[0];
        }

        /// <summary>
        /// Inserer un Photo.
        /// </summary>
        /// <param name="photo">Objet Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererPhoto(Photo photo)
        {
            Procedure procedure = new Procedure();

            //user.IdPhoto = user.IdPhoto != 0 ? user.IdPhoto : null; 

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Nom", photo.IdUserCreation)
            };

            procedure.Execute<Photo>(ListProcedure.InsererPhoto, sqlParam);

            return true;
        }

        /// <summary>
        /// Modifier un Photo.
        /// </summary>
        /// <param name="photo">Objet Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierPhoto(Photo photo)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", photo.Id),
            };

            procedure.Execute<Photo>(ListProcedure.ModifierPhoto, sqlParam);
            return true;
        }

        /// <summary>
        /// Supprimer un Photo.
        /// </summary>
        /// <param name="idPhoto">ID de la Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerPhoto(int idPhoto)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idPhoto),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerPhoto, sqlParam);

            return true;
        }

        List<Photo> IEntite<Photo>.Remplire(SqlDataReader data)
        {
            List<Photo> listPhoto = new List<Photo>();
            while (data.Read())
            {
                IDataRecord record = data;
                Photo photo = new Photo
                {
                    Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"],
                    IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"],
                    UserCreation_Libelle = string.Empty,
                    DateCreation = (DateTime)record["Date_Creation"],
                    IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"],
                    UserModification_Libelle = string.Empty,
                    DateModification = (DateTime)record["Date_Modification"]
                };
                listPhoto.Add(photo);
            }

            return listPhoto;
        }



        #endregion
    }
}