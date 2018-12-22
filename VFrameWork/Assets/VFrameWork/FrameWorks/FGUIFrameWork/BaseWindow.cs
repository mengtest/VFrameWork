using UnityEngine;
using System.Collections;
using FairyGUI;

namespace VFrameWork.Managers.FGUIManagers
{
    public abstract class BaseWindow:Window
    {
        #region 数据成员
        //window信息类
        public MenuInfo menuInfo;
        #endregion
    
        /// <summary>
        /// 为windowInfo赋值
        /// </summary>
        /// <param name="oldWindow"></param>
        public void Copy(MenuInfo oldMenu)
        {
            menuInfo = new MenuInfo();
            menuInfo.PackageName = oldMenu.PackageName;
            menuInfo.WindowName = oldMenu.WindowName;
            menuInfo.UiWindowName = oldMenu.UiWindowName;
            menuInfo.UiMenuType = oldMenu.UiMenuType;
        }
    
        /// <summary>
        /// 设置窗体主组件
        /// </summary>
        /// <param name="view"></param>
        public void SetWindowView(GComponent view)
        {
            this.contentPane = view;
        }

        /// <summary>
        /// 创建前期 主要用于寻找view上的组件
        /// </summary>
        public abstract void OnBeforeEnter();

        /// <summary>
        /// 创建成功 主要用于逻辑注册,最后调用Show()方法
        /// </summary>
        public abstract void OnEnter();

        /// <summary>
        /// 当在该界面上再打开界面时,暂停该界面
        /// </summary>
        /// 
        public abstract void OnPause();

        /// <summary>
        /// 当在关闭该界面上打开的界面时,恢复该界面
        /// </summary>
        public abstract void OnResume();

        /// <summary>
        /// 暂时隐藏这个界面,最后调用Hide()方法
        /// </summary>
        public abstract void OnConceal();

        /// <summary>
        /// 暂时隐藏后重新打开界面,最后调用Show()方法
        /// </summary>
        public abstract void OnShow();

        /// <summary>
        /// 界面关闭之前,用于取消逻辑注册及取消引用
        /// </summary>
        public abstract void OnBeforeClose();

        /// <summary>
        /// 界面关闭,最后调用Hide()方法并将this.contentPane销毁
        /// </summary>
        public abstract void OnClose();
    }
}
