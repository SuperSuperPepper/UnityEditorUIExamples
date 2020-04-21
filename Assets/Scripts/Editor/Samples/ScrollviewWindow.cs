using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollviewWindow : SamplesBaseEditorWindow
{
    [MenuItem("SEditorTools/ScrollView窗口")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<ScrollviewWindow>();
        window.Show();
    }

    private void OnEnable()
    {
        Title = "布局窗口";
        Description = "演示了常用的布局效果";
    }

    Vector2 scrollPositionV;
    Vector2 scrollPositionH;
    bool[] pos = new bool[3] { true, true, true };
    bool posGroupEnabled = true;
    protected override void OnGUI()
    {
        base.OnGUI();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("横向布局", GUILayout.Width(100));
        GUILayout.Button("left");
        GUILayout.Button("right");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("纵向布局", GUILayout.Width(100));
        GUILayout.Button("up");
        GUILayout.Button("down");
        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("开关布局", GUILayout.Width(100));
        posGroupEnabled = EditorGUILayout.BeginToggleGroup("Align position", posGroupEnabled);
        pos[0] = EditorGUILayout.Toggle("x", pos[0]);
        pos[1] = EditorGUILayout.Toggle("y", pos[1]);
        pos[2] = EditorGUILayout.Toggle("z", pos[2]);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.LabelField("纵向ScrollView", GUILayout.Width(100));
        scrollPositionV = EditorGUILayout.BeginScrollView(scrollPositionV);
        for (int i = 0; i < 20; i++)
        {
            GUILayout.Button("ScrollViewItem" + i);
        }
        EditorGUILayout.EndScrollView();

        EditorGUILayout.LabelField("横向ScrollView", GUILayout.Width(100));
        scrollPositionH = EditorGUILayout.BeginScrollView(scrollPositionH);
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < 20; i++)
        {
            GUILayout.Button("ScrollViewItem" + i);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }
}
