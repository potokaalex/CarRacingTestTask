namespace Client.Code
{
    public interface IAssetReceiver<in T>
    {
        void Receive(T asset);
    }
}