using BOBCheats.Collections;
using BOBCheats.GUI;
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
        private CheatsMenuController cheatMenuGUIPrefab;

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

        public CheatsMenuController CheatMenuGUIPrefab { get => cheatMenuGUIPrefab; set => cheatMenuGUIPrefab = value; }

        public List<CheatInfo> CheatsCollection
        {
            get;
            private set;
        } = new List<CheatInfo>();

        private CheatsMenuController CurrentCheatGUI
        {
            get;
            set;
        }

        private KeyCode TriggerKey
        {
            get;
            set;
        }

        private bool OneClick { get; set; } = false;
        private float TimerForDoubleClick { get; set; }
        private float DoubleClickDelay { get; set; } = 0.2f;

        #endregion

        /// <summary>
        /// Use it for initialize BOB cheats collections. If using manual initialize setted in settings.
        /// </summary>
        #region Methods

        public void ToggleCheatMenuGUI()
        {
            if (CurrentCheatGUI != null)
            {
                HideGUI();
            }
            else
            {
                ShowGUI();
            }
        }

        public void ShowGUI()
        {
            CheatsMenuController cheatMenuGUI = Instantiate(CheatMenuGUIPrefab);
            cheatMenuGUI.transform.localScale = Vector3.one;
            CurrentCheatGUI = cheatMenuGUI;
        }

        public void HideGUI()
        {
            if (CurrentCheatGUI != null)
            {
                CurrentCheatGUI.DestroyGUIWindow();
                CurrentCheatGUI = null;
            }
        }

        public void UseCheat(CheatInfo cheat, object[] parameters)
        {
            if (cheat == null)
            {
                Debug.Log("Cheat was null! Can't use it!");
                return;
            }

            Debug.LogFormat("[BOBCheat] Activate cheat name: {0}", cheat.CheatName);
            cheat.CachedInfo.Invoke(null, parameters);
        }

        private void Awake()
        {
            DontDestroyCheck();

            BOBCheatsSettings cheatsSettings = BOBCheatsSettings.Instance;
            if (cheatsSettings == null)
            {
                Debug.Log("[BOBCheat] Scriptable object BOBCheatsSettings not instanced! Can't load cheats!");
                return;
            }

            TriggerKey = cheatsSettings.TriggerKey;
            CheatsCollection = cheatsSettings.CheatsCollection;
        }

        private void DontDestroyCheck()
        {
            BOBCheatsManager[] objs = FindObjectsOfType<BOBCheatsManager>();

            if (objs.Length > 1)
            {
                gameObject.SetActive(false);
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(TriggerKey) == true)
            {
                ToggleCheatMenuGUI();
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (OneClick == false)
                {
                    OneClick = true;

                    TimerForDoubleClick = Time.time;
                }
                else
                {
                    OneClick = false;
                    ToggleCheatMenuGUI();
                }
            }
            if (OneClick)
            {
                if ((Time.time - TimerForDoubleClick) > DoubleClickDelay)
                {
                    OneClick = false;
                }
            }

            #endregion

            #region Enums



            #endregion
        }
    }
}
