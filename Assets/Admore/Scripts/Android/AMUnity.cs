using UnityEngine;

namespace DefaultNamespace
{
    // Unity侧的listener
    public interface AdmoreInitListener
    {
        void OnInitSuccess();
        void OnInitFail(string errorMsg);
    }

    // 定义个 Adapter 来适配 AndroidJavaProxy 对象和 IDownloadListener
    public class ListenerAdapter : AndroidJavaProxy
    {
        private readonly AdmoreInitListener listener;

        public ListenerAdapter(AdmoreInitListener listener) : base(
            "com.plutus.common.admore.bridge.unity.listener.AMSDKUnityInitListener")
        {
            this.listener = listener;
        }
        void onInitSuccess()
        {
            listener.OnInitSuccess();
        }

        void onInitFail(string errorMsg)
        {
            listener.OnInitFail(errorMsg);
        }
    }


    public static class AMUnity
    {
        private static readonly AndroidJavaClass UnityBridge =
            new AndroidJavaClass("com.plutus.common.admore.bridge.unity.AMUnityBridge");

        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appKey"></param>
        /// <param name="userId"></param>
        /// <param name="listener"></param>
        public static void InitSDK(string appId, string appKey, string userId, AdmoreInitListener listener)
        {
            var listenerAdapter = new ListenerAdapter(listener);
            UnityBridge.CallStatic("initSDK", appId, appKey, userId, listenerAdapter);
        }

        /// <summary>
        /// 外部客户暂时不要调用
        /// </summary>
        /// <param name="isProxyEnabled"></param>
        /// <param name="isSkipEnabled"></param>
        /// <param name="isTargetPressureEnabled"></param>
        public static void InternalSetup(bool isProxyEnabled, bool isSkipEnabled, bool isTargetPressureEnabled)
        {
            UnityBridge.CallStatic("internalSetup", isProxyEnabled, isSkipEnabled, isTargetPressureEnabled);
        }

        /// <summary>
        /// 设置SDK log是否开启，调试包可以打开，线上包请关闭
        /// </summary>
        /// <param name="isDebug"></param>
        public static void SetLogDebug(bool isDebug)
        {
            UnityBridge.CallStatic("setLogDebug", isDebug);
        }
    }
}