using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    public abstract class UIController : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField]
        private UIModel model;
        [SerializeField]
        private UIView view;

        #endregion

        #region Propeties

        internal UIModel Model
        {
            get => model;
            private set => model = value;
        }

        internal UIView View
        {
            get => view;
            private set => view = value;
        }

        #endregion

        #region Methods

        public void DestroyGUIWindow()
        {
            Destroy(gameObject);
        }

        public void OnDisable()
        {
            DettachEvents();
        }

        public void OnEnable()
        {
            AttachEvents();
        }

        public virtual void Start()
        {
            Initialize();
        }

        public virtual void AttachEvents()
        {
            Model.AttachEvents();
            View.AttachEvents();
        }

        public virtual void DettachEvents()
        {
            Model.DettachEvents();
            View.DettachEvents();
        }

        public virtual void Initialize()
        {
            Model.Initialize();
            View.Initialize();
        }

        public T GetModel<T>() where T : UIModel
        {
            T model = GetComponent<UIModel>() as T;
            return model;
        }

        public T GetView<T>() where T : UIView
        {
            T model = GetComponent<UIView>() as T;
            return model;
        }

        #endregion
    }
}

