using UnityEngine;
namespace VFrameWork.Utils.MathUtils
{
    public class MathUtil
    {
        public bool Percent(int percent)
        {    
            return Random.Range(0, 100) < percent;
        }
    }
}
