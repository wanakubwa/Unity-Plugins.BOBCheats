using UnityEngine;
using System.Collections;
using BOBCheats.Collections;
using System.Collections.Generic;
using BOBCheats.Utils;
using System.Xml.Serialization;

namespace BOBCheats.GUI
{
    public class CheatsMenuView : BOBUIView
    {
        #region Fields

        [Space]
        [SerializeField]
        private CheatCategoryPanelElement cheatCategoryPrefab;

        #endregion

        #region Propeties

        public CheatCategoryPanelElement CheatCategoryPrefab { get => cheatCategoryPrefab; }

        private CheatsMenuModel Model
        {
            get;
            set;
        }

        private List<CheatCategoryPanelElement> SpawnedCheatsCategories
        {
            get;
            set;
        } = new List<CheatCategoryPanelElement>();

        #endregion

        #region Methods

        public override void Initialize()
        {
            base.Initialize();

            Model = GetModel<CheatsMenuModel>();

            RefreshView();
        }

        public void RefreshView()
        {
            DestroySpawnedCheats();

            List<CheatCategory> categories = Model.GetAvaibleCheatsCategories();
            if(categories.IsNullOrEmpty() == false)
            {
                SpawnCheatsSections(categories);
            }
        }

        private void SpawnCheatsSections(List<CheatCategory> categories)
        {
            for(int i =0; i < categories.Count; i++)
            {
                CheatCategoryPanelElement cheatElement = Instantiate(CheatCategoryPrefab);
                cheatElement.transform.SetParent(CheatCategoryPrefab.transform.parent);
                cheatElement.transform.localScale = Vector3.one;
                cheatElement.gameObject.SetActive(true);

                cheatElement.Initialize(categories[i]);
                SpawnedCheatsCategories.Add(cheatElement);
            }
        }

        private void DestroySpawnedCheats()
        {
            for(int i = 0; i < SpawnedCheatsCategories.Count; i++)
            {
                Destroy(SpawnedCheatsCategories[i].gameObject);
            }

            SpawnedCheatsCategories.Clear();
        }

        #endregion

        #region Enums



        #endregion
    }
}

