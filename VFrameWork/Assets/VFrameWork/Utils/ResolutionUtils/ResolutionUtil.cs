using UnityEngine;
namespace VFrameWork.Utils.ResolutionUtils
{
    public class ResolutionUtil
    {
        public float GetAspectRatio()
        {
            var isLandscape = Screen.width > Screen.height;
            return isLandscape ? (float)Screen.width / Screen.height : (float)Screen.height / Screen.width;
        }

        public bool IsPadResolution()
        {
            return InAspectRange(4.0f / 3);
        }

        public bool IsPhoneResolution()
        {
            return InAspectRange(16.0f / 9);
        }

        public bool IsPhone15Resolution()
        {
            return InAspectRange(3.0f / 2);
        }

        public bool IsiPhoneXResolution()
        {
            return InAspectRange(2436.0f / 1125);
        }

        public bool InAspectRange(float dstAspectRatio)
        {
            var aspect = GetAspectRatio();
            return aspect > (dstAspectRatio - 0.05) && aspect < (dstAspectRatio + 0.05);
        }
    }
}
