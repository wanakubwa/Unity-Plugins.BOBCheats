using System;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;

namespace BOBCheats.Editor
{
    public class BOBSettingsEditorWindow : EditorWindow
    {
        #region Fields

        public const string WINDOW_NAME = "BOBCheats Settings";

        #endregion

        #region Propeties

        private BOBCheatsSettings Settings
        {
            get;
            set;
        }

        private Texture LogoGraphic
        {
            get;
            set;
        }

        #endregion

        #region Methods

        // Method to open the window
        [MenuItem("Window/BOBCheats")]
        public static void OpenWindow()
        {
            BOBSettingsEditorWindow window = GetWindow<BOBSettingsEditorWindow>(WINDOW_NAME);
            window.minSize = new Vector2(400, 200);
            window.Show();
        }

        private void OnEnable()
        {
            Settings = BOBCheatsSettings.Instance;
            if(Settings == null)
            {
                //todo; instance.
                Debug.LogError("[BOBCheats] Settings not instanced!");
                this.Close();
            }

            LogoGraphic = Resources.Load("Graphic/BOBCheats_Logo_v1") as Texture;
        }

        private void OnDestroy()
        {
            Settings.SaveThisAsset();
        }

        void OnGUI()
        {
            GUILayout.Box(LogoGraphic, GUILayout.Height(100), GUILayout.Width(EditorGUIUtility.currentViewWidth));
            GUILayout.Space(25);

            EditorGUILayout.BeginVertical();

            Settings.SetAutoInit(EditorGUILayout.Toggle("Is auto initialize enabled?", Settings.IsAutoinitializeEnabled));

            GUILayout.Space(10);
            DrawEnumPopUp("Activate key short", Settings.TriggerKey, Settings.SetTriggerKey);
            EditorGUILayout.Space();
            DrawButton("Reload cheats collection", Settings.RefreshCheatsCollection);
            EditorGUILayout.Space();
            DrawButton("Create BOBManager", EditorGameObjectSpawner.CreateBOBManagerObject);

            EditorGUILayout.EndVertical();
        }

        // Not in use but can be helpfull in future.
        //private void DrawToggle(string toggleName, bool value,  Action<bool> callback)
        //{
        //    bool toggleValue = EditorGUILayout.Toggle(toggleName, value);
        //    callback(toggleValue);
        //}

        private void DrawEnumPopUp<T>(string label, T currentValue, Action<T> callback) where T : Enum
        {
            T selectedEnum = (T)EditorGUILayout.EnumPopup(label, currentValue);
            callback(selectedEnum);
        }

        private void DrawButton(string label, Action callback)
        {
            if (GUILayout.Button(label, GUILayout.Height(25)) == true)
            {
                callback();
            }
        }

        #endregion

        #region Enums



        #endregion
    }
}
