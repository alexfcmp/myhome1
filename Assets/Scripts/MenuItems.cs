using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LevelMaze
{
    public class MenuItems : MonoBehaviour
    {
        [MenuItem("ReinstantiateObject/Пункт меню №0 ")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyEditorScript), false, "Alexander");
        }
    }
}
