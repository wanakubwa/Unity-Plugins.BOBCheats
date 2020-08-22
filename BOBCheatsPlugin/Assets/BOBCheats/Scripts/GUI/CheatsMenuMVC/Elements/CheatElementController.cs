using UnityEngine;
using System.Collections;
using BOBCheats.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Reflection;
using BOBCheats.Utils;
using System;
using Object = UnityEngine.Object;

namespace BOBCheats.GUI
{
    public class CheatElementController : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField]
        private Text cheatNameLabel;
        [SerializeField]
        private RectTransform parametersParent;
        [SerializeField]
        private List<ParameterInputField> inputFieldsCollection = new List<ParameterInputField>();
        [Space]
        [SerializeField]
        private UnityEvent onSelectCheat;

        #endregion

        #region Propeties

        public Text CheatNameLabel { 
            get => cheatNameLabel; 
        }

        public UnityEvent OnSelectCheat { 
            get => onSelectCheat; 
        }

        public List<ParameterInputField> InputFieldsCollection { 
            get => inputFieldsCollection; 
        }

        public RectTransform ParametersParent {
            get => parametersParent; 
        }

        public CheatInfo CachedCheat
        {
            get;
            private set;
        }

        public List<ParameterInputField> SpawnedParametersFields
        {
            get;
            private set;
        } = new List<ParameterInputField>();

        #endregion

        #region Methods

        public void DrawCheatElement(CheatInfo cheat)
        {
            SetCachedCheat(cheat);
            SetCheatNameLabel(cheat.CheatName);
            DrawCheatParameters(cheat.CachedInfo);
        }

        public void SetCachedCheat(CheatInfo cheat)
        {
            CachedCheat = cheat;
        }

        public void SetCheatNameLabel(string name)
        {
            CheatNameLabel.text = name;
        }

        public void UseCheat()
        {
            OnSelectCheat.Invoke();
        }

        public object[] GetCheatParameters()
        {
            object[] parameters = new object[SpawnedParametersFields.Count];
            for (int i = 0; i < SpawnedParametersFields.Count; i++)
            {
                parameters[i] = SpawnedParametersFields[i].GetValue();
            }

            return parameters;
        }

        private void DrawCheatParameters(MethodInfo method)
        {
            ParameterInfo[] cheatParameters = method.GetParameters();
            if(cheatParameters.IsNullOrEmpty() == true)
            {
                //tod; label with info.
                return;
            }

            SpawnedParametersFields.ClearDestroy();

            for(int i = 0; i < cheatParameters.Length; i++)
            {
                ParameterInputField field = GetInputFieldForType(cheatParameters[i].ParameterType);
                ParameterInputField spawnedField = Instantiate(field);
                spawnedField.transform.ResetParent(ParametersParent);
                spawnedField.SetLabel(cheatParameters[i].Name);

                SpawnedParametersFields.Add(spawnedField);
            }
        }

        private ParameterInputField GetInputFieldForType(Type fieldType)
        {
            ParameterInputField field = null;
            if (fieldType == typeof(int))
            {
                field = GetFieldByLabel(ParameterInputField.InputFieldType.INT);
            }
            else if (fieldType == typeof(float))
            {
                field = GetFieldByLabel(ParameterInputField.InputFieldType.FLOAT);
            }
            else if(fieldType == typeof(string))
            {
                field = GetFieldByLabel(ParameterInputField.InputFieldType.STRING);
            }
            else
            {
                Debug.LogErrorFormat("[BOBCheats] This type of field {0} is not supported!", fieldType);
            }

            return field;
        }

        private ParameterInputField GetFieldByLabel(ParameterInputField.InputFieldType label)
        {
            for(int i =0; i < InputFieldsCollection.Count; i++)
            {
                if(InputFieldsCollection[i].FieldType == label)
                {
                    return InputFieldsCollection[i];
                }
            }

            return null;
        }

        #endregion

        #region Enums



        #endregion
    }
}

