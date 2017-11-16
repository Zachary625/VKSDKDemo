//
//  VKontakteUtility.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/15.
//

#import <Foundation/Foundation.h>
#import "VKontakteUtility.h"
@implementation VKontakteUtility

+(void)Log:(NSString * _Nonnull)log, ...
{
    va_list args;
    va_start(args, log);
    NSLogv(log, args);
    va_end(args);
}

static const char *s_VKGameObjectName = "VKListener";
+(void)UnitySendMessage:(const char *)method Parameter:(const char *)parameter
{
    [VKontakteUtility Log:@"UnitySendMessage(%@, %@, %@)",
     [NSString stringWithUTF8String:s_VKGameObjectName],
     [NSString stringWithUTF8String:method],
     [NSString stringWithUTF8String:parameter]];

    UnitySendMessage(s_VKGameObjectName, method, parameter);
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
+(NSString *)ToJSONString_NSStringDictionary:(NSDictionary *)dictionary
{
    if(dictionary == nil)
    {
        return @"";
    }
    NSData *data = [NSJSONSerialization dataWithJSONObject:data options:NSJSONWritingPrettyPrinted error:nil];
    NSString *json = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
    return json;
}


+(NSString *)ToJSONString_AuthorizationResult:(VKAuthorizationResult *)result
{
    if(result == nil)
    {
        return @"";
    }

    NSDictionary *data =
    @{
      @"state":[self ToJSONString_AuthorizationState:result.state],
      @"user":[self ToJSONString_User:result.user],
      @"token":[self ToJSONString_AccessToken:result.token],
    };
    return [self ToJSONString_NSStringDictionary:data];
}

+(NSString *)ToJSONString_User:(VKUser *)user
{
    if(user == nil)
    {
        return @"";
    }
    NSDictionary *data =
    @{
      @"id":user.id,
      @"nickname":user.nickname,
      @"first_name":user.first_name,
      @"last_name":user.last_name,
      @"screen_name":user.screen_name,
      @"bdate":user.bdate,
      @"sex":user.sex,
      @"description":user.description,
      @"status":user.status,
    };
    return [self ToJSONString_NSStringDictionary:data];
}

+(NSString *)ToJSONString_AccessToken:(VKAccessToken *)accessToken
{
    if(accessToken == nil)
    {
        return @"";
    }
    NSDictionary *data =
    @{
      @"userId":accessToken.userId,
      @"accessToken":accessToken.accessToken,
      @"secret":accessToken.secret,
      @"created":@(accessToken.created),
      @"expiresIn":@(accessToken.expiresIn),
      @"httpsRequired":@(accessToken.httpsRequired),
    };
    return [self ToJSONString_NSStringDictionary:data];

}

static NSDictionary *s_VKAuthorizationStateToNSString =
@{
  @(VKAuthorizationUnknown):@"VKAuthorizationUnknown",
  @(VKAuthorizationInitialized):@"VKAuthorizationInitialized",
  @(VKAuthorizationPending):@"VKAuthorizationPending",
  @(VKAuthorizationExternal):@"VKAuthorizationExternal",
  @(VKAuthorizationSafariInApp):@"VKAuthorizationSafariInApp",
  @(VKAuthorizationWebview):@"VKAuthorizationWebview",
  @(VKAuthorizationAuthorized):@"VKAuthorizationAuthorized",
  @(VKAuthorizationError):@"VKAuthorizationError",
};

+(NSString *)ToJSONString_AuthorizationState:(VKAuthorizationState)state
{
    return [s_VKAuthorizationStateToNSString objectForKey:@(state)];
}

+(NSString * _Nonnull)ToJSONString_Error:(VKError * _Nullable)error
{
    if(error == nil)
    {
        return @"";
    }
    
    NSDictionary *data =
    @{
      @"captchaSid":error.captchaSid,
      @"captchaImg":error.captchaImg,
      @"errorCode":@(error.errorCode),
      @"errorText":error.errorText,
      @"errorMessage":error.errorMessage,
      @"errorReason":error.errorReason,
      @"redirectUri":error.redirectUri,
      @"debugDescription":error.debugDescription,
      @"description":error.description,
    };
    return [self ToJSONString_NSStringDictionary:data];
}

@end
