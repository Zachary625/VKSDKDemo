//
//  VKontakteSDKUIDelegate.h
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//

#ifndef VKontakteSDKUIDelegate_h
#define VKontakteSDKUIDelegate_h

#endif /* VKontakteSDKUIDelegate_h */

#import <VKSdkFramework/VKSdkFramework.h>

@interface VKontakteSDKUIDelegate: NSObject<VKSdkUIDelegate>

/**
 Pass view controller that should be presented to user. Usually, it's an authorization window.
 
 @param controller view controller that must be shown to user
 */
- (void)vkSdkShouldPresentViewController:(UIViewController *)controller;

/**
 Calls when user must perform captcha-check.
 If you implementing this method by yourself, call -[VKError answerCaptcha:] method for captchaError with user entered answer.
 
 @param captchaError error returned from API. You can load captcha image from <b>captchaImg</b> property.
 */
- (void)vkSdkNeedCaptchaEnter:(VKError *)captchaError;

/**
 * Called when a controller presented by SDK will be dismissed.
 */
- (void)vkSdkWillDismissViewController:(UIViewController *)controller;

/**
 * Called when a controller presented by SDK did dismiss.
 */
- (void)vkSdkDidDismissViewController:(UIViewController *)controller;

@end
