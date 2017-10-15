using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServicesToujoursDebout.DTO;

namespace WcfServicesToujoursDebout
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ToujoursDebout" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ToujoursDebout.svc ou ToujoursDebout.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ToujoursDebout : IToujoursDebout
    {
        #region Services Utilisateur

        public Utilisateur GetUtilisateur(int idUtilisateur)
        {
            return Utilisateur.RecupererUtilisateur(idUtilisateur);
        }

        public bool InsertUtilisateur(Utilisateur user)
        {
            return Utilisateur.InsererUtilisateur(user);
        }

        public bool UpdateUtilisateur(Utilisateur user)
        {
            return Utilisateur.ModifierUtilisateur(user);
        }

        public bool DeleteUtilisateur(int idUtilisateur)
        {
            return Utilisateur.SupprimerUtilisateur(idUtilisateur);
        }

        #endregion

        #region Services Evenement

        public Evenement GetEvenement(int idEvenemenet)
        {
            return Evenement.RecupererEvenement(idEvenemenet);
        }

        public List<Evenement> GetListEvenement(int idUtilisateur)
        {
            return new List<Evenement>();
        }

        public bool InsertEvenement(Evenement evenement)
        {
            return Evenement.InsererEvenement(evenement);
        }

        public bool UpdateEvenement(Evenement evenement)
        {
            return Evenement.ModifierEvenement(evenement);
        }

        public bool DeleteEvenement(int idEvenemenet)
        {
            return Evenement.SupprimerEvenement(idEvenemenet);
        }

        #endregion

        #region Services FAQ

        public FAQ GetFAQ(int idFAQ)
        {
            return FAQ.RecupererFAQ(idFAQ);
        }

        public bool InsertFAQ(FAQ faq)
        {
            return FAQ.InsererFAQ(faq);
        }

        public bool UpdateFAQ(FAQ faq)
        {
            return FAQ.ModifierFAQ(faq);
        }

        public bool DeleteFAQ(int idFAQ)
        {
            return FAQ.SupprimerFAQ(idFAQ);
        }

        #endregion

        #region Services MotCle

        public MotCle GetMotCle(int idMotCle)
        {
            return MotCle.RecupererMotCle(idMotCle);
        }

        public bool InsertMotCle(MotCle motCle)
        {
            return MotCle.InsererMotCle(motCle);
        }

        public bool UpdateMotCle(MotCle motCle)
        {
            return MotCle.ModifierMotCle(motCle);
        }

        public bool DeleteMotCle(int idMotCle)
        {
            return MotCle.SupprimerMotCle(idMotCle);
        }

        #endregion

        #region Services Photo

        public Photo GetPhoto(int idPhoto)
        {
            return Photo.RecupererPhoto(idPhoto);
        }

        public bool InsertPhoto(Photo photo)
        {
            return Photo.InsererPhoto(photo);
        }

        public bool UpdatePhoto(Photo photo)
        {
            return Photo.ModifierPhoto(photo);
        }

        public bool DeletePhoto(int idPhoto)
        {
            return Photo.SupprimerPhoto(idPhoto);
        }

        #endregion

        #region Services Publication

        public Publication GetPublication(int idPublication)
        {
            return Publication.RecupererPublication(idPublication);
        }

        public bool InsertPublication(Publication publication)
        {
            return Publication.InsererPublication(publication);
        }

        public bool UpdatePublication(Publication publication)
        {
            return Publication.ModifierPublication(publication);
        }

        public bool DeletePublication(int idPublication)
        {
            return Publication.SupprimerPublication(idPublication);
        }

        #endregion

        #region Services Tag

        public Tag GetTag(int idTag)
        {
            return Tag.RecupererTag(idTag);
        }

        public bool InsertTag(Tag tag)
        {
            return Tag.InsererTag(tag);
        }

        public bool UpdateTag(Tag tag)
        {
            return Tag.ModifierTag(tag);
        }

        public bool DeleteTag(int idTag)
        {
            return Tag.SupprimerTag(idTag);
        }

        #endregion

        #region Services News

        public News GetNews(int idNews)
        {
            return News.RecupererNews(idNews);
        }

        public bool InsertNews(News news)
        {
            return News.InsererNews(news);
        }

        public bool UpdateNews(News news)
        {
            return News.ModifierNews(news);
        }

        public bool DeleteNews(int idNews)
        {
            return News.SupprimerNews(idNews);
        }

        #endregion

        #region Services Commentaire

        public Commentaire GetCommentaire(int idCommentaire)
        {
            return Commentaire.RecupererCommentaire(idCommentaire);
        }

        public bool InsertCommentaire(Commentaire Commentaire)
        {
            return Commentaire.InsererCommentaire(Commentaire);
        }

        public bool UpdateCommentaire(Commentaire Commentaire)
        {
            return Commentaire.ModifierCommentaire(Commentaire);
        }

        public bool DeleteCommentaire(int idCommentaire)
        {
            return Commentaire.SupprimerCommentaire(idCommentaire);
        }

        #endregion


    }


}

