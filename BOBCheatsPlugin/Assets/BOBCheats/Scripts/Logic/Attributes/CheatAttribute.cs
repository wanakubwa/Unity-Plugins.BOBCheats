using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOBCheats
{
    public class CheatAttribute : Attribute
    {
        #region Fields

        #endregion

        #region Propeties

        public string CheatName
        {
            get;
            private set;
        } = string.Empty;

        #endregion

        #region Methods

        public CheatAttribute() { }

        public CheatAttribute(string name)
        {
            CheatName = name;
        }

        #endregion

        #region Enums



        #endregion
    }
}
