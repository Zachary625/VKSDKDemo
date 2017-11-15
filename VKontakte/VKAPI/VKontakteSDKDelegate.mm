//
//  VKontakteSDKDelegate.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//

#import <Foundation/Foundation.h>
#import "VKontakteSDKDelegate.h"
#import "VKontakteUtility.h"
@implementation VKontakteSDKDelegate


/**
 Notifies about authorization was completed, and returns authorization result with new token or error.
 
 @param result contains new token or error, retrieved after VK authorization.
 */
- (void)vkSdkAccessAuthorizationFinishedWithResult:(VKAuthorizationResult *)result
{
    NSString *resultJson = [VKontakteUtility ToJSONString_AuthorizationResult:result];
    [VKontakteUtility Log:resultJson];
    [VKontakteUtility UnitySendMessage:"vkSdkAccessAuthorizationFinishedWithResult" Parameter:[VKontakteUtility NSStringToChars:resultJson]];
}

/**
 Notifies about access error. For example, this may occurs when user rejected app permissions through VK.com
 */
- (void)vkSdkUserAuthorizationFailed
{
    [VKontakteUtility Log:@"VKontakteSDKDelegate.vkSdkUserAuthorizationFailed"];
    [VKontakteUtility UnitySendMessage:"vkSdkUserAuthorizationFailed" Parameter:""];
}

/**
 Notifies about authorization state was changed, and returns authorization result with new token or error.
 
 If authorization was successfull, also contains user info.
 
 @param result contains new token or error, retrieved after VK authorization
 */
- (void)vkSdkAuthorizationStateUpdatedWithResult:(VKAuthorizationResult *)result
{
    NSString *resultJson = [VKontakteUtility ToJSONString_AuthorizationResult:result];
    [VKontakteUtility Log:resultJson];
    [VKontakteUtility UnitySendMessage:"vkSdkAuthorizationStateUpdatedWithResult" Parameter:[VKontakteUtility NSStringToChars:resultJson]];
}

/**
 Notifies about access token has been changed
 
 @param newToken new token for API requests
 @param oldToken previous used token
 */
- (void)vkSdkAccessTokenUpdated:(VKAccessToken *)newToken oldToken:(VKAccessToken *)oldToken
{
    NSString *newTokenJson = [VKontakteUtility ToJSONString_AccessToken:newToken];
    NSString *oldTokenJson = [VKontakteUtility ToJSONString_AccessToken:oldToken];

    NSString *tokenUpdateJson = [VKontakteUtility ToJSONString_NSStringDictionary:
                                 @{
                                   @"old": oldTokenJson,
                                   @"new": newTokenJson,
                                   }];
    [VKontakteUtility Log:tokenUpdateJson];
    [VKontakteUtility UnitySendMessage:"vkSdkAccessTokenUpdated" Parameter:[VKontakteUtility NSStringToChars:tokenUpdateJson]];
}

/**
 Notifies about existing token has expired (by timeout). This may occurs if you requested token without no_https scope.
 
 @param expiredToken old token that has expired.
 */
- (void)vkSdkTokenHasExpired:(VKAccessToken *)expiredToken
{
    NSString *tokenJson = [VKontakteUtility ToJSONString_AccessToken:expiredToken];
    [VKontakteUtility Log:tokenJson];
    [VKontakteUtility UnitySendMessage:"vkSdkTokenHasExpired" Parameter:[VKontakteUtility NSStringToChars:tokenJson]];
}

@end
