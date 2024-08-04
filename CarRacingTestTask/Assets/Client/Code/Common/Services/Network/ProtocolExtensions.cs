namespace Client.Code.Common.Services.Network
{
    public static class ProtocolExtensions
    {
        public static void Serialize(bool value, byte[] array, ref int offset) => array[offset++] = value ? (byte)1 : (byte)0;

        public static void Deserialize(out bool value, byte[] array, ref int offset) => value = array[offset++] == 1;
    }
}