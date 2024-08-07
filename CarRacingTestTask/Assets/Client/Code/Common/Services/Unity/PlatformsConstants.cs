namespace Client.Code.Common.Services.Unity
{
    public static class PlatformsConstants
    {
        public static readonly bool IsEditor;
        public static readonly bool IsAndroid;
        public static readonly bool IsIOS;

        static PlatformsConstants()
        {
#if UNITY_EDITOR
            IsEditor = true;
#elif UNITY_ANDROID
            IsAndroid = true;
#elif UNITY_IOS
            IsIOS = true;
#endif
        }
    }
}