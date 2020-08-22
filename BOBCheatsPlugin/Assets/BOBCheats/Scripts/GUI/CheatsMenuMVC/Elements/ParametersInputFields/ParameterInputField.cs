using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BOBCheats.GUI
{
    public abstract class ParameterInputField : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField]
        private InputField inputField;
        [SerializeField]
        private Text label;
        [Space]
        [SerializeField]
        private InputFieldType fieldType;

        #endregion

        #region Propeties

        public InputField InputField { 
            get => inputField; 
        }

        public Text Label { 
            get => label; 
        }

        public InputFieldType FieldType { 
            get => fieldType; 
        }

        public object Value
        {
            get;
            protected set;
        } = new object();

        #endregion

        #region Methods

        public abstract void SetValue(string text);

        public virtual object GetValue()
        {
            return Value;
        }

        public abstract void InitializeValue();

        public void SetLabel(string text)
        {
            Label.text = text;
        }

        private void Start()
        {
            InitializeValue();
        }

        #endregion

        #region Enums

        public enum InputFieldType
        {
            INT,
            FLOAT,
            STRING
        }

        #endregion
    }
}
