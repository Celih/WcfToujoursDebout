using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static WcfServicesToujoursDebout.ToujoursDebout;

namespace WcfServicesToujoursDebout
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IToujoursDebout" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IToujoursDebout
    {
        #region Services Utilisateur

        [OperationContract]
        Utilisateur GetUtilisateur(int idUtilisateur);

        [OperationContract]
        bool InsertUtilisateur(Utilisateur user);

        [OperationContract]
        bool UpdateUtilisateur(Utilisateur user);

        [OperationContract]
        bool DeleteUtilisateur(int idUtilisateur);

        #endregion

        #region Services Evenement

        [OperationContract]
        Evenement GetEvenement(int idEvenemenet);

        [OperationContract]
        List<Evenement> GetListEvenement(int idUtilisateur);

        [OperationContract]
        bool InsertEvenement(Evenement evenement);

        [OperationContract]
        bool UpdateEvenement(Evenement evenement);

        [OperationContract]
        bool DeleteEvenement(int idEvenemenet);

        #endregion

        #region Services FAQ

        [OperationContract]
        FAQ GetFAQ(int idFAQ);

        [OperationContract]
        bool InsertFAQ(FAQ faq);

        [OperationContract]
        bool UpdateFAQ(FAQ faq);

        [OperationContract]
        bool DeleteFAQ(int idFAQ);

        #endregion

        #region Services MotCle

        [OperationContract]
        MotCle GetMotCle(int idMotCle);

        [OperationContract]
        bool InsertMotCle(MotCle motCle);

        [OperationContract]
        bool UpdateMotCle(MotCle motCle);

        [OperationContract]
        bool DeleteMotCle(int idMotCle);

        #endregion

        #region Services Photo

        [OperationContract]
        Photo GetPhoto(int idPhoto);

        [OperationContract]
        bool InsertPhoto(Photo photo);

        [OperationContract]
        bool UpdatePhoto(Photo photo);

        [OperationContract]
        bool DeletePhoto(int idPhoto);

        #endregion

        #region Services Publication

        [OperationContract]
        Publication GetPublication(int idPublication);

        [OperationContract]
        bool InsertPublication(Publication publication);

        [OperationContract]
        bool UpdatePublication(Publication publication);

        [OperationContract]
        bool DeletePublication(int idPublication);

        #endregion

        #region Services Tag

        [OperationContract]
        Tag GetTag(int idTag);

        [OperationContract]
        bool InsertTag(Tag tag);

        [OperationContract]
        bool UpdateTag(Tag tag);

        [OperationContract]
        bool DeleteTag(int idTag);

        #endregion

        #region Services News

        [OperationContract]
        News GetNews(int idNews);

        [OperationContract]
        bool InsertNews(News news);

        [OperationContract]
        bool UpdateNews(News news);

        [OperationContract]
        bool DeleteNews(int idNews);

        #endregion
        
    }
}
