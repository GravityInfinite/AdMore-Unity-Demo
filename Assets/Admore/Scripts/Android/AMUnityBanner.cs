using UnityEngine;

namespace DefaultNamespace
{
    // Unity侧的listener
    public interface AdmoreBannerListener
    {
        void onBannerAdLoaded(string placementId);

        void onBannerRenderFail(string placementId, int code, string msg);

        void onBannerAdShow(string placementId, string adSource, int width, int height);
        
        void onRenderSuccess(string placementId);
        
        void onDislikeRemoved(string placementId);

        void onBannerAdClicked(string placementId, string adSource);
    }

    public class BannerListenerAdapter : AndroidJavaProxy
    {
        private readonly AdmoreBannerListener listener;

        public BannerListenerAdapter(AdmoreBannerListener listener) : base(
            "com.plutus.common.admore.bridge.unity.listener.AMBannerListener")
        {
            this.listener = listener;
        }

        void onBannerAdLoaded(string placementId)
        {
            listener.onBannerAdLoaded(placementId);
        }

        void onBannerRenderFail(string placementId, int code, string msg)
        {
            listener.onBannerRenderFail(placementId, code, msg);
        }

        void onBannerAdShow(string placementId, string adSource, int width, int height)
        {
            listener.onBannerAdShow(placementId, adSource, width, height);
        }
        
        void onRenderSuccess(string placementId)
        {
            listener.onRenderSuccess(placementId);
        }

        void onDislikeRemoved(string placementId)
        {
            listener.onDislikeRemoved(placementId);
        }

        void onBannerAdClicked(string placementId, string adSource)
        {
            listener.onBannerAdClicked(placementId, adSource);
        }
    }


    public static class AMUnityBanner
    {
        private static readonly AndroidJavaClass UnityBridge =
            new AndroidJavaClass("com.plutus.common.admore.bridge.unity.AMBannerUnityBridge");
        /// <summary>
        /// 设置监听回调，必须调用
        /// </summary>
        /// <param name="listener"></param>
        public static void SetAdListener(AdmoreBannerListener listener)
        {
            var listenerAdapter = new BannerListenerAdapter(listener);
            UnityBridge.CallStatic("setAdListener", listenerAdapter);
        }

        /// <summary>
        /// 加载信息流广告
        /// </summary>
        /// <param name="placementId"></param>
        /// <param name="settings"></param>
        public static void Load(string placementId, string settings)
        {
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