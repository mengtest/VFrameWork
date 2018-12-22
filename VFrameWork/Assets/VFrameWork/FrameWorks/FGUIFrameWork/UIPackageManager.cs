using System;
using UnityEngine;
using System.Collections.Generic;
using FairyGUI;
namespace VFrameWork.Managers.FGUIManagers
{
    public class UIPackageManager
    {
        #region 数据成员

        //记录包是否Add的字典
        private Dictionary<string, bool> packageAddDict = new Dictionary<string, bool>();

        #endregion


        /// <summary>
        /// 加载FGUI的包
        /// </summary>
        /// <param name="packageName">UI包名</param>
        public void AddPackage(string packageName,UiMenuType uiMenuType)
        {
            if (CheckPackageHaveAdd(packageName) == false)
            {
                try
                {
                    UIPackage.AddPackage("FGUI/"+uiMenuType.ToString()+"/" + packageName + "/" + packageName);
                    packageAddDict.Add(packageName, true);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                    return;
                }

            }
        }

        /// <summary>
        /// 检查UI包是否已经包进来
        /// </summary>
        /// <param name="packageName">UI包名</param>
        public bool CheckPackageHaveAdd(string packageName)
        {
            return packageAddDict.ContainsKey(packageName);
        }

        /// <summary>
        /// 清理没有用到的UI包
        /// </summary>
        public void RemovePackage(string packageName)
        {
            try
            {
                UIPackage.RemovePackage(packageName);
                packageAddDict.Remove(packageName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                return;
            }
        }

        public void UnloadAssets(string packageName)
        {
            try
            {
                UIPackage package = UIPackage.GetByName(packageName);
                package.UnloadAssets();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            return;
        }

        public void ReloadAssets(string packageName)
        {
            try
            {
                UIPackage package = UIPackage.GetByName(packageName);
                package.ReloadAssets();
            }
            catch (Exception e)
            {
                Debug.LogError("资源加载错误，请检查是否在调用了UIWindowManager.Instance.DestoryAllWindow()方法后又调用了UIWindowManager.Instance.OpenWindow()方法，错误代码：AA0012");
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                return;
            }
           
        }
    }
}