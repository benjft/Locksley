namespace Locksley.Helpers;

public static class FlagHelper {
    public const bool IsDebug =
#if DEBUG
        true;
#else
        false;
#endif
        
    public const bool IsAndroid =
#if ANDROID
        true;
#else
        false;
#endif
}