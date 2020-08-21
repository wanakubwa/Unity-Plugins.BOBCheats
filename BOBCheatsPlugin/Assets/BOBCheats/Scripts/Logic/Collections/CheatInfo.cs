using BOBCheats.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BOBCheats.Collections
{
    [Serializable]
    class CheatInfo
    {
        #region Fields

        [SerializeField, ReadOnly]
        private string cheatName;
        [SerializeField, HideInInspector]
        private MethodInfo cachedInfo;

        #endregion

        #region Propeties
        //xd
        public string CheatName { 
            get => cheatName; 
            private set => cheatName = value; 
        }

        public MethodInfo CachedInfo { 
            get => cachedInfo; 
            private set => cachedInfo = value; 
        }

        #endregion

        #region Methods

        public CheatInfo() { }

        public CheatInfo(string name, MethodInfo methodInfo)
        {
            CheatName = name;
            CachedInfo = methodInfo;
        }

        public void SetCheatName(string name)
        {
            CheatName = name;
        }

        public void SetMethodInfo(MethodInfo methodInfo)
        {
            CachedInfo = methodInfo;
        }

        #endregion

        #region Enums



        #endregion
    }
}
