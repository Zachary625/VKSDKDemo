//
//  VKontakteSDKDelegate.h
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//

#ifndef VKontakteSDKDelegate_h
#define VKontakteSDKDelegate_h

#endif /* VKontakteSDKDelegate_h */

#import <VKSdkFramework/VKSdkFramework.h>

@interface VKontakteSDKDelegate: NSObject<VKSdkDelegate>

/**
 Notifies about authorization was completed, and returns authorization result with new token or error.
 
 @param result contains new token or error, retrieved after VK authorization.
 */
- (void)vkSdkAccessAuthorizationFinishedWithResult:(VKAuthorizationResult *)result;

/**
 Notifies about access error. For example, this may occurs when user rejected app permissions through VK.com
 */
- (void)vkSdkUserAuthorizationFailed;

/**
 Notifies about authorization state was changed, and returns authorization result with new token or error.
 
 If authorization was successfull, also contains user info.
 
 @param result contains new token or error, retrieved after VK authorization
 */
- (void)vkSdkAuthorizationStateUpdatedWithResult:(VKAuthorizationResult *)result;

/**
 Notifies about access token has been changed
 
 @param newToken new token for API requests
 @param oldToken previous used token
 */
- (void)vkSdkAccessTokenUpdated:(VKAccessToken *)newToken oldToken:(VKAccessToken *)oldToken;

/**
 Notifies about existing token has expired (by timeout). This may occurs if you requested token without no_https scope.
 
 @param expiredToken old token that has expired.
 */
- (void)vkSdkTokenHasExpired:(VKAccessToken *)expiredToken;

@end
