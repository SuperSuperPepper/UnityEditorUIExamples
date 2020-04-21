using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SEditorTool
{
    public static class SEditorGUI
    {                 
        /// <summary>
        /// 绘制外框
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="thickness"></param>
        public static void DrawOutline(Rect rect, float thickness = 2.0f)
        {
            DrawOutline(rect, thickness, Color.white);
        }

        public static void DrawOutline(Rect rect, float thickness = 2.0f,Color? color= null)
        {
            color = color ?? Color.white;

            // Draw top selected lines.
            UnityEditor.EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), Color.white);

            // Draw bottom selected lines.
            UnityEditor.EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), Color.white);

            // Draw Left Selected Lines
            UnityEditor.EditorGUI.DrawRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), Color.white);

            // Draw Right Selected Lines
            UnityEditor.EditorGUI.DrawRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), Color.white);

        }


     
    }
}

