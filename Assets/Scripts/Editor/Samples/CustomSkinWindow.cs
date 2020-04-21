using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomSkinWindow : SamplesBaseEditorWindow
{


    [MenuItem("SEditorTools/自定义皮肤窗口")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<CustomSkinWindow>();
        window.Show();
    }

    private void OnEnable()
    {
        Title = "自定义皮肤功能";
        Description = "演示了如何使用自定义皮肤，也可以自己封装一些常用的style";
        customSkin = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/Scripts/Editor/Samples/CustomGUISkin/CustomGUISkin.guiskin");
    }

    GUISkin customSkin;

    protected override void OnGUI()
    {
        base.OnGUI();
        EditorGUILayout.LabelField("皮肤可以由Assets/Scripts/Editor/Samples/CustomGUISkin/CustomGUISkin 自定义");
        GUI.skin = customSkin;
        GUILayout.Button("I am the Skin's Button Style");

        EditorGUILayout.LabelField("可以封装自己的Style类来使用");
    }


  
}
