using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using System;

namespace VFrameWork.Managers.FGUIManagers
{
   public class MenuInfo
   {
       #region 数据成员
       //包名
       private string _packageName;
       public string PackageName
       {
           get
           {
               return _packageName;
           }
   
           set
           {
               _packageName = value;
           }
       }
       //窗体名
       private string _windowName;
       public string WindowName
       {
           get
           {
               return _windowName;
           }
   
           set
           {
               _windowName = value;
           }
       }
       //window名称
       private UiWindowName _uiWindowName;
       public UiWindowName UiWindowName
       {
           get
           {
               return _uiWindowName;
           }
           set
           {
               _uiWindowName = value;
           }
       }
       //menuType
       private UiMenuType _uiMenuType;
       public UiMenuType UiMenuType
       {
           get
           {
               return _uiMenuType;
           }
           set
           {
               _uiMenuType = value;
           }
       }
       #endregion
   
       /// <summary>
       /// 获取当前窗体的包名
       /// </summary>
       /// <returns></returns>
       public string GetPackName()
       {
           return PackageName;
       }
   
       /// <summary>
       /// 获取当前窗体的名字
       /// </summary>
       /// <returns></returns>
       public string GetWindowName()
       {
           return WindowName;
       }
   } 
}
