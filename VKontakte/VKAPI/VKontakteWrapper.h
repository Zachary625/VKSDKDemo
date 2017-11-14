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
@property (nonatomic, copy)NSInteger appID;
@property (nonatomic, copy)NSString* secureKey;

+(VKontakteWrapper *)Instance;

+(char *)NSStringToChars:(NSString *)nsString;

-(NSString *)CurrentAppID;
-(NSString *)APIVersion;
-(BOOL)Initialized;
-(instancetype)InitializeWithAppID:(NSString *)appID;
-(void)Authorize:(NSArray *)permissions;

-(BOOL)AppMayExists;

-(BOOL)HasPermissions:(NSArray *)permissions;
-(BOOL)IsLoggedIn;
-(void)ForceLogout;

@end
