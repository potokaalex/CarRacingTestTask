namespace Client.Code.Common.Services.Asset.Receiver
{
    public interface IAssetReceiver<in T> : IAssetReceiverBase where T : IAsset
    {
        void Receive(T asset);
    }
}