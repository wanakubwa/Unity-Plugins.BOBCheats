using BOBCheats.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOBCheats.GUI
{
    public class FloatInputField : ParameterInputField
    {
        #region Fields



        #endregion

        #region Propeties



        #endregion

        #region Methods

        public override void InitializeValue()
        {
            Value = default(float);
            InputField.text = Value.ToString();
        }

        public override void SetValue(string text)
        {
            Value = text.ParseToFloat();
        }

        #endregion

        #region Enums



        #endregion
    }
}
