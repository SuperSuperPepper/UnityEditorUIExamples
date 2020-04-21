using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SEditorTool;

public class SamplesBaseEditorWindow : EditorWindow
{
    const string PrefixFilePath = "Assets/Scripts/Editor/Samples/";

    protected string Title { set; get; }

    protected string Description { set; get; }

    protected string FilePath { get { return PrefixFilePath + GetType().ToString()+".cs"; } }

    protected virtual void OnGUI()
    {
        EditorGUILayout.LabelField(Title);
        EditorGUILayout.LabelField(Description);
        if (GUILayout.Button("查看代码"))
        {
            SEditorUtility.GoToPath(FilePath);
        }
        SEditorGUILayout.HLine(1, Color.gray);
        EditorGUILayout.Space();
      
    } 
    
}
