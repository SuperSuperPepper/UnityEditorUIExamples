using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class BeginFadeGroupWindow : SamplesBaseEditorWindow
{
    [MenuItem("SEditorTools/高级窗口")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<BeginFadeGroupWindow>();
        window.Show();
    }
    AnimBool m_ShowExtraFields;
    string m_String;
    Color m_Color = Color.white;
    int m_Number = 0;
    AnimationCurve curve = new AnimationCurve();
    bool showPosition = true;
    string status = "Select a GameObject";

    bool fold = true;
    Transform selectedTransform;

    void OnEnable()
    {
        m_ShowExtraFields = new AnimBool(true);
        m_ShowExtraFields.valueChanged.AddListener(Repaint);

        Title = "高级窗口";
        Description = "非基础的控件";

    }
    void OnInspectorUpdate()
    {
        this.Repaint();
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", m_ShowExtraFields.target);

        //Extra block that can be toggled on and off.
        if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel("Color");
            m_Color = EditorGUILayout.ColorField(m_Color);
            EditorGUILayout.PrefixLabel("Text");
            m_String = EditorGUILayout.TextField(m_String);
            EditorGUILayout.PrefixLabel("Number");
            m_Number = EditorGUILayout.IntSlider(m_Number, 0, 10);

            EditorGUI.indentLevel--;

            EditorGUILayout.LabelField("显示IndentLevel与PrefixLabel与Label的区别");

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("AnimationCurve");
            EditorGUILayout.CurveField(curve);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.EndFadeGroup();



        EditorGUILayout.LabelField("点击场景中的物体");

        showPosition = EditorGUILayout.Foldout(showPosition, status);
        if (showPosition)
            if (Selection.activeTransform)
            {
                Selection.activeTransform.position =
                    EditorGUILayout.Vector3Field("Position", Selection.activeTransform.position);
                status = Selection.activeTransform.name;                
            }

        if (!Selection.activeTransform)
        {
            status = "Select a GameObject";
            showPosition = false;
        }


        EditorGUILayout.LabelField("点击场景中的物体");
        EditorGUILayout.LabelField("可以通过InspectorTitlebar实现Component效果");
        if (Selection.activeGameObject)
        {

            selectedTransform = Selection.activeGameObject.transform;
            fold = EditorGUILayout.InspectorTitlebar(fold, selectedTransform);
            if (fold)
            {
                selectedTransform.position =
                    EditorGUILayout.Vector3Field("Position", selectedTransform.position);
                EditorGUILayout.Space();

                EditorGUILayout.Space();
                selectedTransform.localScale =
                    EditorGUILayout.Vector3Field("Scale", selectedTransform.localScale);
            }
        }


    }
}
