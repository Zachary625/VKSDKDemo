//
//  VKontakteSDKUIDelegate.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//

#import <Foundation/Foundation.h>
#import "VKontakteSDKUIDelegate.h"
#import "VKontakteWrapper.h"
#import "VKontakteUtility.h"

@implementation VKontakteSDKUIDelegate
/**
 Pass view controller that should be presented to user. Usually, it's an authorization window.
 
 @param controller view controller that must be shown to user
 */
- (void)vkSdkShouldPresentViewController:(UIViewController *)controller
{
    [VKontakteUtility Log:@"VKontakteSDKUIDelegate.vkSdkShouldPresentViewController: "];
    [VKontakteUtility UnitySendMessage:"vkSdkShouldPresentViewController" Parameter:""];
}

/**
 Calls when user must perform captcha-check.
 If you implementing this method by yourself, call -[VKError answerCaptcha:] method for captchaError with user entered answer.
 
 @param captchaError error returned from API. You can load captcha image from <b>captchaImg</b> property.
 */
- (void)vkSdkNeedCaptchaEnter:(VKError *)captchaError
{
    NSString *captchaErrorJson = [VKontakteUtility ToJSONString_VKError:captchaError];
    [VKontakteUtility Log:@"VKontakteSDKUIDelegate.vkSdkNeedCaptchaEnter: %@", captchaErrorJson];
    [VKontakteUtility UnitySendMessage:"vkSdkNeedCaptchaEnter" Parameter:[VKontakteUtility NSStringToChars:captchaErrorJson]];
}

/**
 * Called when a controller presented by SDK will be dismissed.
 */
- (void)vkSdkWillDismissViewController:(UIViewController *)controller
{
    [VKontakteUtility Log:@"VKontakteSDKUIDelegate.vkSdkWillDismissViewController: "];
    [VKontakteUtility UnitySendMessage:"vkSdkWillDismissViewController" Parameter:""];
}

/**
 * Called when a controller presented by SDK did dismiss.
 */
- (void)vkSdkDidDismissViewController:(UIViewController *)controller
{
    [VKontakteUtility Log:@"VKontakteSDKUIDelegate.vkSdkDidDismissViewController: "];
    [VKontakteUtility UnitySendMessage:"vkSdkDidDismissViewController" Parameter:""];
}

@end
