using UnityEngine;
using System.Collections;

namespace BOBCheats.GUI
{
    public abstract class BOBUIController : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField]
        private BOBUIModel model;
        [SerializeField]
        private BOBUIView view;

        #endregion

        #region Propeties

        internal BOBUIModel Model
        {
            get => model;
            private set => model = value;
        }

        internal BOBUIView View
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

        public T GetModel<T>() where T : BOBUIModel
        {
            T model = GetComponent<BOBUIModel>() as T;
            return model;
        }

        public T GetView<T>() where T : BOBUIView
        {
            T model = GetComponent<BOBUIView>() as T;
            return model;
        }

        #endregion
    }
}

