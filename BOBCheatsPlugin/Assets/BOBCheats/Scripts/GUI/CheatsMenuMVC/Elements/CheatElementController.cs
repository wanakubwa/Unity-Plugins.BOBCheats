using UnityEngine;
using System.Collections;
using BOBCheats.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BOBCheats.GUI
{
    public class CheatElementController : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField]
        private Text cheatNameLabel;
        [SerializeField]
        private UnityEvent onSelectCheat;

        #endregion

        #region Propeties

        public Text CheatNameLabel { get => cheatNameLabel; }
        public UnityEvent OnSelectCheat { get => onSelectCheat; }

        public CheatInfo CachedCheat
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public void SetCachedCheat(CheatInfo cheat)
        {
            CachedCheat = cheat;
            CheatNameLabel.text = CachedCheat.CheatName;
        }

        public void UseCheat()
        {
            OnSelectCheat.Invoke();
        }

        #endregion

        #region Enums



        #endregion
    }
}

