using System;
using System.ComponentModel;
using Client.Code.Common.Data;
using Client.Code.Common.Services.Network;
using Client.Code.Gameplay.Game.GameSpawnPoint;
using Client.Code.GameplayOnline.Game.Car;
using ExitGames.Client.Photon;

namespace Client.Code.GameplayOnline.Infrastructure.States
{
    public static class NetworkCarCreateDataSerializer
    {
        private static readonly byte[] _buffer = new byte[sizeof(float) * (3 + 4) + sizeof(int) + sizeof(bool)];

        public static short Serialize(StreamBuffer outStream, object obj) => SerializeBase(outStream, obj, 0);

        private static short SerializeBase(StreamBuffer outStream, object obj, int offset)
        {
            var data = (CarCreateData)obj;
            var array = _buffer;

            var index = 0;
            index += NetworkSpawnPointSerializer.SerializeBase(_buffer, data.SpawnPoint, index);
            Protocol.Serialize((int)data.ColorType, array, ref index);
            ProtocolExtensions.Serialize(data.IsCarSpoilerEnabled, array, ref index);
            outStream.Write(array, offset, array.Length);
            return (short)array.Length;
        }

        public static object DeSerialize(StreamBuffer inStream, short length) => DeSerializeBase(inStream, length, 0);

        private static object DeSerializeBase(StreamBuffer inStream, short length, int offset)
        {
            var data = new CarCreateData();
            var array = _buffer;
            if (length != array.Length)
                return data;

            var index = sizeof(float) * (3 + 4);
            inStream.Read(array, offset, array.Length);
            data.SpawnPoint = (SpawnPoint)NetworkSpawnPointSerializer.DeSerializeBase(_buffer, index, 0);
            Protocol.Deserialize(out int carColor, array, ref index);
            data.ColorType = (CarColorType)carColor;
            ProtocolExtensions.Deserialize(out data.IsCarSpoilerEnabled, array, ref index);
            return data;
        }
    }
}