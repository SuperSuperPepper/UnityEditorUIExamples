using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomWindow : SamplesBaseEditorWindow
{
    [MenuItem("SEditorTools/自定义窗口入口", priority = 0)]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<CustomWindow>();
        window.Show();
    }

    Vector2 pos;
    private void OnEnable()
    {
        Title = "目录";
        Description = "本窗口包含所有窗口的入口,可以快速寻找所需要功能模块";
    }


    protected override void OnGUI()
    {
        base.OnGUI();

        pos = EditorGUILayout.BeginScrollView(pos);

        ShowWindowButton<BaseModelWindow>("基础控件");
        ShowWindowButton<InheritCustomWindow>("扩展控件");
        ShowWindowButton<ScrollviewWindow>("布局控件");
        ShowWindowButton<CustomSkinWindow>("自定义Skin");
        ShowWindowButton<BeginFadeGroupWindow>("高级布局窗口");
        ShowWindowButton<DropdownWindow>("下拉菜单");
        ShowWindowButton<CustomToolBarWindow>("扩展工具栏的工具按钮");
        ShowWindowButton<ScopeWindow>("Scope范围检测");
        ShowComponentButton<BaseModel>("Component编辑器");

        EditorGUILayout.EndScrollView();
    }


    void ShowWindowButton<T>(string name) where T :EditorWindow
    {
        if (GUILayout.Button(name))
            EditorWindow.GetWindow<T>().Show();
    }
    GameObject showGo;

    void ShowComponentButton<T>(string name) where T :MonoBehaviour
    {
        if (GUILayout.Button(name))
        {
            if (showGo!=null)
            {
                DestroyImmediate(showGo);
            }
            showGo = new GameObject("BaseModel");

            showGo.AddComponent<T>();

            Selection.activeGameObject = showGo;
        }
    }


    private void OnDisable()
    {
        if (showGo != null)
        {
            DestroyImmediate(showGo);
        }
    }
}
