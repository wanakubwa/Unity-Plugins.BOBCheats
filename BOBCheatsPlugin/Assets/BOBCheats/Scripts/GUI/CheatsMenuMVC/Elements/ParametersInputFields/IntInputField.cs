using BOBCheats.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOBCheats.GUI
{
    public class IntInputField : ParameterInputField
    {
        #region Fields



        #endregion

        #region Propeties



        #endregion

        #region Methods

        public override void InitializeValue()
        {
            Value = default(int);

            InputField.text = Value.ToString();
        }

        public override void SetValue(string text)
        {
            Value = text.ParseToInt();
        }

        #endregion

        #region Enums



        #endregion
    }
}
