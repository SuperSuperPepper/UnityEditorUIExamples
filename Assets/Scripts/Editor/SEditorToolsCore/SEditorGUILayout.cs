using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace SEditorTool
{
    public static class SEditorGUILayout
    {
        /// <summary>
        /// 画横线 支持进度条
        /// </summary>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <param name="progress"></param>
        public static void HLine(float height, Color color, float progress = 1.0f)
        {
            var rect = EditorGUILayout.GetControlRect(false, height);
            EditorGUI.DrawRect(new Rect(rect.x, rect.y, rect.width * progress, rect.height), color);
        }
    }
}

