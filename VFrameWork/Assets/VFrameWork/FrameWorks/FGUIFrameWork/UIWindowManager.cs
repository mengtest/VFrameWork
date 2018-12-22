using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using LitJson;
using System;

namespace VFrameWork.Managers.FGUIManagers
{
	public class UIWindowManager:SingLeton<UIWindowManager>
    {
    	#region 数据成员
	    UIPackageManager uiPackageManager=new UIPackageManager();
	    
    	//界面栈,控制界面的显示与隐藏
    	Stack<BaseWindow> uiStack = new Stack<BaseWindow>();
	    
    	private List<BaseWindow> windowList=new List<BaseWindow>();
	    
	    private List<BaseWindow> openWindowList=new List<BaseWindow>();
    
    	#endregion
    	/// <summary>
    	/// 初始化FairyGUI的管理器
    	/// 将带有脚本的物体实例化至面板并将脚本存储
    	/// </summary>
    	/// <param name="uiWindowTypes">该界面要实例化的界面类型</param>
    	public void Init()
    	{
    		TextAsset ta = Resources.Load<TextAsset>("FGUI/Config/WindowInformation");
    		List<MenuInfo> windowInfos = JsonMapper.ToObject<List<MenuInfo>>(ta.text);
    		foreach (var item in windowInfos)
    		{
			    if (item.UiMenuType == UiMenuType.ResourceMenu)
			    {
				    uiPackageManager.AddPackage(item.PackageName,item.UiMenuType);
			    }
			    else
			    {
				    uiPackageManager.AddPackage(item.PackageName,item.UiMenuType);
				    Type type = Type.GetType(item.WindowName);
				    if (type == null)
				    {
					    Debug.Log("导入的"+item.PackageName+"包，并没有为其创建对应脚本文件，请创建"+item.WindowName+"脚本并继承自BaseWindow，错误代码：AA0011");
						#if UNITY_EDITOR
					    UnityEditor.EditorApplication.isPlaying = false;
						#endif
					    return;
				    }
				    object obj = type.Assembly.CreateInstance(type.Name);
				    BaseWindow bw = obj as BaseWindow;
				    bw.Copy(item);
				    GComponent view = UIPackage.CreateObject(bw.menuInfo.GetPackName(), bw.menuInfo.GetWindowName()).asCom;
				    bw.SetWindowView(view);
				    windowList.Add(bw);
			    }	    
    		}
    	}
    
    	/// <summary>
    	/// 通过UIWindowType获取WindowInfo
    	/// </summary>
    	/// <param name="uiWindowType">窗体类型</param>
    	/// <returns>该窗体的信息</returns>
    	public BaseWindow GetWindowInfo(UiWindowName uiWindowName)
    	{
    		foreach (var item in windowList)
    		{
    			if (item.menuInfo.UiWindowName == uiWindowName)
    				return item;
    		}
    		return null;
    	}
    	/// <summary>
    	/// 打开界面
    	/// </summary>
    	public void OpenWindow(UiWindowName uiWindowName)
    	{
    		
    		BaseWindow bw = null;
    		if (uiStack.Count > 0)
    		{
    			bw = uiStack.Peek();
    			bw.OnPause();
			    uiPackageManager.UnloadAssets(bw.menuInfo.PackageName);
    		}
		    bw = GetWindowInfo(uiWindowName);
		    if (!openWindowList.Contains(bw))
		    {
			    uiStack.Push(bw);
			    uiPackageManager.ReloadAssets(bw.menuInfo.PackageName);
			    bw.OnBeforeEnter();
			    bw.OnEnter();
			    openWindowList.Add(bw);
		    }
		    else
		    {
			    uiPackageManager.ReloadAssets(bw.menuInfo.PackageName);
			    bw.OnShow(); 
		    }
    	}
    
    	/// <summary>
    	/// 暂时隐藏界面界面
    	/// </summary>
    	public void HideWindow(UiWindowName uiWindowName)
    	{
    		
    		BaseWindow bw = GetWindowInfo(uiWindowName);
		    while(true&&uiStack.Count>0)
		    {
			    bw = uiStack.Pop();
			    bw.OnConceal();
			    uiPackageManager.UnloadAssets(bw.menuInfo.PackageName);
			    if (bw.menuInfo.UiWindowName == uiWindowName)
				    break;
		    }
		    if (uiStack.Count >= 1)
		    {
			    bw = uiStack.Peek();
			    uiPackageManager.ReloadAssets(bw.menuInfo.PackageName);
			    bw.OnResume();
		    }
    	}

	    public void DestoryAllWindow()
	    {
		    while (uiStack.Count > 0)
		    {
			    BaseWindow bw = uiStack.Pop();
			    bw.OnBeforeClose();
			    bw.OnClose();
			    uiPackageManager.UnloadAssets(bw.menuInfo.PackageName);
		    }

		    foreach (var VARIABLE in windowList)
		    {
			    uiPackageManager.RemovePackage(VARIABLE.menuInfo.GetPackName());
		    }
	    }
    }
}

