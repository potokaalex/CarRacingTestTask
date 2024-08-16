using Client.Code.Game.Gameplay.GameSpawnPoint;
using ExitGames.Client.Photon;

namespace Client._dev.GameplayOnline.Data.Network
{
    public static class NetworkSpawnPointSerializer
    {
        private static readonly byte[] _buffer = new byte[sizeof(float) * (3 + 4)];

        public static short Serialize(StreamBuffer outStream, object obj)
        {
            var size = SerializeBase(_buffer, obj, 0);
            outStream.Write(_buffer, 0, _buffer.Length);
            return (short)size;
        }

        public static int SerializeBase(byte[] outArray, object obj, int outOffset)
        {
            var data = (SpawnPoint)obj;
            var index = outOffset;

            Protocol.Serialize(data.Position.x, outArray, ref index);
            Protocol.Serialize(data.Position.y, outArray, ref index);
            Protocol.Serialize(data.Position.z, outArray, ref index);

            Protocol.Serialize(data.Rotation.x, outArray, ref index);
            Protocol.Serialize(data.Rotation.y, outArray, ref index);
            Protocol.Serialize(data.Rotation.z, outArray, ref index);
            Protocol.Serialize(data.Rotation.w, outArray, ref index);

            return _buffer.Length;
        }

        public static object DeSerialize(StreamBuffer inStream, short length)
        {
            inStream.Read(_buffer, 0, _buffer.Length);
            var size = DeSerializeBase(_buffer, length, 0);
            return size;
        }

        public static object DeSerializeBase(byte[] inArray, int length, int inOffset)
        {
            var data = new SpawnPoint();
            if (length != _buffer.Length)
                return data;

            var index = inOffset;
            Protocol.Deserialize(out data.Position.x, inArray, ref index);
            Protocol.Deserialize(out data.Position.y, inArray, ref index);
            Protocol.Deserialize(out data.Position.z, inArray, ref index);

            Protocol.Deserialize(out data.Rotation.x, inArray, ref index);
            Protocol.Deserialize(out data.Rotation.y, inArray, ref index);
            Protocol.Deserialize(out data.Rotation.z, inArray, ref index);
            Protocol.Deserialize(out data.Rotation.w, inArray, ref index);

            return data;
        }
    }
}