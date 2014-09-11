package com.broobu.hamdroid;

import android.app.Application;
import android.content.Context;
import android.util.Log;

/**
 * Created by ON8RL on 1/21/14.
 */
public class HamdroidApp extends Application {
    private static final String TAG = HamdroidApp.class.getSimpleName();
    private static HamdroidApp instance;


    @Override
    public void onCreate() {
        super.onCreate();
        Log.i(TAG, "HamdroidApp.onCreate was called");
        instance = this;
    }

    public static Context getContext() {
        return instance.getApplicationContext();
    }
}
