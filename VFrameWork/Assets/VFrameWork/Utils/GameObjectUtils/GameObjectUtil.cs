using UnityEngine;
namespace VFrameWork.Utils.GameObjectUtils
{
    static class GameObjectUtil
    {
        public static void Show(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void Hide(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}