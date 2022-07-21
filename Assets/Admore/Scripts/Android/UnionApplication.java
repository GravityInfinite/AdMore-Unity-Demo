package com.plutus.mediation;

import android.content.Context;
import androidx.multidex.MultiDexApplication;
import com.plutus.common.core.GravitySDK;

public class UnionApplication  extends MultiDexApplication {

    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(base);
        // 在应用的application类中执行
        System.out.println("admore gravity sdk attach");
        // 上线之前，如果需要查看调试日志，请这样初始化
//         GravitySDK.onAttachBaseContext(base, true, "debug", "master");
        // 上线之后，请关闭调试模式如下：
        GravitySDK.onAttachBaseContext(base, false, "release", "master");
    }
    
    @Override
    public void onCreate() {
        super.onCreate();
        // 在应用的application类中执行
        System.out.println("admore gravity sdk create");
        GravitySDK.onCreate(this);
    }
}
