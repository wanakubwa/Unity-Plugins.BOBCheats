using UnityEngine.UI;

namespace BOBCheats.GUI
{
    public class BooleanInputField : ParameterInputField
    {
        #region Fields

        [UnityEngine.SerializeField]
        UnityEngine.UI.Toggle targetToggle;

        #endregion

        #region Propeties

        private Toggle TargetToggle { 
            get => targetToggle; 
        }

        #endregion

        #region Methods

        public override void InitializeValue()
        {
            Value = false;
            TargetToggle.isOn = (bool)Value;
        }

        public override void SetValue(string text)
        {
            Value = text == false.ToString() ? false : true;
        }

        public void OnToggleChanged(bool isOn)
        {
            SetValue(isOn.ToString());
        }

        #endregion

        #region Enums



        #endregion
    }
}
