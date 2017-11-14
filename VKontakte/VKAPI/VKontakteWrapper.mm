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
    return [VkSdk currentAppId];
}

-(NSString *)APIVersion
{
    return [VkSdk apiVersion];
}

-(BOOL)Initialized
{
    return [VkSdk initialized];
}

-(instancetype)InitializeWithAppID:(NSString *)appID
{
    return [VkSdk initializeWithAppId:appID];
}

-(void)Authorize:(NSArray *)permissions
{
    [VkSdk authorize:permissions];
}

-(BOOL)AppMayExists
{
    return [VkSdk vkAppMayExists];
}

-(BOOL)HasPermissions:(NSArray *)permissions
{
    return [VkSdk hasPermissions:permissions];
}

-(BOOL)IsLoggedIn
{
    return [VkSdk IsLoggedIn];
}
-(void)ForceLogout
{
    [VkSdk forceLogout];
}


@end
