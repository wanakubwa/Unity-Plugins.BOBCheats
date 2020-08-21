using UnityEngine;
using UnityEditor;
using BOBCheats.Utils;

namespace BOBCheats
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyPropertyDrawer : PropertyDrawer
    {
        #region Fields



        #endregion

        #region Propeties



        #endregion

        #region Methods

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            UnityEngine.GUI.enabled = false;

            EditorGUI.PropertyField(position, property, label, true);

            UnityEngine.GUI.enabled = true;
        }

        #endregion

        #region Enums



        #endregion
    }
}

