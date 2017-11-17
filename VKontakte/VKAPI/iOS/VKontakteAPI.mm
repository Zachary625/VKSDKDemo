//
//  VKontakteAPI.m
//  Unity-iPhone
//
//  Created by zhang.chi on 2017/11/14.
//
//

#import "VKontakteAPI.h"
#import "VKontakteWrapper.h"
#import "VKontakteUtility.h"

const char *CurrentAppID()
{
    return [VKontakteUtility NSStringToChars:[VKontakteWrapper Instance].CurrentAppID];
}

const char *APIVersion()
{
    return [VKontakteUtility NSStringToChars:[VKontakteWrapper Instance].APIVersion];
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

int IsLoggedIn()
{
    if([[VKontakteWrapper Instance] IsLoggedIn] == TRUE)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

void WakeUpSession()
{
    [[VKontakteWrapper Instance] WakeUpSession];
}

void Authorize()
{
    [[VKontakteWrapper Instance] Authorize:nil];
}

void ForceLogout()
{
    [[VKontakteWrapper Instance] ForceLogout];
}

void CopyStringToClipboard(const char *content)
{
    if(content != NULL)
    {
        [VKontakteUtility CopyStringToClipboard:[NSString stringWithUTF8String:content]];
    }
}

const char *CopyStringFromClipboard()
{
    return [[VKontakteUtility CopyStringFromClipboard] UTF8String];
}


