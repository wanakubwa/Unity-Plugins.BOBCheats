using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    public abstract class UIView : MonoBehaviour
    {
        #region Fields



        #endregion

        #region Propeties



        #endregion

        #region Methods

        public virtual void Initialize()
        {

        }

        public virtual void AttachEvents()
        {

        }

        public virtual void DettachEvents()
        {

        }

        public T GetModel<T>() where T : UIModel
        {
            T model = GetComponent<UIModel>() as T;
            return model;
        }

        #endregion

        #region Handlers



        #endregion
    }
}

