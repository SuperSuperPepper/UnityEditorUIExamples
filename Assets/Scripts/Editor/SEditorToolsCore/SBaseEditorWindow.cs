using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SEditorTool
{
    public class SBaseEditorWindow<T> : EditorWindow where T : EditorWindow
    {
        [SerializeField]
        protected Rect m_LastPositon = new Rect();

        public static T GetWindow()
        {
            T window = (T)EditorWindow.GetWindow(typeof(T));
            return window;
        }

        virtual protected void OnEnable()
        {
            if (m_LastPositon.width * m_LastPositon.height == 0)
            {
                var att = GetAttribute();
                if (att != null)
                {
                    //Note:只能设置第一次打开，随后会被Unity缓存，进而变成上次打开的状态
                    m_LastPositon.size = att.DefaultSize;
                    this.position = m_LastPositon;
                }
            }
        }

        virtual protected void OnDisable()
        {
            m_LastPositon = this.position;
        }


        SEditorWindowAttr GetAttribute()
        {
            var attrs = Attribute.GetCustomAttributes(typeof(T));
            if (attrs==null||attrs.Length==0)
            {
                return null;
            }
            foreach (var item in attrs)
            {
                if (item is SEditorWindowAttr)
                {
                    return (SEditorWindowAttr)item;
                }
            }
            return null;
        }


        protected static string GetPrefs(string key)
        {
            var val = EditorPrefs.GetString(typeof(T).Name + "_" + key);
            return val;
        }

        protected static void SetPrefs(string key, string val)
        {
            EditorPrefs.SetString(typeof(T).Name + "_" + key, val);
        }

    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
    internal sealed class SEditorWindowAttr : Attribute
    {
        public Vector2Int DefaultSize { private set; get; }

        public SEditorWindowAttr(int width,int height)
        {
            DefaultSize = new Vector2Int(width, height);
        }
    }

}



