namespace Client.Code.Services.AssetProvider
{
    public interface IAssetProvider<out T> where T : IAsset
    {
        T Get();
    }
}