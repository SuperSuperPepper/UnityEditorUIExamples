using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SEditorTool
{
    public static class SEditorUtility
    {
        /// <summary>
        /// 定位资产路径
        /// </summary>
        /// <param name="path">相对路径即可</param>
        /// <returns></returns>
        public static bool GoToPath(string path)
        {
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
            if (obj == null)
            {
                return false;
            }
            UnityEditor.EditorGUIUtility.PingObject(obj);
            AssetDatabase.ReleaseCachedFileHandles();
            return true;
        }


        /// <summary>
        /// 设置文件可写
        /// </summary>
        public static bool SetFileWritable(string filePath)
        {
            string fullPath = filePath;
            //convert assetPath to absolute path
            if (fullPath.StartsWith("Assets/"))
                fullPath = AssetPathToAbsPath(fullPath);

            try
            {
                System.IO.FileAttributes fa = System.IO.File.GetAttributes(fullPath);
                if (fa.HasFlag(System.IO.FileAttributes.ReadOnly))
                {
                    System.IO.File.SetAttributes(fullPath, System.IO.FileAttributes.Normal);
                }
                return true;
            }
            catch (System.Exception e)
            {
                Debug.LogErrorFormat("Fail to set file({0}) be writable, for the reason of {1}", filePath, e.Message);
                return false;
            }
        }

        /// <summary>
        /// AssetDataBase Path -> Absolute Path
        /// </summary>
        /// <param name="assetPath"></param>
        /// <returns></returns>
        public static string AssetPathToAbsPath(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath))
                return "";
            return assetPath.Replace("Assets", Application.dataPath);
        }


        public static string FormatPath(string p)
        {
            return p.Replace(@"//", @"\").Replace(@"\", @"/").Replace(@"//", @"/");
        }

    }



}

