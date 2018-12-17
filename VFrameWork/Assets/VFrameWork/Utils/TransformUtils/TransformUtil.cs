using UnityEngine;
namespace VFrameWork.Utils.TransformUtils
{
    static class TransformUtil
    {
        public static void ReSet(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        } 
        
        public static void SetLocalPos(this Transform transform, float x,float y, float z)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = localPos;
        }
        
        public static void SetLocalPosX(this Transform transform, float x)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosY(this Transform transform, float y)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosZ(this Transform transform, float z)
        {
            var localPos = transform.localPosition;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosXY(this Transform transform, float x, float y)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.y = y;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosXZ(this Transform transform, float x, float z)
        {
            var localPos = transform.localPosition;
            localPos.x = x;
            localPos.z = z;
            transform.localPosition = localPos;
        }

        public static void SetLocalPosYZ(this Transform transform, float y, float z)
        {
            var localPos = transform.localPosition;
            localPos.y = y;
            localPos.z = z;
            transform.localPosition = transform.localPosition;
        }
        public static void SetPos(this Transform transform, float x,float y, float z)
        {
            var Pos = transform.position;
            Pos.x = x;
            Pos.y = y;
            Pos.z = z;
            transform.position = Pos;
        }
        
        public static void SetPosX(this Transform transform, float x)
        {
            var Pos = transform.position;
            Pos.x = x;
            transform.localPosition = Pos;
        }

        public static void SetPosY(this Transform transform, float y)
        {
            var Pos = transform.position;
            Pos.y = y;
            transform.localPosition = Pos;
        }

        public static void SetPosZ(this Transform transform, float z)
        {
            var Pos = transform.position;
            Pos.z = z;
            transform.localPosition = Pos;
        }

        public static void SetPosXY(this Transform transform, float x, float y)
        {
            var Pos = transform.position;
            Pos.x = x;
            Pos.y = y;
            transform.localPosition = Pos;
        }

        public static void SetPosXZ(this Transform transform, float x, float z)
        {
            var Pos = transform.position;
            Pos.x = x;
            Pos.z = z;
            transform.localPosition = Pos;
        }

        public static void SetPosYZ(this Transform transform, float y, float z)
        {
            var Pos = transform.position;
            Pos.y = y;
            Pos.z = z;
            transform.localPosition = Pos;
        }
    }
}