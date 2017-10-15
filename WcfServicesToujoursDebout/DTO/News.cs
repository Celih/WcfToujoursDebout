using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServicesToujoursDebout.Constante;
using WcfServicesToujoursDebout.Utilitaire;

namespace WcfServicesToujoursDebout
{
    public class News : IEntite<News>
    {
        /// <summary>
        /// Constructeur par défault
        /// </summary>
        public News()
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

        #region Données News

        /// <summary>
        /// Id de la news.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de la news.
        /// </summary>
        public string Titre { get; set; }
        
        /// <summary>
        /// Texte de la news.
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
        /// Recupere l'News.
        /// </summary>
        /// <param name="idNews">ID de la News</param>
        /// <returns>Données de la News</returns>
        internal static News RecupererNews(int idNews)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idNews)
            };

            return procedure.Execute<News>(ListProcedure.RecupererNews, sqlParam);
        }

        /// <summary>
        /// Inserer un News.
        /// </summary>
        /// <param name="news">Objet News</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool InsererNews(News news)
        {

            Procedure procedure = new Procedure();

            //user.IdPhoto = user.IdPhoto != 0 ? user.IdPhoto : null; 

            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Nom", news.Texte)
            };

            procedure.Execute<News>(ListProcedure.InsererNews, sqlParam);
            return true;
        }

        /// <summary>
        /// Modifier un News.
        /// </summary>
        /// <param name="news">Objet News</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool ModifierNews(News news)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@Id", news.Id),
            };

            procedure.Execute<News>(ListProcedure.ModifierNews, sqlParam);

            return true;
        }

        /// <summary>
        /// Supprimer un News.
        /// </summary>
        /// <param name="idNews">ID de la News</param>
        /// <returns>Retour le résultat de la requete</returns>
        internal static bool SupprimerNews(int idNews)
        {
            Procedure procedure = new Procedure();
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter("@idUtilisateur", idNews),
            };

            procedure.Execute<Utilisateur>(ListProcedure.SupprimerNews, sqlParam);

            return true;
        }

        News IEntite<News>.Remplire(SqlDataReader data)
        {
            data.Read();
            IDataRecord record = data;
            News news = new News();

            news.Id = string.IsNullOrEmpty(Convert.ToString(record["Id"])) ? -1 : (int)record["Id"];
            news.Titre = (string)record["Titre"];
            news.Texte = (string)record["Texte"];
            news.IdUserCreation = string.IsNullOrEmpty(Convert.ToString(record["User_Creation"])) ? -1 : (int)record["User_Creation"];
            news.UserCreation_Libelle = string.Empty;
            news.DateCreation = (DateTime)record["Date_Creation"];
            news.IdUserModification = string.IsNullOrEmpty(Convert.ToString(record["User_Modification"])) ? -1 : (int)record["User_Modification"];
            news.UserModification_Libelle = string.Empty;
            news.DateModification = (DateTime)record["Date_Modification"];

            return news;
        }



        #endregion
    }
}