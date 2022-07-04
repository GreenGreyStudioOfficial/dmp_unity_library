#import <Foundation/Foundation.h>

#import <CoreTelephony/CTTelephonyNetworkInfo.h>
#import <CoreTelephony/CTCarrier.h>


@interface iOSPlugin : NSObject

@end

@implementation iOSPlugin

+(NSString *)getCellularName
{
    CTTelephonyNetworkInfo *netinfo = [[CTTelephonyNetworkInfo alloc] init];
    CTCarrier *carrier = [netinfo subscriberCellularProvider];
    NSString *carrierName = [carrier carrierName];
    
    if (carrierName == nil) {
        return @"Unknown";
    }
    NSLog(@"Carrier Name: %@", carrierName);
    return carrierName;
}

+(NSString *)getMcc
{
    CTTelephonyNetworkInfo *netinfo = [[CTTelephonyNetworkInfo alloc] init];
    CTCarrier *carrier = [netinfo subscriberCellularProvider];
    NSString *mcc = [carrier mobileCountryCode];
    
    if (mcc == nil) {
        return @"Unknown";
    }
    NSLog(@"Mobile Country Code: %@", mcc);
    return mcc;
}

+(NSString *)getMnc
{
    CTTelephonyNetworkInfo *netinfo = [[CTTelephonyNetworkInfo alloc] init];
    CTCarrier *carrier = [netinfo subscriberCellularProvider];
    NSString *mnc = [carrier mobileNetworkCode];
    
    if (mnc == nil) {
        return @"Unknown";
    }
    NSLog(@"MobileNetworkCode: %@", mnc);
    return mnc;
}

@end

char* cStringCopy(const char* string)
{
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    
    return res;
}

extern "C"
{
    const char * _GetCellularName()
    {
        return cStringCopy([[iOSPlugin getCellularName] UTF8String]);
    }
    
    const char * _GetMcc()
    {
        return cStringCopy([[iOSPlugin getMcc] UTF8String]);
    }
    
    const char * _GetMnc()
    {
        return cStringCopy([[iOSPlugin getMnc] UTF8String]);
    }
}