using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("扩展 Tool")]
class CustomTool : EditorTool
{

    [SerializeField]
    Texture2D m_ToolIcon;

    GUIContent m_IconContent;

    void OnEnable()
    {
        //Debug.Log("这是一个单轴移动的工具");
        m_IconContent = new GUIContent()
        {
            image = Resources.Load<Texture2D>("Arrow"),
            text = "扩展工具",
            tooltip = "扩展工具"
        };
    }

    public override GUIContent toolbarIcon
    {
        get { return m_IconContent; }
    }


    // This is called for each window that your tool is active in. Put the functionality of your tool here.
    public override void OnToolGUI(EditorWindow window)
    {
        EditorGUI.BeginChangeCheck();

        Vector3 position = Tools.handlePosition;

        using (new Handles.DrawingScope(Color.green))
        {
            position = Handles.Slider(position, Vector3.right);
        }

        if (EditorGUI.EndChangeCheck())
        {
            Vector3 delta = position - Tools.handlePosition;

            Undo.RecordObjects(Selection.transforms, "Move Platform");

            foreach (var transform in Selection.transforms)
                transform.position += delta;
        }
    }
}