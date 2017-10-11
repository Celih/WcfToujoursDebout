using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServicesToujoursDebout.Constante
{
    public class ListProcedure
    {
        #region Utilisateur

        /// <summary>
        /// Procedure : GetUtilisateur
        /// </summary>
        public const string RecupererUtilisateur = "ToujoursDebout.dbo.GetUtilisateur";

        /// <summary>
        /// Procedure : GetUtilisateur
        /// </summary>
        public const string InsererUtilisateur = "ToujoursDebout.dbo.InsertUtilisateur";

        /// <summary>
        /// Procedure : GetUtilisateur
        /// </summary>
        public const string ModifierUtilisateur = "ToujoursDebout.dbo.UpdateUtilisateur";

        #endregion
    }
}