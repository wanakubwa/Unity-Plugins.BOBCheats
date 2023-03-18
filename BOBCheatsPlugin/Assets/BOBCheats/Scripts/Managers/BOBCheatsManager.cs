using BOBCheats.Collections;
using BOBCheats.GUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BOBCheats
{
    public class BOBCheatsManager : MonoBehaviour
    {
        #region Fields

        private static BOBCheatsManager instance;

        [Space]
        [SerializeField]
        private CheatsMenuController cheatMobileMenuGUIPrefab;
        [SerializeField]
        private CheatsMenuController cheatDesktopMenuGUIPrefab;

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

        public CheatsMenuController CheatMenuGUIPrefab { get => cheatMobileMenuGUIPrefab; set => cheatMobileMenuGUIPrefab = value; }

        public List<CheatCategory> CategoriesCollection {
            get;
            private set;
        } = new List<CheatCategory>();

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

        #endregion


        #region Methods

        /// <summary>
        /// Use it for initialize BOB cheats, if auto initialize is enabled.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void AutoInitialize()
        {
            // BOB is already initiaized on scene.
            if(Instance != null)
            {
                return;
            }

            if(BOBCheatsSettings.IsAutoInitialize == true)
            {
                GameObject go = new GameObject("BOBCheatManager");
                BOBCheatsManager bob = go.AddComponent<BOBCheatsManager>();

                GameObject cheatsMenuObj = Resources.Load("GUI/BOBCheatsGUI") as GameObject;
                GameObject cheatsDesktopMenuObj = Resources.Load("GUI/BOBCheatsGUI_Desktop") as GameObject;

                bob.CheatMenuGUIPrefab = cheatsMenuObj.GetComponent<CheatsMenuController>();
                bob.cheatDesktopMenuGUIPrefab = cheatsDesktopMenuObj.GetComponent<CheatsMenuController>();

                GameObject.DontDestroyOnLoad(go);

                Debug.Log("[BOBCheats] Auto initialized!");
            }
        }

        public static void InitializeManually()
        {
            // BOB was initialized before.
            if (Instance != null)
            {
                Debug.LogWarning("[BOBCheats] Is already initialized check your code!");
                return;
            }

            GameObject go = new GameObject("BOBCheatManager");
            BOBCheatsManager bob = go.AddComponent<BOBCheatsManager>();

            GameObject cheatsMenuObj = Resources.Load("GUI/BOBCheatsGUI") as GameObject;
            GameObject cheatsDesktopMenuObj = Resources.Load("GUI/BOBCheatsGUI_Desktop") as GameObject;

            bob.CheatMenuGUIPrefab = cheatsMenuObj.GetComponent<CheatsMenuController>();
            bob.cheatDesktopMenuGUIPrefab = cheatsDesktopMenuObj.GetComponent<CheatsMenuController>();

            GameObject.DontDestroyOnLoad(go);

            Debug.Log("[BOBCheats] Manually initialized!");
        }

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
            try
            {
                CheatsMenuController cheatMenuGUI = Instantiate(GetCheatsGuiPrefabForCurrentPlatform());
                cheatMenuGUI.transform.localScale = Vector3.one;
                CurrentCheatGUI = cheatMenuGUI;
            }
            catch(Exception ex) 
            {
                Debug.LogError(ex.Message);
            }
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

            cheatsSettings.RefreshCheatsCollection();

            TriggerKey = cheatsSettings.TriggerKey;
            CategoriesCollection = cheatsSettings.CheatsCategories;
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

        private CheatsMenuController GetCheatsGuiPrefabForCurrentPlatform()
        {
            CheatsMenuController guiPrefab = null;

            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    guiPrefab = cheatMobileMenuGUIPrefab;
                    break;

                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.LinuxEditor:
                case RuntimePlatform.LinuxPlayer:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    guiPrefab = cheatDesktopMenuGUIPrefab;
                    break;

                default:
                    guiPrefab = cheatMobileMenuGUIPrefab;
                    break;
            }

            return guiPrefab;
        }

        private void Update()
        {
            if (Input.GetKeyDown(TriggerKey) == true)
            {
                ToggleCheatMenuGUI();
            }

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR

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
#endif

#endregion

#region Enums



#endregion
        }
    }
}
