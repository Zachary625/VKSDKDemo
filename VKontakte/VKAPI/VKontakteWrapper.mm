//
//  VKontakteWrapper.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#import "VKontakteWrapper.h"
#import <VKSdkFramework/VKSdkFramework.h>
#import "VKontakteSDKDelegate.h"
#import "VKontakteSDKUIDelegate.h"
#import "VKontakteUtility.h"

static VKontakteWrapper *s_Instance = nil;

@implementation VKontakteWrapper

+(VKontakteWrapper *)Instance
{
    if(s_Instance == nil)
    {
            s_Instance = [[VKontakteWrapper alloc] init];
    }
    return s_Instance;
}


-(NSString *)CurrentAppID
{
    return [VKSdk instance].currentAppId;
}

-(NSString *)APIVersion
{
    return [VKSdk instance].apiVersion;
}

-(BOOL)Initialized
{
    return [VKSdk initialized];
}

-(BOOL)InitializeWithAppID:(NSString *)appID
{
    VKSdk *vk = [VKSdk initializeWithAppId:appID];
    if(vk != nil)
    {
        [vk registerDelegate:[[VKontakteSDKDelegate alloc] init] ];
        [vk setUiDelegate:[[VKontakteSDKUIDelegate alloc] init] ];
        return TRUE;
    }
    else
    {
        return FALSE;
    }
}

-(void)Authorize:(NSArray *)permissions
{
    [VKSdk authorize:permissions];
}

-(BOOL)AppMayExists
{
    return [VKSdk vkAppMayExists];
}

-(void)WakeUpSession
{
    [VKSdk wakeUpSession:nil completeBlock:^(VKAuthorizationState state, NSError *error) {
        NSString *stateJson = [VKontakteUtility ToJSONString_AuthorizationState:state];
        [VKontakteUtility Log:stateJson];
        [VKontakteUtility UnitySendMessage:"vkSdkWakeUpSessionComplete" Parameter:[VKontakteUtility NSStringToChars:stateJson]];
    }];
}

-(BOOL)IsLoggedIn
{
    return [VKSdk isLoggedIn];
}
-(void)ForceLogout
{
    [VKSdk forceLogout];
}


@end
