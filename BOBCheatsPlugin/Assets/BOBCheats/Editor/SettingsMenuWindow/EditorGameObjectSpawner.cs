using BOBCheats.GUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace BOBCheats.Editor
{
    public class EditorGameObjectSpawner
    {
		public static void CreateBOBManagerObject()
		{
            GameObject manager = new GameObject();
            manager.name = "BOBCheatsManager";
            BOBCheatsManager bobManager = manager.AddComponent<BOBCheatsManager>();

            // Register object for undo.
            Undo.RegisterCreatedObjectUndo(manager, "Created BOBManager Object");

            MonoScript managerScript = MonoScript.FromMonoBehaviour(bobManager);
            string scriptPath = Path.GetDirectoryName(AssetDatabase.GetAssetPath(managerScript));
            scriptPath = scriptPath.Replace("Scripts\\Managers", "Resources\\GUI\\BOBCheatsGUI");
            GameObject cheatsMenuObj = Resources.Load("GUI/BOBCheatsGUI") as GameObject;
            bobManager.CheatMenuGUIPrefab = cheatsMenuObj.GetComponent<CheatsMenuController>();
        }
    }
}
