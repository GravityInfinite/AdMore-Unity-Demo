using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class InitListener : AdmoreInitListener
{
    public void OnInitSuccess()
    {
        Debug.Log("AMUnity init success");
    }

    public void OnInitFail(string errorMsg)
    {
        Debug.Log("AMUnity init failed " + errorMsg);
    }
}

public class RewardListener : AdmoreRewardVideoListener
{
    private const string TAG = "RewardListener";

    public void onRewardedVideoAdLoaded(string placementId)
    {
        Debug.Log(TAG + " onRewardedVideoAdLoaded " + placementId);
    }

    public void onRewardedVideoAdFailed(string placementId, string adErrorStr)
    {
        Debug.Log(TAG + " onRewardedVideoAdFailed " + placementId + " " + adErrorStr);
    }

    public void onRewardedVideoAdPlayStart(string placementId, string adSource)
    {
        Debug.Log(TAG + " onRewardedVideoAdPlayStart " + placementId + " " + adSource);
    }

    public void onRewardedVideoAdPlayEnd(string placementId, string adSource)
    {
        Debug.Log(TAG + " onRewardedVideoAdPlayEnd " + placementId + " " + adSource);
    }

    public void onRewardedVideoAdPlayFailed(string placementId, string adError, string adSource)
    {
        Debug.Log(TAG + " onRewardedVideoAdPlayFailed " + placementId + " " + adError + " " + adSource);
    }

    public void onRewardedVideoAdClosed(string placementId, string adSource)
    {
        Debug.Log(TAG + " onRewardedVideoAdClosed " + placementId + " " + adSource);
    }

    public void onRewardedVideoAdPlayClicked(string placementId, string adSource)
    {
        Debug.Log(TAG + " onRewardedVideoAdPlayClicked " + placementId + " " + adSource);
    }

    public void onReward(string placementId, string adSource)
    {
        Debug.Log(TAG + " onReward " + placementId + " " + adSource);
    }
}

public class InterstitialListener : AdmoreInterstitialListener
{
    private const string TAG = "InterstitialListener";

    public void onInterstitialAdLoaded(string placementId)
    {
        Debug.Log(TAG + " onInterstitialAdLoaded " + placementId);
    }

    public void onInterstitialAdVideoError(string placementId, string adErrorStr)
    {
        Debug.Log(TAG + " onInterstitialAdVideoError " + placementId + " " + adErrorStr);
    }

    public void onInterstitialAdShow(string placementId, string adSource)
    {
        Debug.Log(TAG + " onInterstitialAdShow " + placementId + " " + adSource);
    }

    public void onInterstitialAdVideoStart(string placementId, string adSource)
    {
        Debug.Log(TAG + " onInterstitialAdVideoStart " + placementId + " " + adSource);
    }

    public void onInterstitialAdVideoEnd(string placementId, string adSource)
    {
        Debug.Log(TAG + " onInterstitialAdVideoEnd " + placementId + " " + adSource);
    }

    public void onInterstitialAdClose(string placementId, string adSource)
    {
        Debug.Log(TAG + " onInterstitialAdClose " + placementId + " " + adSource);
    }

    public void onInterstitialAdClicked(string placementId, string adSource)
    {
        Debug.Log(TAG + " onInterstitialAdClicked " + placementId + " " + adSource);
    }

    public void onReward(string placementId, string adSource)
    {
        Debug.Log(TAG + " onReward " + placementId + " " + adSource);
    }
}


public class NativeListener : AdmoreNativeListener
{
    private const string TAG = "NativeListener";

    public void onNativeAdLoaded(string placementId)
    {
        Debug.Log(TAG + " onNativeAdLoaded " + placementId);
    }

    public void onNativeAdVideoError(string placementId, string adErrorStr)
    {
        Debug.Log(TAG + " onNativeAdVideoError " + placementId + " " + adErrorStr);
    }

    public void onNativeAdShow(string placementId, string adSource, int width, int height)
    {
        Debug.Log(TAG + " onNativeAdShow " + placementId + " " + adSource + " " + width + " " + height);
    }

    public void onNativeAdVideoStart(string placementId, string adSource)
    {
        Debug.Log(TAG + " onNativeAdVideoStart " + placementId + " " + adSource);
    }

    public void onNativeAdVideoEnd(string placementId, string adSource)
    {
        Debug.Log(TAG + " onNativeAdVideoEnd " + placementId + " " + adSource);
    }

    public void onNativeAdVideoProgress(string placementId, int progress)
    {
        Debug.Log(TAG + " onNativeAdVideoProgress " + placementId + " " + progress);
    }

    public void onRenderSuccess(string placementId)
    {
        Debug.Log(TAG + " onRenderSuccess " + placementId);
    }
    
    public void onRenderFail(string placementId, int code, string msg)
    {
        Debug.Log(TAG + " onRenderSuccess " + placementId + " " + code + " " + msg);
    }

    public void onDislikeRemoved(string placementId)
    {
        Debug.Log(TAG + " onDislikeRemoved " + placementId);
    }

    public void onNativeAdClicked(string placementId, string adSource)
    {
        Debug.Log(TAG + " onNativeAdClicked " + placementId + " " + adSource);
    }
}


public class BannerListener : AdmoreBannerListener
{
    private const string TAG = "BannerListener";

    public void onBannerAdLoaded(string placementId)
    {
        Debug.Log(TAG + " " + placementId);
    }

    public void onBannerRenderFail(string placementId, int code, string msg)
    {
        Debug.Log(TAG + " " + placementId + " " + code + " " + msg) ;
    }

    public void onBannerAdShow(string placementId, string adSource, int width, int height)
    {
        Debug.Log(TAG + " " + placementId + " " + adSource + " " + width + " " + height) ;
    }

    public void onRenderSuccess(string placementId)
    {
        Debug.Log(TAG + " " + placementId) ;
    }

    public void onDislikeRemoved(string placementId)
    {
        Debug.Log(TAG + " " + placementId) ;
    }

    public void onBannerAdClicked(string placementId, string adSource)
    {
        Debug.Log(TAG + " " + placementId + " " + adSource) ;
    }
}

public class AdmoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitSDK()
    {
        Debug.Log("init sdk clicked");
        AMUnity.SetLogDebug(true);
        AMUnity.InitSDK(Constant.APP_ID, Constant.APP_KEY, Constant.USER_ID, new InitListener());
    }

    public void LoadReward()
    {
        Debug.Log("load reward clicked");
        AMUnityRewardVideo.SetAdListener(new RewardListener());
        AMUnityRewardVideo.Load(Constant.REWARD_PLACEMENT_ID, "{}");
    }

    public void ShowReward()
    {
        Debug.Log("show reward clicked");
        Debug.Log("is ready " + AMUnityRewardVideo.IsAdReady(Constant.REWARD_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityRewardVideo.IsAdExpired(Constant.REWARD_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityRewardVideo.CheckAdStatus(Constant.REWARD_PLACEMENT_ID));
        if (AMUnityRewardVideo.IsAdReady(Constant.REWARD_PLACEMENT_ID))
        {
            if (AMUnityRewardVideo.IsAdExpired(Constant.REWARD_PLACEMENT_ID))
            {
                // 调用show方法，并且在加载成功之后，请主动调用Show方法
                AMUnityRewardVideo.Load(Constant.REWARD_PLACEMENT_ID, "{}");
            }
            else
            {
                AMUnityRewardVideo.Show(Constant.REWARD_PLACEMENT_ID);
            }
        }
        else
        {
            var statusStr = AMUnityRewardVideo.CheckAdStatus(Constant.REWARD_PLACEMENT_ID);
            // json处理一下
            var statusInfo = StatusInfo.CreateFromJSON(statusStr);
            if (statusInfo.isLoading)
            {
                // 展示加载中的弹窗，可以做一些处理，优化用户体验，设置在加载完成后，自动调用Show方法
                Debug.Log("loading");
            }
            else
            {
                // 没有在加载中，此时需要调用加载的逻辑，并且展示加载中的弹窗通知用户，并在加载完成后，自动调用Show方法
                AMUnityRewardVideo.Load(Constant.REWARD_PLACEMENT_ID, "{}");
            }
        }
    }

    public void LoadInterstitial()
    {
        Debug.Log("load interstitial clicked");
        AMUnityInterstitial.SetAdListener(new InterstitialListener());
        AMUnityInterstitial.Load(Constant.INTERSTITIAL_PLACEMENT_ID, "{}");
    }

    public void ShowInterstitial()
    {
        Debug.Log("show interstitial clicked");
        Debug.Log("is ready " + AMUnityInterstitial.IsAdReady(Constant.INTERSTITIAL_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityInterstitial.IsAdExpired(Constant.INTERSTITIAL_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityInterstitial.CheckAdStatus(Constant.INTERSTITIAL_PLACEMENT_ID));
        if (!AMUnityInterstitial.IsAdReady(Constant.INTERSTITIAL_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityInterstitial.Load(Constant.INTERSTITIAL_PLACEMENT_ID, "{}");
        } else if (AMUnityInterstitial.IsAdExpired(Constant.INTERSTITIAL_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityInterstitial.Load(Constant.INTERSTITIAL_PLACEMENT_ID, "{}");
        }
        else
        {
            // 直接展示
            AMUnityInterstitial.Show(Constant.INTERSTITIAL_PLACEMENT_ID);
        }
    }

    public void LoadNative()
    {
        Debug.Log("load Native clicked");
        AMUnityNative.SetAdListener(new NativeListener());
        AMUnityNative.Load(Constant.NATIVE_PLACEMENT_ID, "{}");
    }

    public void ShowNative()
    {
        Debug.Log("show Native clicked");
        Debug.Log("is ready " + AMUnityNative.IsAdReady(Constant.NATIVE_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityNative.IsAdExpired(Constant.NATIVE_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityNative.CheckAdStatus(Constant.NATIVE_PLACEMENT_ID));
        if (!AMUnityNative.IsAdReady(Constant.NATIVE_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityNative.Load(Constant.NATIVE_PLACEMENT_ID, "{}");
        } else if (AMUnityNative.IsAdExpired(Constant.NATIVE_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityNative.Load(Constant.NATIVE_PLACEMENT_ID, "{}");
        }
        else
        {
            AMUnityNative.Show(Constant.NATIVE_PLACEMENT_ID);
        }
    }


    public void RemoveNative()
    {
        Debug.Log("remove Native clicked");
        AMUnityNative.Remove(Constant.NATIVE_PLACEMENT_ID);
    }
    
    
    public void LoadBanner()
    {
        Debug.Log("load Banner clicked");
        AMUnityBanner.SetAdListener(new BannerListener());
        AMUnityBanner.Load(Constant.BANNER_PLACEMENT_ID, "{}");
    }

    public void ShowBanner()
    {
        Debug.Log("show Banner clicked");
        Debug.Log("is ready " + AMUnityBanner.IsAdReady(Constant.BANNER_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityBanner.IsAdExpired(Constant.BANNER_PLACEMENT_ID));
        Debug.Log("is ready " + AMUnityBanner.CheckAdStatus(Constant.BANNER_PLACEMENT_ID));
        if (!AMUnityBanner.IsAdReady(Constant.BANNER_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityBanner.Load(Constant.BANNER_PLACEMENT_ID, "{}");
        } else if (AMUnityBanner.IsAdExpired(Constant.BANNER_PLACEMENT_ID))
        {
            // 重新load广告
            AMUnityBanner.Load(Constant.BANNER_PLACEMENT_ID, "{}");
        }
        else
        {
            AMUnityBanner.Show(Constant.BANNER_PLACEMENT_ID);
        }
    }


    public void RemoveBanner()
    {
        Debug.Log("remove Banner clicked");
        AMUnityBanner.Remove(Constant.BANNER_PLACEMENT_ID);
    }
}