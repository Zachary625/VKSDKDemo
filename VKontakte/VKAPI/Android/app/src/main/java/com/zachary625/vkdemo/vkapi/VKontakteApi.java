package com.zachary625.vkdemo.vkapi;

import android.content.ClipData;
import android.content.ClipboardManager;
import android.content.Context;
import android.util.Log;

import com.unity3d.player.UnityPlayer;
import com.vk.sdk.VKAccessToken;
import com.vk.sdk.VKCallback;
import com.vk.sdk.VKSdk;
import com.vk.sdk.api.VKError;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Hashtable;

/**
 * Created by zhang.chi on 2017/11/17.
 */

public class VKontakteApi {

    public static VKDemoMainActivity MainActivity;

    private static final String LOG_TAG = "VKontakteApi";
    public static void Log(String string)
    {
        Log.i(LOG_TAG, string);
    }
    public static void LogError(String string)
    {
        Log.e(LOG_TAG, string);
    }

    public static void CopyStringToClipboard(String label, String content)
    {
        ClipboardManager cm = (ClipboardManager) MainActivity.getSystemService(Context.CLIPBOARD_SERVICE);
        cm.setPrimaryClip(ClipData.newPlainText(label, content));
    }

    public static String CopyStringFromClipboard()
    {
        ClipboardManager cm = (ClipboardManager) MainActivity.getSystemService(Context.CLIPBOARD_SERVICE);
        if(!cm.hasPrimaryClip())
        {
            return "";
        }
        ClipData clipData = cm.getPrimaryClip();
        if(clipData == null || clipData.getItemCount() <= 0)
        {
            return "";
        }
        for(int i = 0 ; i < clipData.getItemCount(); i++)
        {
            ClipData.Item item = clipData.getItemAt(i);
            if(item != null)
            {
                CharSequence content = item.getText();
                if(content != null && content.length() > 0)
                {
                    return content.toString();
                }
            }
        }
        return "";
    }

    public static void Login(String[] scope)
    {
        VKSdk.login(MainActivity, scope);
    }

    public static void Logout()
    {
        VKSdk.logout();
    }
    public static boolean IsLoggedIn()
    {
        return VKSdk.isLoggedIn();
    }
    public static void WakeUpSession()
    {
        VKSdk.wakeUpSession(MainActivity, new VKCallback<VKSdk.LoginState>() {
            @Override
            public void onResult(VKSdk.LoginState loginState) {
                UnitySendMessage("onWakeUpSessionResult", ToJSONString(loginState));
            }

            @Override
            public void onError(VKError vkError) {
                UnitySendMessage("onWakeUpSessionError", ToJSONString(vkError));
            }
        });
    }

    private static final String VK_LISTENER = "VKListener";
    public static void UnitySendMessage(String message, String parameter)
    {
        Log(String.format("VKontakteApi.UnitySendMessage(%s, %s, %s)", VK_LISTENER, message, parameter));
        UnityPlayer.UnitySendMessage(VK_LISTENER, message, parameter);
    }

    public static String ToJSONString(VKAccessToken accessToken)
    {
        if(accessToken == null)
        {
            return "";
        }
        JSONObject result = new JSONObject();
        try
        {
            result.put("userId", accessToken.userId);
            result.put("created", accessToken.created);
            result.put("expiresIn", accessToken.expiresIn);
            result.put("secret", accessToken.secret);
            result.put("email", accessToken.email);
            result.put("accessToken", accessToken.accessToken);
            result.put("httpsRequired", accessToken.httpsRequired);

        }
        catch(JSONException jsonException)
        {

        }
        return result.toString();
    }

    public static String ToJSONString(VKError error)
    {
        if(error == null)
        {
            return "";
        }
        JSONObject result = new JSONObject();
        try
        {
            result.put("captchaImg", error.captchaImg);
            result.put("captchaSid", error.captchaSid);
            result.put("errorCode", error.errorCode);
            result.put("errorMessage", error.errorMessage);
            result.put("errorReason", error.errorReason);
            result.put("redirectUri", error.redirectUri);
        }
        catch(JSONException jsonException)
        {

        }
        return result.toString();
    }
    private static final Hashtable<VKSdk.LoginState, String> LOGIN_STATE_TO_STRING = new Hashtable<VKSdk.LoginState, String>()
    {{
        put(VKSdk.LoginState.Unknown, "Unknown");
        put(VKSdk.LoginState.Pending, "Pending");
        put(VKSdk.LoginState.LoggedOut, "LoggedOut");
        put(VKSdk.LoginState.LoggedIn, "LoggedIn");
    }};
    public static String ToJSONString(VKSdk.LoginState loginState)
    {
        return LOGIN_STATE_TO_STRING.get(loginState);
    }

}
