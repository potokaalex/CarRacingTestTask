using Client.Code.Common.Services.Asset.Receiver;

namespace Client.Code.Common.Services.Asset.Loader
{
    public interface IAssetLoader<out T> where T : IAsset
    {
        void Load();
        void RegisterReceiver(IAssetReceiver<T> receiver);
        void UnRegisterReceiver(IAssetReceiver<T> receiver);
    }
}