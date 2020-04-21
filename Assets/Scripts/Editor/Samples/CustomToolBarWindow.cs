using SEditorTool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

public class CustomToolBarWindow : SamplesBaseEditorWindow
{
    [MenuItem("SEditorTools/扩展工具")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<CustomToolBarWindow>();
        window.Show();
        //window.ShowAsDropDown(new Rect(),new Vector2(300, 600));
    }
    GUIContent content;
    Texture texture;
    string toolScriptPath = "Assets/Scripts/Editor/Samples/CustomTool.cs";

    private void OnEnable()
    {
        Title = "自定义工具栏工具";
        Description = "可以通过重写EditorTool来实现自己的Scene界面的操作工具";
        content = new GUIContent()
        {
            image =Resources.Load<Texture2D>("Tool"),
            text ="工具栏扩展工具"
        };
        texture = Resources.Load<Texture2D>("Tool");
        
    }

    
    protected override void OnGUI()
    {
        base.OnGUI();

        if (GUILayout.Button("查看工具代码"))
        {
            SEditorUtility.GoToPath(toolScriptPath);
        }
        EditorGUILayout.LabelField("单个显示");
        EditorGUILayout.EditorToolbar(CreateInstance<CustomTool>());


        EditorGUILayout.LabelField("列表显示");
        var tlist = new List<EditorTool>();
        tlist.Add(CreateInstance<CustomTool>());
        tlist.Add(CreateInstance<LikeTool>());
        EditorGUILayout.EditorToolbar<EditorTool>(tlist);

        //试了多次也没明白 EditorToolbarForTarget 的用法
        //var go = GameObject.Find("Cube");
        //EditorGUILayout.EditorToolbarForTarget(content, go);

        EditorGUILayout.LabelField("工具栏工具位置");
        var Rect = EditorGUILayout.GetControlRect();
        Rect.height = texture.height;
        Rect.width = texture.width;
        GUI.DrawTexture(Rect,texture);



    }
}
