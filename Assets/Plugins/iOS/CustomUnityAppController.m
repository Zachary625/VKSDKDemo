//
//  CustomUnityAppController.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//
#import "UnityAppController.h"
#import <VKSdkFramework/VKSdkFramework.h>
@interface CustomUnityAppController: UnityAppController
@end

IMPL_APP_CONTROLLER_SUBCLASS(CustomUnityAppController)

@implementation CustomUnityAppController

- (BOOL)application:(UIApplication*)application openURL:(nonnull NSURL *)url sourceApplication:(nullable NSString *)sourceApplication annotation:(nonnull id)annotation
{
    [VKSdk processOpenURL:url fromApplication:sourceApplication];
}

-(BOOL)application:(UIApplication*)application openURL:(nonnull NSURL *)url options:(nonnull NSDictionary<NSString *,id> *)options
{
    [VKSdk processOpenURL:url fromApplication:options[UIApplicationOpenURLOptionsSourceApplicationKey]];
}
@end
