using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class AdRect
    {
        public float left; // 左上角原点x坐标 
        public float top; // 左上角原点y坐标
        public float width; // 展示区域宽度
        public float height; // 展示区域高度
        
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}