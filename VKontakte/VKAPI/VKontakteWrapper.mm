//
//  VKontakteWrapper.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#import "VKontakteWrapper.h"
#import <VKSdkFramework/VKSdkFramework.h>

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

+(char *)NSStringToChars:(NSString *)nsString
{
    if(nsString == nil)
    {
        return NULL;
    }
    const char * cStr = nsString.UTF8String;
    unsigned long length = strlen(cStr) + 1;
    char *result = new char[length];
    memset(result, 0, length);
    memcpy(result, cStr, length);
    return result;
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

-(BOOL)IsLoggedIn
{
    return [VKSdk isLoggedIn];
}
-(void)ForceLogout
{
    [VKSdk forceLogout];
}


@end
