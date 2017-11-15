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

@interface VKontakteUtility

+(void)Log:(NSString * _Nonnull)log, ...;
+(void)UnitySendMessage:(const char *)method Parameter:(const char *)parameter;
+(char *)NSStringToChars:(NSString *)nsString;
+(NSString *)ToJSONString_NSStringDictionary:(NSDictionary *)dictionary;
+(NSString *)ToJSONString_AuthorizationResult:(VKAuthorizationResult *)result;
+(NSString *)ToJSONString_User:(VKUser *)user;
+(NSString *)ToJSONString_AccessToken:(VKAccessToken *)accessToken;
+(NSString *)ToJSONString_AuthorizationState:(VKAuthorizationState)state;
@end
