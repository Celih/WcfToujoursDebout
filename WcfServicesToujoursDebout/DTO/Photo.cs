using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Serialization;

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
            return new Photo();
        }

        /// <summary>
        /// Inserer un Photo.
        /// </summary>
        /// <param name="photo">Objet Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererPhoto(Photo photo)
        {
            return true;
        }

        /// <summary>
        /// Modifier un Photo.
        /// </summary>
        /// <param name="photo">Objet Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierPhoto(Photo photo)
        {
            return true;
        }

        /// <summary>
        /// Supprimer un Photo.
        /// </summary>
        /// <param name="idPhoto">ID de la Photo</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerPhoto(int idPhoto)
        {
            return true;
        }

        Photo IEntite<Photo>.Remplire(SqlDataReader data)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}