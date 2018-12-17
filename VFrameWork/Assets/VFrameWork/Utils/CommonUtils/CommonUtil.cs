using UnityEngine;
namespace VFrameWork.Utils.CommonUtils
{
    public class CommonUtil
    {
        public void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
    }
}