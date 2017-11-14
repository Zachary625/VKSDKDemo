//
//  VKontakteAPI.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#import "VKontakteAPI.h"
#import "VKontakteWrapper.h"

char *CurrentAppID()
{
    return [VKontakteWrapper NSStringToChars[VKontakteWrapper CurrentAppID]];
}

char *APIVersion()
{
    return [VKontakteWrapper NSStringToChars[VKontakteWrapper APIVersion]];
}

int Initialized()
{
    if([VKontakteWrapper Initialized] == TRUE)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}
int InitializeWithAppID(char* appID)
{
}
int InitializeWithAppIDAndAPIVersion(char* appID, char* apiVersion);
