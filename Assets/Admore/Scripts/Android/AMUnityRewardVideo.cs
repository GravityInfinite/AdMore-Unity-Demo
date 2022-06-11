using UnityEngine;

namespace DefaultNamespace
{
    // Unity侧的listener
    public interface AdmoreRewardVideoListener
    {
        void onRewardedVideoAdLoaded(string placementId);

        void onRewardedVideoAdFailed(string placementId, string adErrorStr);

        void onRewardedVideoAdPlayStart(string placementId, string adSource);

        void onRewardedVideoAdPlayEnd(string placementId, string adSource);

        void onRewardedVideoAdPlayFailed(string placementId, string adError, string adSource);

        void onRewardedVideoAdClosed(string placementId, string adSource);

        void onRewardedVideoAdPlayClicked(string placementId, string adSource);

        void onReward(string placementId, string adSource);
    }

    public class RewardVideoListenerAdapter : AndroidJavaProxy
    {
        private readonly AdmoreRewardVideoListener listener;

        public RewardVideoListenerAdapter(AdmoreRewardVideoListener listener) : base(
            "com.plutus.common.admore.bridge.unity.listener.AMRewardVideoListener")
        {
            this.listener = listener;
        }

        void onRewardedVideoAdLoaded(string placementId)
        {
            listener.onRewardedVideoAdLoaded(placementId);
        }

        void onRewardedVideoAdFailed(string placementId, string adErrorStr)
        {
            listener.onRewardedVideoAdFailed(placementId, adErrorStr);
        }

        void onRewardedVideoAdPlayStart(string placementId, string adSource)
        {
            listener.onRewardedVideoAdPlayStart(placementId, adSource);
        }

        void onRewardedVideoAdPlayEnd(string placementId, string adSource)
        {
            listener.onRewardedVideoAdPlayEnd(placementId, adSource);
        }

        void onRewardedVideoAdPlayFailed(string placementId, string adError, string adSource)
        {
            listener.onRewardedVideoAdPlayFailed(placementId, adError, adSource);
        }

        void onRewardedVideoAdClosed(string placementId, string adSource)
        {
            listener.onRewardedVideoAdClosed(placementId, adSource);
        }

        void onRewardedVideoAdPlayClicked(string placementId, string adSource)
        {
            listener.onRewardedVideoAdPlayClicked(placementId, adSource);
        }

        void onReward(string placementId, string adSource)
        {
            listener.onReward(placementId, adSource);
        }
    }


    public static class AMUnityRewardVideo
    {
        private static readonly AndroidJavaClass UnityBridge =
            new AndroidJavaClass("com.plutus.common.admore.bridge.unity.AMRewardedVideoUnityBridge");

        /// <summary>
        /// 设置监听回调，必须调用
        /// </summary>
        /// <param name="listener"></param>
        public static void SetAdListener(AdmoreRewardVideoListener listener)
        {
            var listenerAdapter = new RewardVideoListenerAdapter(listener);
            UnityBridge.CallStatic("setAdListener", listenerAdapter);
        }

        /// <summary>
        /// 加载激励视频广告
        /// </summary>
        /// <param name="placementId"></param>
        /// <param name="settings"></param>
        public static void Load(string placementId, string settings)
        {
            UnityBridge.CallStatic("load", placementId, settings);
        }

        /// <summary>
        /// 展示激励视频广告
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