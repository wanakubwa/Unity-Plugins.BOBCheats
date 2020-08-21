using UnityEngine;
using System.Collections;
using BOBCheats.Collections;
using System.Collections.Generic;
using BOBCheats.Utils;
using System.Xml.Serialization;

namespace BOBCheats.GUI
{
    public class CheatsMenuView : UIView
    {
        #region Fields

        [Space]
        [SerializeField]
        private CheatElementController cheatElementPrefab;

        #endregion

        #region Propeties

        public CheatElementController CheatElementPrefab { get => cheatElementPrefab; }

        private CheatsMenuModel Model
        {
            get;
            set;
        }

        private List<CheatElementController> SpawnedCheatsElements
        {
            get;
            set;
        } = new List<CheatElementController>();

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

            List<CheatInfo> cheats = Model.GetAvaibleCheats();
            if(cheats.IsNullOrEmpty() == false)
            {
                SpawnCheatsSections(cheats);
            }
        }

        private void SpawnCheatsSections(List<CheatInfo> cheats)
        {
            for(int i =0; i < cheats.Count; i++)
            {
                CheatElementController cheatElement = Instantiate(CheatElementPrefab);
                cheatElement.transform.SetParent(CheatElementPrefab.transform.parent);
                cheatElement.transform.localScale = Vector3.one;
                cheatElement.gameObject.SetActive(true);

                cheatElement.SetCachedCheat(cheats[i]);
                SpawnedCheatsElements.Add(cheatElement);
            }
        }

        private void DestroySpawnedCheats()
        {
            for(int i = 0; i < SpawnedCheatsElements.Count; i++)
            {
                Destroy(SpawnedCheatsElements[i].gameObject);
            }

            SpawnedCheatsElements.Clear();
        }

        #endregion

        #region Enums



        #endregion
    }
}

