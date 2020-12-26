using System;

namespace BOBCheats
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheatAttribute : Attribute
    {
        #region Fields

        #endregion

        #region Propeties

        public string CheatName {
            get;
            private set;
        } = string.Empty;

        public string CheatCategory {
            get;
            private set;
        } = string.Empty;

        #endregion

        #region Methods

        public CheatAttribute() { }

        public CheatAttribute(string category)
        {
            CheatCategory = category;
        }

        public CheatAttribute(string category, string name)
        {
            CheatName = name;
            CheatCategory = category;
        }

        #endregion

        #region Enums



        #endregion
    }
}
