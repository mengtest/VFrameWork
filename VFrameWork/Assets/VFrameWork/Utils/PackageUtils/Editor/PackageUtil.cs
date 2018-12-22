using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using VFrameWork.Utils.EditorUtils;
namespace VFrameWork.Utils.PackageUtils
{
    public class PackageUtil
    {
        private static string GeneratePackageName()
        {
            return "VFramework_" + DateTime.Now.ToString("yyyyMMdd_HH");
        }

        [MenuItem("VFrameWork/Package %e", false, 1)]
        static void MenuClicked()
        {
            EditorUtil.ExportPackage("Assets", GeneratePackageName() + ".unitypackage");
            EditorUtil.OpenInFolder(Path.Combine(Application.dataPath, "../"));
        }
    }
}