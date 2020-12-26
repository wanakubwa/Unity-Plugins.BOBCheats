using BOBCheats.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BOBCheats.GUI
{
    public class CheatsMenuModel : BOBUIModel
    {
        #region Fields



        #endregion

        #region Propeties



        #endregion

        #region Methods

        public List<CheatCategory> GetAvaibleCheatsCategories()
        {
            BOBCheatsManager cheatsManager = BOBCheatsManager.Instance;
            if (cheatsManager == null)
            {
                return null;
            }

            return cheatsManager.CategoriesCollection;
        }

        #endregion

        #region Enums



        #endregion
    }
}

