using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class ScopeWindow : SamplesBaseEditorWindow
{
    [MenuItem("SEditorTools/Scope弹窗")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<ScopeWindow>();
        window.Show();
    }

    private void OnEnable()
    {
        Title = "Scope菜单";
        Description = "本窗口主要讲Scope的范围模块使用，所有的Scope类都支持两种写法，看喜好来使用";

        m_ShowExtraFields = new AnimBool(true);
        m_ShowExtraFields.valueChanged.AddListener(Repaint);
    }

    GameObject go;
    AnimBool m_ShowExtraFields;

    bool toogle;
    BuildTargetGroup target;
    protected override void OnGUI()
    {
        base.OnGUI();

        EditorGUILayout.LabelField("ChangeCheck 框选中代码只有被操作后，判断内逻辑才会被执行，而不是每帧执行");
        EditorGUILayout.Space();
        EditorGUI.BeginChangeCheck();
        go =(GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);

        if (EditorGUI.EndChangeCheck())
        {
            Debug.Log("chanegr");
        }        

        ///和上述是等价的。
        using (var changerCheck = new EditorGUI.ChangeCheckScope())
        {
            go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);
            if (changerCheck.changed)
            {
                Debug.Log("use changer");
            }
        }


        EditorGUILayout.LabelField("DisabledGroup");
        EditorGUILayout.Space();
        EditorGUI.BeginDisabledGroup(false);
        EditorGUILayout.LabelField("Disable false");
        EditorGUI.EndDisabledGroup();
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.LabelField("Disable true");
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.LabelField("FadeGroup");
        EditorGUILayout.Space();
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", m_ShowExtraFields.target);
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUILayout.LabelField("FadeGroup");
            EditorGUILayout.LabelField("FadeGroup");
            EditorGUILayout.LabelField("FadeGroup");
            GUILayout.Button("Btn");

        }

        EditorGUILayout.EndFadeGroup();

        EditorGUILayout.LabelField("ToogleGroup");
        EditorGUILayout.Space();
        toogle = EditorGUILayout.BeginToggleGroup("ToogleGroup", toogle);

        EditorGUILayout.LabelField("ToogleGroup");
        EditorGUILayout.LabelField("ToogleGroup");
        EditorGUILayout.LabelField("ToogleGroup");
        GUILayout.Button("Btn");
        EditorGUILayout.EndToggleGroup();


        EditorGUILayout.LabelField("BuildTargetSelectionGrouping");
        EditorGUILayout.Space();

        target = EditorGUILayout.BeginBuildTargetSelectionGrouping();
        if (target == BuildTargetGroup.Android)
        {
            EditorGUILayout.LabelField("Android specific things");
        }
        if (target == BuildTargetGroup.Standalone)
        {
            EditorGUILayout.LabelField("Standalone specific things");
        }
        EditorGUILayout.EndBuildTargetSelectionGrouping();
    }
}
