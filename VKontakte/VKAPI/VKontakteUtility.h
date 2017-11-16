//
//  VKontakteUtility.h
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/15.
//

#ifndef VKontakteUtility_h
#define VKontakteUtility_h


#endif /* VKontakteUtility_h */

#import <VKSdkFramework/VKSdkFramework.h>

@interface VKontakteUtility: NSObject
+(void)CopyStringToClipboard:(NSString * _Nullable)content;
+(NSString * _Nonnull)CopyStringFromClipboard;
+(void)Log:(NSString * _Nonnull)log, ...;
+(void)UnitySendMessage:(const char * _Nonnull)method Parameter:(const char * _Nullable)parameter;
+(const char * _Nullable)NSStringToChars:(NSString * _Nullable)nsString;
+(NSString * _Nonnull)ToJSONString_NSStringDictionary:(NSDictionary * _Nullable)dictionary;
+(NSString * _Nonnull)ToJSONString_AuthorizationResult:(VKAuthorizationResult * _Nullable)result;
+(NSString * _Nonnull)ToJSONString_User:(VKUser * _Nullable)user;
+(NSString * _Nonnull)ToJSONString_AccessToken:(VKAccessToken * _Nullable)accessToken;
+(NSString * _Nonnull)ToJSONString_AuthorizationState:(VKAuthorizationState)state;
+(NSString * _Nonnull)ToJSONString_Error:(VKError * _Nullable)error;
@end
