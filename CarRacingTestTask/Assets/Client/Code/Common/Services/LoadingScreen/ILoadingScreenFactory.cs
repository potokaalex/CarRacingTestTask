namespace Client.Code.Common.Services.LoadingScreen
{
    public interface ILoadingScreenFactory
    {
        ILoadingScreen Create();
        void Destroy();
    }
}