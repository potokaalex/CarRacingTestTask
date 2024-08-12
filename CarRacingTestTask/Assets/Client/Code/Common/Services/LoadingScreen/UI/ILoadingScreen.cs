namespace Client.Code.Common.Services.LoadingScreen.UI
{
    public interface ILoadingScreen
    {
        void SetProgress(float progress, float startValue, float endValue);
    }
}