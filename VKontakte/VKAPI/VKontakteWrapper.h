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


@end
