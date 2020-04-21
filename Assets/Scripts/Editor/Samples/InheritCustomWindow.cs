using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SEditorTool;
using UnityEditor;
using System;

[SEditorWindowAttr(500, 500)]
public class InheritCustomWindow : SBaseEditorWindow<InheritCustomWindow>
{
    [MenuItem("SEditorTools/继承自定义窗口")]
    public static void OpenWindow()
    {
        var window = GetWindow();
        window.Show();     
    }

    float tempTime;
    string longString;

    private void OnGUI()
    {                 
        EditorGUILayout.LabelField("这是继承自SBaseEditorWindow");        
        EditorGUILayout.LabelField("扩展了初次设置初次打开的大小");
        if (GUILayout.Button("查看代码"))
        {
            SEditorUtility.GoToPath("Assets/Scripts/Editor/Samples/InheritCustomWindow.cs");
        }
       

        EditorGUILayout.LabelField("横线");
        SEditorGUILayout.HLine(1, Color.gray);

        EditorGUILayout.LabelField("进度条");   
        SEditorGUILayout.HLine(3, Color.green,tempTime/600f);
   


    
    }


    override protected void OnEnable()
    {
      
        base.OnEnable();
        EditorApplication.update += OnUpdate;
    }

    

    protected override void OnDisable()
    {
        base.OnDisable();
        EditorApplication.update -= OnUpdate;
    }
    private void OnUpdate()
    {
        tempTime++;
        if (tempTime > 600)
        {
            tempTime = 0;
        }
        Repaint();
    }

}
