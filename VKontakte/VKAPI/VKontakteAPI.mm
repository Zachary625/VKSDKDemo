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
    return [VKontakteWrapper NSStringToChars:[VKontakteWrapper Instance].CurrentAppID];
}

char *APIVersion()
{
    return [VKontakteWrapper NSStringToChars:[VKontakteWrapper Instance].APIVersion];
}

int Initialized()
{
    if([VKontakteWrapper Instance].Initialized == TRUE)
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
    if([[VKontakteWrapper Instance] InitializeWithAppID:[NSString stringWithUTF8String:appID]] == TRUE)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

