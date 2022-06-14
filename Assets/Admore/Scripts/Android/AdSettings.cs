using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class AdSettings
    {
        public float width; // 广告展示区域宽
        public float height; // 广告展示区域高

        public static float AutoSize = 0; // 不要修改此值，否则展示可能出现异常
        
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}