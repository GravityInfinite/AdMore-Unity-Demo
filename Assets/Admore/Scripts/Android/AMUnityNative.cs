using UnityEngine;

namespace DefaultNamespace
{
    // Unity侧的listener
    public interface AdmoreNativeListener
    {
        void onNativeAdLoaded(string placementId, bool isAdFilled);

        void onNativeAdVideoError(string placementId, string adErrorStr);

        void onNativeAdShow(string placementId, string adSource, int width, int height);

        void onNativeAdVideoStart(string placementId, string adSource);

        void onNativeAdVideoEnd(string placementId, string adSource);
        
        void onNativeAdVideoProgress(string placementId, int progress);

        void onRenderSuccess(string placementId);

        void onRenderFail(string placementId, int code, string msg);

        void onDislikeRemoved(string placementId);

        void onNativeAdClicked(string placementId, string adSource);
    }

    public class NativeListenerAdapter : AndroidJavaProxy
    {
        private readonly AdmoreNativeListener listener;

        public NativeListenerAdapter(AdmoreNativeListener listener) : base(
            "com.plutus.common.admore.bridge.unity.listener.AMNativeListener")
        {
            this.listener = listener;
        }

        void onNativeAdLoaded(string placementId, bool isAdFilled)
        {
            listener.onNativeAdLoaded(placementId, isAdFilled);
        }

        void onNativeAdVideoError(string placementId, string adErrorStr)
        {
            listener.onNativeAdVideoError(placementId, adErrorStr);
        }

        void onNativeAdShow(string placementId, string adSource, int width, int height)
        {
            listener.onNativeAdShow(placementId, adSource, width, height);
        }

        void onNativeAdVideoStart(string placementId, string adSource)
        {
            listener.onNativeAdVideoStart(placementId, adSource);
        }

        void onNativeAdVideoEnd(string placementId, string adSource)
        {
            listener.onNativeAdVideoEnd(placementId, adSource);
        }

        void onNativeAdVideoProgress(string placementId, int progress)
        {
            listener.onNativeAdVideoProgress(placementId, progress);
        }

        void onRenderSuccess(string placementId)
        {
            listener.onRenderSuccess(placementId);
        }
        
        void onRenderFail(string placementId, int code, string msg)
        {
            listener.onRenderFail(placementId, code, msg);
        }

        void onDislikeRemoved(string placementId)
        {
            listener.onDislikeRemoved(placementId);
        }

        void onNativeAdClicked(string placementId, string adSource)
        {
            listener.onNativeAdClicked(placementId, adSource);
        }
    }


    public static class AMUnityNative
    {
        private static readonly AndroidJavaClass UnityBridge =
            new AndroidJavaClass("com.plutus.common.admore.bridge.unity.AMNativeUnityBridge");
        /// <summary>
        /// 设置监听回调，必须调用
        /// </summary>
        /// <param name="listener"></param>
        public static void SetAdListener(AdmoreNativeListener listener)
        {
            var listenerAdapter = new NativeListenerAdapter(listener);
            UnityBridge.CallStatic("setAdListener", listenerAdapter);
        }

        /// <summary>
        /// 加载信息流广告
        /// </summary>
        /// <param name="placementId"></param>
        /// <param name="settings"></param>
        public static void Load(string placementId, string settings)
        {
            Debug.Log("load " + settings);
            UnityBridge.CallStatic("load", placementId, settings);
        }

        /// <summary>
        /// 展示信息流广告
        /// </summary>
        /// <param name="placementId"></param>
        public static void Show(string placementId)
        {
            UnityBridge.CallStatic("show", placementId);
        }
        
        
        /// <summary>
        /// 在指定位置展示信息流广告
        /// </summary>
        /// <param name="placementId"></param>
        /// <param name="rectJson"></param>
        public static void ShowInRectangle(string placementId, string rectJson)
        {
            UnityBridge.CallStatic("showInRectangle", placementId, rectJson);
        }

        /// <summary>
        /// 在底部展示信息流广告，不支持展示在顶部
        /// </summary>
        /// <param name="placementId"></param>
        public static void ShowInBottom(string placementId)
        {
            UnityBridge.CallStatic("showInBottom", placementId);
        }
        
        /// <summary>
        /// 主动移除信息流广告
        /// </summary>
        /// <param name="placementId"></param>
        public static void Remove(string placementId)
        {
            UnityBridge.CallStatic("remove", placementId);
        }

        /// <summary>
        /// 检查广告状态，返回一个json string
        /// </summary>
        /// <param name="placementId"></param>
        /// <returns></returns>
        public static string CheckAdStatus(string placementId)
        {
            return UnityBridge.CallStatic<string>("checkAdStatus", placementId);
        }

        /// <summary>
        /// 判断当前广告是否ready
        /// </summary>
        /// <param name="placementId"></param>
        /// <returns></returns>
        public static bool IsAdReady(string placementId)
        {
            return UnityBridge.CallStatic<bool>("isAdReady", placementId);
        }

        /// <summary>
        /// 判断当前广告是否过期
        /// </summary>
        /// <param name="placementId"></param>
        /// <returns></returns>
        public static bool IsAdExpired(string placementId)
        {
            return UnityBridge.CallStatic<bool>("isAdExpired", placementId);
        }
    }
}