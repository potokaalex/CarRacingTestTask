using Client.Code.Services.Asset.Receiver;

namespace Client.Code.Services.Asset.Loader
{
    public interface IAssetLoader<out T> where T : IAsset
    {
        void Load();
        void RegisterReceiver(IAssetReceiver<T> receiver);
        void UnRegisterReceiver(IAssetReceiver<T> receiver);
    }
}