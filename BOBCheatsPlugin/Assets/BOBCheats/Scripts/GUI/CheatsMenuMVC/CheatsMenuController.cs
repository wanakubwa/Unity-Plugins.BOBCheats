using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    [RequireComponent(typeof(CheatsMenuModel), typeof(CheatsMenuView))]
    public class CheatsMenuController : UIController
    {
        #region Fields



        #endregion

        #region Propeties

        private CheatsMenuModel Model
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            Model = GetModel<CheatsMenuModel>();
        }

        public void SelectCheat(CheatElementController sender)
        {
            Model.EnableCheat(sender.CachedCheat, sender.GetCheatParameters());
        }

        #endregion

        #region Enums



        #endregion
    }
}

