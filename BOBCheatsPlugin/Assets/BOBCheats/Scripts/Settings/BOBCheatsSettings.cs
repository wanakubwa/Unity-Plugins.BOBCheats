using BOBCheats.Collections;
using BOBCheats.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BOBCheats
{
    [Serializable]
    [CreateAssetMenu(fileName = "BOBCheatsSettings.asset", menuName = "Settings/BOBCheatsSettings")]
    public class BOBCheatsSettings : ScriptableObject
    {
        #region Fields

        public const string DEFAULT_CATEGORY_NAME = "Other";

        private static BOBCheatsSettings instance;

        [Space]
        [SerializeField]
        private KeyCode triggerKey;

        [Space]
        [SerializeField]
        private List<CheatCategory> cheatsCategories = new List<CheatCategory>();

        [SerializeField]
        private bool isAutoinitializeEnabled = true;

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

        public KeyCode TriggerKey { 
            get => triggerKey;
            private set => triggerKey = value;
        }

        internal List<CheatCategory> CheatsCategories { 
            get => cheatsCategories; 
            private set => cheatsCategories = value; 
        }

        public bool IsAutoinitializeEnabled { 
            get => isAutoinitializeEnabled; 
            private set => isAutoinitializeEnabled = value; 
        }

        #endregion

        #region Settings Shortcuts

        public static bool IsAutoInitialize => Instance.IsAutoinitializeEnabled;

        #endregion

        #region Methods

        public void SetAutoInit(bool isAutoinit)
        {
            IsAutoinitializeEnabled = isAutoinit;
        }

        public void SetTriggerKey(KeyCode key)
        {
            TriggerKey = key;
        }

        public void RefreshCheatsCollection()
        {
            CheatsCategories.Clear();

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

            CreateCheatsCategoryCollection(cheatsMethods);
        }

        private void OnEnable()
        {

#if UNITY_EDITOR
            RefreshCheatsCollection();
#endif

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

        private void CreateCheatsCategoryCollection(List<MethodInfo> cheatsMethods)
        {
            for (int i = 0; i < cheatsMethods.Count; i++)
            {
                AddCheatMethodToCategory(cheatsMethods[i]);
            }
        }

        private void AddCheatMethodToCategory(MethodInfo cheatMethod)
        {
            CheatAttribute attribute = (CheatAttribute)cheatMethod.GetCustomAttribute(typeof(CheatAttribute));

            string cheatCategory = attribute.CheatCategory == string.Empty ? DEFAULT_CATEGORY_NAME : attribute.CheatCategory;

            CheatCategory currentCategory = GetCheatCategoryByName(cheatCategory);
            currentCategory.AddCheat(GetFormattedCheatInfo(cheatMethod));
        }

        private CheatCategory GetCheatCategoryByName(string name)
        {
            CheatCategory category = null;

            foreach (CheatCategory cheatCategory in CheatsCategories)
            {
                if(cheatCategory.Equals(name) == true)
                {
                    category = cheatCategory;
                    break;
                }
            }

            if(category == null)
            {
                category = new CheatCategory(name);
                CheatsCategories.Add(category);
            }

            return category;
        }

        /// <summary>
        /// You can customize the cheat stored data here.
        /// </summary>
        /// <param name="method"> Cheat method. </param>
        /// <returns> Formatted cheat info instance. </returns>
        private CheatInfo GetFormattedCheatInfo(MethodInfo method)
        {
            string cheatName = string.Empty;

            CheatAttribute attribute = (CheatAttribute)method.GetCustomAttribute(typeof(CheatAttribute));
            if(attribute.CheatName != string.Empty)
            {
                cheatName = attribute.CheatName;
            }
            else
            {
                cheatName = method.Name.AddSpaces();
            }

            CheatInfo cheat = new CheatInfo(cheatName, method);
            return cheat;
        }

#if UNITY_EDITOR
        public void SaveThisAsset()
        {
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif

#endregion

        #region Enums



        #endregion
    }
}


