using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    public abstract class BOBUIModel : MonoBehaviour
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

        public T GetView<T>() where T : BOBUIView
        {
            T view = GetComponent<BOBUIView>() as T;
            return view;
        }

        #endregion

        #region Handlers



        #endregion
    }
}

