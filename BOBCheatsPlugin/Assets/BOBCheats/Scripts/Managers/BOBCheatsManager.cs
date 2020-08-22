using BOBCheats.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BOBCheats
{
    public class BOBCheatsManager : MonoBehaviour
    {
        #region Fields

        private static BOBCheatsManager instance;

        [Space]
        [SerializeField]
        private GameObject cheatMenuGUIPrefab;

        #endregion

        #region Propeties

        public static BOBCheatsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (BOBCheatsManager)FindObjectOfType(typeof(BOBCheatsManager));
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public GameObject CheatMenuGUIPrefab { get => cheatMenuGUIPrefab; }

        public List<CheatInfo> CheatsCollection
        {
            get;
            private set;
        } = new List<CheatInfo>();

        #endregion

        /// <summary>
        /// Use it for initialize BOB cheats collections. If using manual initialize setted in settings.
        /// </summary>
        #region Methods
        public static void Initialize()
        {
            BOBCheatsSettings cheatsSettings = BOBCheatsSettings.Instance;
            if (cheatsSettings == null)
            {
                return;
            }

            cheatsSettings.RefreshCheatsCollection();
        }

        public void ShowGUI()
        {
            GameObject cheatMenuGUI = Instantiate(CheatMenuGUIPrefab);
            cheatMenuGUI.transform.localScale = Vector3.one;
        }

        public void UseCheat(CheatInfo cheat, object[] parameters)
        {
            if(cheat == null)
            {
                Debug.Log("Cheat was null! Can't use it!");
                return;
            }

            // TODO: Parameters of cheat.
            Debug.LogFormat("[BOBCheat] Activate cheat name: {0}", cheat.CheatName);
            cheat.CachedInfo.Invoke(null, parameters);
        }

        private void Awake()
        {
            BOBCheatsSettings cheatsSettings = BOBCheatsSettings.Instance;
            if (cheatsSettings == null)
            {
                Debug.Log("[BOBCheat] Scriptable object BOBCheatsSettings not instanced! Can't load cheats!");
                return;
            }

            if (cheatsSettings.IsManualInitialize == false)
            {
                Initialize();
            }

            CheatsCollection = cheatsSettings.CheatsCollection;
        }

        #endregion

        #region Enums



        #endregion
    }
}
