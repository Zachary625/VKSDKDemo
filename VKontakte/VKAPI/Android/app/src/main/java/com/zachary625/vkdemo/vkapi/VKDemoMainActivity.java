package com.zachary625.vkdemo.vkapi;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.unity3d.player.UnityPlayerActivity;
import com.vk.sdk.VKAccessToken;
import com.vk.sdk.VKCallback;
import com.vk.sdk.VKSdk;
import com.vk.sdk.api.VKError;

public class VKDemoMainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        VKontakteApi.MainActivity = this;
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        boolean vkResult = VKSdk.onActivityResult(requestCode, resultCode, data,
                new VKCallback<VKAccessToken>() {
                    @Override
                    public void onResult(VKAccessToken res)
                    {
                        VKontakteApi.UnitySendMessage("onActivityResult", VKontakteApi.ToJSONString(res));
                    }
                    @Override
                    public void onError(VKError error)
                    {
                        VKontakteApi.UnitySendMessage("onActivityError", VKontakteApi.ToJSONString(error));
                    }
                });
        if(!vkResult)
        {
            super.onActivityResult(requestCode, resultCode, data);
        }
    }

}
