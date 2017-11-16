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
    const char *CurrentAppID();
    const char *APIVersion();
    int Initialized();
    int InitializeWithAppID(char* appID);
    int InitializeWithAppIDAndAPIVersion(char* appID, char* apiVersion);
    
    int IsLoggedIn();
    void WakeUpSession();
    void Authorize();
    void ForceLogout();
    
    void CopyStringToClipboard(const char *content);
    const char *CopyStringFromClipboard();
#ifdef __cplusplus
};
#endif
