using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BOBCheats.Collections
{
    [Serializable]
    public class CheatCategory : IEquatable<string>
    {
        #region Fields

        [SerializeField]
        private string categoryName;
        [SerializeField]
        private List<CheatInfo> cheatsCollection = new List<CheatInfo>();

        #endregion

        #region Propeties

        public string CategoryName
        {
            get => categoryName;
            private set => categoryName = value;
        }

        public List<CheatInfo> CheatsCollection { 
            get => cheatsCollection; 
            private set => cheatsCollection = value; 
        }

        #endregion

        #region Methods

        public CheatCategory() { }

        public CheatCategory(string category)
        {
            CategoryName = category;
        }

        public void SetCategoryName(string category)
        {
            CategoryName = category;
        }

        public void AddCheat(CheatInfo cheat)
        {
            CheatsCollection.Add(cheat);
        }

        public bool Equals(string other)
        {
            return other.Equals(CategoryName);
        }

        #endregion

        #region Enums



        #endregion
    }
}

