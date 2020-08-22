using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    public abstract class BOBUIView : MonoBehaviour
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

        public T GetModel<T>() where T : BOBUIModel
        {
            T model = GetComponent<BOBUIModel>() as T;
            return model;
        }

        #endregion

        #region Handlers



        #endregion
    }
}

