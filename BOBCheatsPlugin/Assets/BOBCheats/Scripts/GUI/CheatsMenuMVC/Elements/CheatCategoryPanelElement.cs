using BOBCheats.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BOBCheats.GUI
{
    public class CheatCategoryPanelElement : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private Text nameLabel;
        [SerializeField]
        private RectTransform cheatsParent;
        [SerializeField]
        private CheatElementController cheatElementPrefab;

        #endregion

        #region Propeties

        public Text NameLabel { get => nameLabel; }
        public RectTransform CheatsParent { get => cheatsParent; }
        public CheatElementController CheatElementPrefab { get => cheatElementPrefab; }

        private CheatCategory CachedCategory
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void Initialize(CheatCategory category)
        {
            CachedCategory = category;

            RefreshCategoryLabel();
            SpawnCheats();

            SetCheatsVisible(false);

            if (CachedCategory.CategoryName.Equals(BOBCheatsSettings.DEFAULT_CATEGORY_NAME) == true)
            {
                SetCheatsVisible(true);
            }
        }

        public void ToggleSection()
        {
            if(CheatsParent.gameObject.activeInHierarchy == true)
            {
                SetCheatsVisible(false);
            }
            else
            {
                SetCheatsVisible(true);
            }
        }

        private void RefreshCategoryLabel()
        {
            NameLabel.text = CachedCategory.CategoryName;
        }

        private void SetCheatsVisible(bool isVisible)
        {
            CheatsParent.gameObject.SetActive(isVisible);
        }

        private void SpawnCheats()
        {
            foreach (CheatInfo cheat in CachedCategory.CheatsCollection)
            {
                SpawnCheatSections(cheat);
            }
        }

        private void SpawnCheatSections(CheatInfo cheat)
        {
            CheatElementController cheatElement = Instantiate(CheatElementPrefab);
            cheatElement.transform.SetParent(CheatsParent);
            cheatElement.transform.localScale = Vector3.one;
            cheatElement.gameObject.SetActive(true);

            cheatElement.DrawCheatElement(cheat);
        }

        #endregion

        #region Enums



        #endregion
    }
}
