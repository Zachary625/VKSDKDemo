//
//  VKontakteWrapper.h
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#ifndef VKontakteWrapper_h
#define VKontakteWrapper_h
#endif /* VKontakteWrapper_h */

@interface VKontakteWrapper : NSObject

+(VKontakteWrapper *)Instance;


-(NSString *)CurrentAppID;
-(NSString *)APIVersion;
-(BOOL)Initialized;
-(BOOL)InitializeWithAppID:(NSString *)appID;
-(void)Authorize:(NSArray *)permissions;

-(BOOL)AppMayExists;

-(void)WakeUpSession;
-(BOOL)IsLoggedIn;
-(void)ForceLogout;

@end
