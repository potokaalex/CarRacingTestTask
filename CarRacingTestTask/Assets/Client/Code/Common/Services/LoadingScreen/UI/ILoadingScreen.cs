namespace Client.Code.Common.Services.LoadingScreen
{
    public interface ILoadingScreen
    {
        void SetProgress(float progress, float startValue, float endValue);
    }
}