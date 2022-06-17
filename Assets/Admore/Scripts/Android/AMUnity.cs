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
        /// <param name="appId"></param> 在admore后台获取
        /// <param name="appKey"></param> 在admore后台获取
        /// <param name="userId"></param> 当前用户的user id，每个用户都不相同，如果没有用户体系可以传空字符串，主要用来统计dau、人均收益等信息
        /// <param name="channel"></param> 当前apk的渠道信息
        /// <param name="listener"></param> 初始化结果回调
        public static void InitSDK(string appId, string appKey, string userId, string channel,
            AdmoreInitListener listener)
        {
            var listenerAdapter = new ListenerAdapter(listener);
            UnityBridge.CallStatic("initSDK", appId, appKey, userId, channel, listenerAdapter);
        }

        /// <summary>
        /// 设置SDK log是否开启，调试包可以打开，线上包请关闭
        /// </summary>
        /// <param name="isDebug"></param>
        public static void SetLogDebug(bool isDebug)
        {
            UnityBridge.CallStatic("setLogDebug", isDebug);
        }

        /// <summary>
        /// 设置微信SDK版本信息，可以优化联盟广告的ecpm，建议传入（可选，如果没有使用微信SDK，可以不传入）
        /// </summary>
        /// <param name="wxOpenSDKVersion"></param>
        public static void SetWxOpenSDKVersion(string wxOpenSDKVersion)
        {
            UnityBridge.CallStatic("setWxOpenSDKVersion", wxOpenSDKVersion);
        }

        /// <summary>
        /// 设置微信返回给用户的open id，传入后可以优化联盟广告的ecpm，建议传入（可选，如果没有使用微信SDK，可以不传入）
        /// </summary>
        /// <param name="wxOpenId"></param>
        public static void SetWxOpenId(string wxOpenId)
        {
            UnityBridge.CallStatic("setWxOpenId", wxOpenId);
        }

        /// <summary>
        /// 设置当前用户的经纬度信息，传入后可以优化联盟广告的ecpm，建议传入（可选）
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public static void SetLocation(string longitude, string latitude)
        {
            UnityBridge.CallStatic("setLocation", longitude, latitude);
        }

        /// <summary>
        /// 设置只出某一个广告平台的广告，只能在测试阶段开启，一定不要上线正式环境
        /// </summary>
        /// <param name="adnType"></param>
        public static void SetDebugAdnType(int adnType)
        {
            UnityBridge.CallStatic("setDebugAdnType", adnType);
        }
    }
}