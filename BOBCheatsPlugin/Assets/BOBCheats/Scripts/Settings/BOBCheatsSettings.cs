using BOBCheats.Collections;
using BOBCheats.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BOBCheats
{
    [Serializable]
    [CreateAssetMenu(fileName = "BOBCheatsSettings.asset", menuName = "Settings/BOBCheatsSettings")]
    public class BOBCheatsSettings : ScriptableObject
    {
        #region Fields

        private static BOBCheatsSettings instance;

        [Space]
        [SerializeField]
        private bool isManualInitialize = false;

        [SerializeField]
        private List<CheatInfo> cheatsCollection = new List<CheatInfo>();

        [SerializeField]
        private bool tmp;

        #endregion

        #region Propeties

        public static BOBCheatsSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<BOBCheatsSettings>("BOBCheatsSettings");
                }

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public List<CheatInfo> CheatsCollection { 
            get => cheatsCollection; 
            private set => cheatsCollection = value; 
        }

        public bool IsManualInitialize { 
            get => isManualInitialize; 
        }

        #endregion

        #region Methods

        private void OnValidate()
        {
            RefreshCheatsCollection();
        }

        public void RefreshCheatsCollection()
        {
            CheatsCollection.Clear();

            List<Type> cheatsContainers = GetCheatsContainersInAssemblies();
            if(cheatsContainers.IsNullOrEmpty() == true)
            {
                return;
            }

            List<MethodInfo> cheatsMethods = GetCheatsMethods(cheatsContainers);
            if(cheatsMethods.IsNullOrEmpty() == true)
            {
                return;
            }

            CheatsCollection = GetCheatsInfoCollection(cheatsMethods);
        }

        private List<Type> GetCheatsContainersInAssemblies()
        {
            List<Type> cheatsContainers = new List<Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                cheatsContainers.AddRange(assemblies[i].GetTypes(typeof(CheatBase)));
            }

            return cheatsContainers;
        }

        private List<MethodInfo> GetCheatsMethods(List<Type> containers)
        {
            List<MethodInfo> cheatsMethods = new List<MethodInfo>();
            for(int i =0; i < containers.Count; i++)
            {
                foreach (MethodInfo method in containers[i].GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    if(method.HasCustomAttribute(typeof(CheatAttribute)) == true)
                    {
                        cheatsMethods.Add(method);
                    }
                }
            }

            return cheatsMethods;
        }

        private List<CheatInfo> GetCheatsInfoCollection(List<MethodInfo> cheatsMethods)
        {
            List<CheatInfo> cheatInfos = new List<CheatInfo>();
            for(int i =0; i < cheatsMethods.Count; i++)
            {
                cheatInfos.Add(GetFormattedCheatInfo(cheatsMethods[i]));
            }

            return cheatInfos;
        }

        /// <summary>
        /// You can customize the cheat stored data here.
        /// </summary>
        /// <param name="method"> Cheat method. </param>
        /// <returns> Formatted cheat info instance. </returns>
        private CheatInfo GetFormattedCheatInfo(MethodInfo method)
        {
            CheatInfo cheat = new CheatInfo(method.Name, method);
            return cheat;
        }

        #endregion

        #region Enums



        #endregion
    }
}


