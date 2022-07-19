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
