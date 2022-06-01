using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LevelMaze
{
    public class MyEditorScript : EditorWindow
    {
        public static GameObject ObjectForReinstantiate;
        public string nameObject = "Hello World";
        public bool randomColor = false;

        private void OnGUI()
        {
            GUILayout.Label("Настройки", EditorStyles.boldLabel);
            ObjectForReinstantiate = EditorGUILayout.ObjectField("Объект который хотим изменить", ObjectForReinstantiate, typeof(GameObject), true) as GameObject;
            nameObject = EditorGUILayout.TextField("Имя объекта для изменения", nameObject);
            randomColor = EditorGUILayout.Toggle("Рандомизировать цвет?", randomColor);
            var button = GUILayout.Button("Изменить объект");
            if (button)
            {
                if (ObjectForReinstantiate)
                {
                    Debug.Log("sdsdSdasdasdasdasdasd2131312312");
                    ObjectForReinstantiate.name = nameObject;
                    if (randomColor && ObjectForReinstantiate.TryGetComponent<Renderer>(out var changeMaterial))
                    { 
                        changeMaterial.material.color = Random.ColorHSV(); 
                    }
                }
            }
        }
    }
}
      