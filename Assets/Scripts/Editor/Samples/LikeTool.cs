using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
[EditorTool("Like")]
public class LikeTool : EditorTool
{


    GUIContent m_IconContent;

    void OnEnable()
    {
        //Debug.Log("这是一个单轴移动的工具");
        m_IconContent = new GUIContent()
        {
            image = Resources.Load<Texture2D>("like"),
            text = "扩展工具",
            tooltip = "扩展工具"
        };
    }

    public override GUIContent toolbarIcon
    {
        get { return m_IconContent; }
    }


    public override void OnToolGUI(EditorWindow window)
    {
        Debug.Log("You Are Good!!");
    }
}
