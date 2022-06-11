using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class StatusInfo
    {
        public bool isLoading;
        public bool isReady;

        public static StatusInfo CreateFromJSON(string jsonStr)
        {
            return JsonUtility.FromJson<StatusInfo>(jsonStr);
        }
    }
}