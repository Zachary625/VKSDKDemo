//
//  VKontakteUtility.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/15.
//

#import <Foundation/Foundation.h>
#import "VKontakteUtility.h"

static inline NSString * _Nonnull _(NSString * _Nullable nsString)
{
    return (!nsString)? @"": nsString;
}

static inline NSString * _Nonnull _(NSNumber * _Nullable nsNumber)
{
    return (!nsNumber)? @"": [nsNumber stringValue];
}

@implementation VKontakteUtility

+(void)CopyStringToClipboard: (NSString * _Nullable)content
{
    if(content)
    {
        UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
        pasteboard.string = content;
    }
}

+(NSString * _Nonnull)CopyStringFromClipboard
{
    UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
    NSString *content = pasteboard.string;
    if(content)
    {
        return content;
    }
    return @"";
}

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

+(const char * _Nullable)NSStringToChars:(NSString *)nsString
{
    if(!nsString)
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
    if(!dictionary)
    {
        return @"";
    }
    NSData *data = [NSJSONSerialization dataWithJSONObject:dictionary options:0 error:nil];
    NSString *json = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
    return json;
}


+(NSString *)ToJSONString_AuthorizationResult:(VKAuthorizationResult *)result
{
    if(!result)
    {
        return @"";
    }

    NSDictionary *data =
    @{
      @"state":[self ToJSONString_AuthorizationState:[result state]],
      @"user":[self ToJSONString_User:[result user]],
      @"token":[self ToJSONString_AccessToken:[result token]],
    };
    return [self ToJSONString_NSStringDictionary:data];
}

+(NSString *)ToJSONString_User:(VKUser *)user
{
    if(!user)
    {
        return @"";
    }
    NSDictionary *data =
    @{
      @"id":_([user id]),
      @"nickname":_([user nickname]),
      @"first_name":_([user first_name]),
      @"last_name":_([user last_name]),
      @"screen_name":_([user screen_name]),
      @"bdate":_([user bdate]),
      @"sex":_([user sex]),
      @"status":_([user status]),
    };
    return [self ToJSONString_NSStringDictionary:data];
}

+(NSString *)ToJSONString_AccessToken:(VKAccessToken *)accessToken
{
    if(!accessToken)
    {
        return @"";
    }
    NSDictionary *data =
    @{
      @"userId":_([accessToken userId]),
      @"accessToken":_([accessToken accessToken]),
      @"secret":_([accessToken secret]),
      @"created":@([accessToken created]),
      @"expiresIn":@([accessToken expiresIn]),
      @"httpsRequired":@([accessToken httpsRequired]),
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
    if(!error)
    {
        return @"";
    }
    
    NSDictionary *data =
    @{
      @"captchaSid":_([error captchaSid]),
      @"captchaImg":_([error captchaImg]),
      @"errorCode":@([error errorCode]),
      @"errorText":_([error errorText]),
      @"errorMessage":_([error errorMessage]),
      @"errorReason":_([error errorReason]),
      @"redirectUri":_([error redirectUri]),
      @"debugDescription":_([error debugDescription ]),
    };
    return [self ToJSONString_NSStringDictionary:data];
}

@end
