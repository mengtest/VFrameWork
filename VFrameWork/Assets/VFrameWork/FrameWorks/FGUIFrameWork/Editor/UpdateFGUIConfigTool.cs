using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEditor;
using UnityEngine;

namespace VFrameWork.Managers.FGUIManagers
{
    public class UpdateFGUIConfigTool
    {
        private static string RESOUECEMENUPATH = "Assets/Resources/FGUI/ResourceMenu";
        private static string WINDOWMENUPATH = "Assets/Resources/FGUI/WindowMenu";
        private static string UIWINDOWNAMETEMPLATE = "Assets/Resources/FGUI/Config/UiWindowNameTemplate.txt";
        private static string UIWINDOWNAME = "Assets/VFrameWork/FrameWorks/FGUIFrameWork/UiWindowName.cs";
        private static string WINDOWINFORMATION = "Assets//Resources/FGUI/Config/WindowInformation.json";
        private static List<MenuInfo> MenuInfo = new List<MenuInfo>();
        [MenuItem("VFrameWork/UpdateFGUIConfig %u")]
        public static void MenuClicked()
        {
            MenuInfo.Clear();
            try
            {
                EditorApplication.ExecuteMenuItem("Window/FairyGUI - Refresh Packages And Panels");
            }
            catch (Exception e)
            {
               Debug.LogError("更新FairyGUI包失败，请检查是否导入FairyGUI-SDK。错误编码：AA0010");
               return;
            }

            List<MenuInfo> menuInfos=new List<MenuInfo>();
            List<string> enumItems=new List<string>();
            
            string[] directoryInfo=null;
            try
            {
                directoryInfo=Directory.GetDirectories(RESOUECEMENUPATH);
            }
            catch (Exception e)
            {
                Debug.LogError("获取FairyGUI资源包失败，请确保存在"+RESOUECEMENUPATH+"目录。错误编码：AA0020");
                return;
            }
            for (int i = 0; i < directoryInfo.Length; i++)
            {
                string[] temps = directoryInfo[i].Split('/');
                MenuInfo menuInfo=new MenuInfo();
                menuInfo.PackageName = temps[temps.Length-1];
                menuInfo.WindowName = temps[temps.Length-1];
                menuInfo.UiMenuType = UiMenuType.ResourceMenu;
                menuInfos.Add(menuInfo);
                enumItems.Add(menuInfo.WindowName);
            }      
            
            directoryInfo=null;
            try
            {
                directoryInfo=Directory.GetDirectories(WINDOWMENUPATH);
            }
            catch (Exception e)
            {
                Debug.LogError("获取FairyGUI窗体包失败，请确保存在"+WINDOWMENUPATH+"目录错误编码：AA0021");
                return;
            }
            
            for (int i = 0; i < directoryInfo.Length; i++)
            {
                string[] temps = directoryInfo[i].Split('/');
                MenuInfo menuInfo=new MenuInfo();
                menuInfo.PackageName = temps[temps.Length-1];
                menuInfo.WindowName = temps[temps.Length-1]+"Window";
                menuInfo.UiMenuType = UiMenuType.WindowMenu;
                menuInfos.Add(menuInfo);
                enumItems.Add(menuInfo.WindowName);
            }

            CreateUiWindowNamEumeClass(enumItems);
            AssetDatabase.Refresh();
            for (int i = 0; i < menuInfos.Count; i++)
            {
                bool equal = false;
                while (!equal)
                {
                    try
                    {
                        menuInfos[i].UiWindowName = (UiWindowName)Enum.Parse(typeof(UiWindowName),menuInfos[i].WindowName);
                    }
                    catch (Exception e)
                    {
                        equal = false;
                    }

                    equal = true;
                }
                
            }

            CreateWindowInformation(menuInfos);
            AssetDatabase.Refresh();
            Debug.Log("配置文件更新完成！");
        }

        private static void CreateUiWindowNamEumeClass(List<string> enumItems)
        {
            TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>(UIWINDOWNAMETEMPLATE);
            if (ta == null)
            {
                Debug.LogError("未能成功加载[UiWindowNameTemplate.txt]枚举模板，请检查"+UIWINDOWNAMETEMPLATE+"是否存在，错误代码：AA0022");
                return;
            }
            StringBuilder sb=new StringBuilder(ta.ToString());
            StringBuilder temp=new StringBuilder();
            foreach (var VARIABLE in enumItems)
            {
                temp.Append(VARIABLE+ ",\n       ");
            }
            sb.Replace("$enumItem", temp.ToString());
            if (File.Exists(UIWINDOWNAME))
            {
                File.Delete(UIWINDOWNAME);
            }
            FileStream fileStream=new FileStream(UIWINDOWNAME,FileMode.Create,FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            fileStream.Write(bytes,0,bytes.Length);
            fileStream.Close();
        }

        private static void CreateWindowInformation(List<MenuInfo> menuInfos)
        {
            string json = JsonMapper.ToJson(menuInfos);
            if (File.Exists(WINDOWINFORMATION))
            {
                File.Delete(WINDOWINFORMATION);
            }
            FileStream fileStream=new FileStream(WINDOWINFORMATION,FileMode.Create,FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            fileStream.Write(bytes,0,bytes.Length);
            fileStream.Close();
        }
    }
}