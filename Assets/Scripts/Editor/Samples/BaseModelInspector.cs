using SEditorTool;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseModel))]
public class BaseModelInspector : Editor
{

    SerializedProperty gameGo;
    private void OnEnable()
    {
        gameGo = serializedObject.FindProperty("go");

    }

    int sliderInt;

    public override void OnInspectorGUI()
    {

        if (GUILayout.Button("查看代码"))
        {
            SEditorUtility.GoToPath("Assets/Scripts/Editor/Samples/"+ GetType().ToString() + ".cs");
        }

        EditorGUILayout.LabelField("自己实现组件编辑Inspector页");

        EditorGUILayout.LabelField("大多数EditorGUIlayout下的API都可以在Editor下使用，再此不在演示");

        EditorGUILayout.PropertyField(gameGo);

        sliderInt = EditorGUILayout.IntSlider(sliderInt, 0, 1);
        serializedObject.ApplyModifiedProperties();

    }

}
