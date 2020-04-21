using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class DropdownWindow : SamplesBaseEditorWindow
{

    [MenuItem("SEditorTools/下拉弹窗")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<DropdownWindow>();
        window.Show();
    }

    private void OnEnable()
    {
        Title = "下拉菜单";
        Description = "本窗口主要讲dropdown 和 popup 功能";
    }
    int selectedSize = 1;
    string[] names = new string[] { "Normal", "Double", "Quadruple" };
    int[] sizes = { 1, 2, 4 };
    int selectedLayer = 0;
    string tag;

    int flags = 0;
    string[] options = new string[] { "CanJump", "CanShoot", "CanSwim" };

    protected override void OnGUI()
    {
        base.OnGUI();

        if (EditorGUILayout.DropdownButton(new GUIContent("DropDown"), FocusType.Keyboard))
        {
            GenericMenu menu = new GenericMenu();

            menu.AddItem(new GUIContent("第一个下拉按钮"),true,OnClickOne);            
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("第二个下拉按钮"), false, OnClickTwo);
            menu.AddItem(new GUIContent("第三个下拉按钮/层级设置"), false, null);

            menu.ShowAsContext();
        }

        EditorGUILayout.PrefixLabel("Popup");
        selectedSize = EditorGUILayout.Popup(selectedSize, names);
        selectedSize = EditorGUILayout.IntPopup("IntPopup: ", selectedSize, names, sizes);
        EditorGUILayout.LabelField("IntValue",selectedSize.ToString());

        EditorGUILayout.LabelField("注意两者的区别");

        selectedLayer = EditorGUILayout.LayerField("Layer for Objects:", selectedLayer);
        tag = EditorGUILayout.TagField("Tag for Object", tag);

        flags = EditorGUILayout.MaskField("Player Flags", flags, options);
    }

    private void OnClickOne()
    {
        Debug.Log("clik one");
    }

    private void OnClickTwo()
    {
        Debug.Log("clik one");
    }
}
