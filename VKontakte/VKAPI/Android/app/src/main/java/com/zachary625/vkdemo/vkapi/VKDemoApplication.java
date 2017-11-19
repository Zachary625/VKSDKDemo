package com.zachary625.vkdemo.vkapi;

import android.app.Application;
import android.support.annotation.Nullable;

import com.vk.sdk.VKAccessToken;
import com.vk.sdk.VKAccessTokenTracker;
import com.vk.sdk.VKSdk;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by zhang.chi on 2017/11/17.
 */

public class VKDemoApplication extends Application {
    VKAccessTokenTracker vkAccessTokenTracker = new VKAccessTokenTracker() {
        @Override
        public void onVKAccessTokenChanged(@Nullable VKAccessToken oldToken, @Nullable VKAccessToken newToken) {
            JSONObject json = new JSONObject();
            try
            {
                json.put("oldToken", VKontakteApi.ToJSONString(oldToken));
                json.put("newToken", VKontakteApi.ToJSONString(newToken));
            }
            catch (JSONException jsonException)
            {
            }
            VKontakteApi.UnitySendMessage("onVKAccessTokenChanged", json.toString());
        }
    };
    @Override
    public void onCreate() {
        super.onCreate();

        vkAccessTokenTracker.startTracking();
        VKSdk.initialize(this);

    }
}
