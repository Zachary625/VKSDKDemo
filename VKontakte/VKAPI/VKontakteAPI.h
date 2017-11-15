//
//  VKontakteAPI.h
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#ifndef VKontakteAPI_h
#define VKontakteAPI_h

#import <Foundation/Foundation.h>

#endif /* VKontakteAPI_h */

#ifdef __cplusplus
extern "C" {
#endif
    char *CurrentAppID();
    char *APIVersion();
    int Initialized();
    int InitializeWithAppID(char* appID);
    int InitializeWithAppIDAndAPIVersion(char* appID, char* apiVersion);
    
    void Authorize();
    void ForceLogout();
    
#ifdef __cplusplus
};
#endif
