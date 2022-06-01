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
            GUILayout.Label("���������", EditorStyles.boldLabel);
            ObjectForReinstantiate = EditorGUILayout.ObjectField("������ ������� ����� ��������", ObjectForReinstantiate, typeof(GameObject), true) as GameObject;
            nameObject = EditorGUILayout.TextField("��� ������� ��� ���������", nameObject);
            randomColor = EditorGUILayout.Toggle("��������������� ����?", randomColor);
            var button = GUILayout.Button("�������� ������");
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
      