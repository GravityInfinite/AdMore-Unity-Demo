using UnityEngine;

namespace DefaultNamespace
{
    // Unity侧的listener
    public interface AdmoreInterstitialListener
    {
        void onInterstitialAdLoaded(string placementId, bool isAdFilled);

        void onInterstitialAdVideoError(string placementId, string adErrorStr);

        void onInterstitialAdShow(string placementId, string adSource);

        void onInterstitialAdVideoStart(string placementId, string adSource);

        void onInterstitialAdVideoEnd(string placementId, string adSource);

        void onInterstitialAdClose(string placementId, string adSource);

        void onInterstitialAdClicked(string placementId, string adSource);

        void onReward(string placementId, string adSource);
    }

    public class InterstitialListenerAdapter : AndroidJavaProxy
    {
        private readonly AdmoreInterstitialListener listener;

        public InterstitialListenerAdapter(AdmoreInterstitialListener listener) : base(
            "com.plutus.common.admore.bridge.unity.listener.AMInterstitialListener")
        {
            this.listener = listener;
        }

        void onInterstitialAdLoaded(string placementId, bool isAdFilled)
        {
            listener.onInterstitialAdLoaded(placementId, isAdFilled);
        }

        void onInterstitialAdVideoError(string placementId, string adErrorStr)
        {
            listener.onInterstitialAdVideoError(placementId, adErrorStr);
        }

        void onInterstitialAdShow(string placementId, string adSource)
        {
            listener.onInterstitialAdShow(placementId, adSource);
        }

        void onInterstitialAdVideoStart(string placementId, string adSource)
        {
            listener.onInterstitialAdVideoStart(placementId, adSource);
        }

        void onInterstitialAdVideoEnd(string placementId, string adSource)
        {
            listener.onInterstitialAdVideoEnd(placementId, adSource);
        }

        void onInterstitialAdClose(string placementId, string adSource)
        {
            listener.onInterstitialAdClose(placementId, adSource);
        }

        void onInterstitialAdClicked(string placementId, string adSource)
        {
            listener.onInterstitialAdClicked(placementId, adSource);
        }

        void onReward(string placementId, string adSource)
        {
            listener.onReward(placementId, adSource);
        }
    }


    public static class AMUnityInterstitial
    {
        private static readonly AndroidJavaClass UnityBridge =
            new AndroidJavaClass("com.plutus.common.admore.bridge.unity.AMInterstitialUnityBridge");

        /// <summary>
        /// 设置监听回调，必须调用
        /// </summary>
        /// <param name="listener"></param>
        public static void SetAdListener(AdmoreInterstitialListener listener)
        {
            var listenerAdapter = new InterstitialListenerAdapter(listener);
            UnityBridge.CallStatic("setAdListener", listenerAdapter);
        }

        /// <summary>
        /// 加载插屏广告
        /// </summary>
        /// <param name="placementId"></param>
        /// <param name="settings"></param>
        public static void Load(string placementId, string settings)
        {
            UnityBridge.CallStatic("load", placementId, settings);
        }

        /// <summary>
        /// 展示插屏广告
        /// </summary>
        /// <param name="placementId"></param>
        public static void Show(string placementId)
        {
            UnityBridge.CallStatic("show", placementId);
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