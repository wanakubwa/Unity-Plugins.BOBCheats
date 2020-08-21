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
                Debug.Log("[BOBCheat] Scriptable object BOBCheatsSettings not instanced! Can't load cheats!");
                return;
            }

            cheatsSettings.RefreshCheatsCollection();
        }

        public void ShowGUI()
        {
            //todo;
        }

        public void UseCheat(CheatInfo cheat)
        {
            if(cheat == null)
            {
                Debug.Log("Cheat was null! Can't use it!");
                return;
            }

            // TODO: Parameters of cheat.
            cheat.CachedInfo.Invoke(null, null);
        }

        private void Awake()
        {
            if (BOBCheatsSettings.Instance?.IsManualInitialize == false)
            {
                Initialize();
            }

            CheatsCollection = BOBCheatsSettings.Instance?.CheatsCollection;
        }

        #endregion

        #region Enums



        #endregion
    }
}
