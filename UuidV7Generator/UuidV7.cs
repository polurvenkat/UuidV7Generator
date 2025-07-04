using System;

namespace UuidV7Generator
{
    public static class UuidV7
    {
#if NET6_0_OR_GREATER
        private static Random RandomInstance => Random.Shared;
#else
        private static readonly Random _random = new Random();
        private static Random RandomInstance
        {
            get { lock (_random) return _random; }
        }
#endif

        public static Guid NewUuid()
        {
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            byte[] bytes = new byte[16];

#if NET6_0_OR_GREATER
            Random.Shared.NextBytes(bytes.AsSpan(6, 10));
#else
            lock (_random)
            {
                _random.NextBytes(bytes);
            }
#endif

            // Compose UUID v7 format manually
            // e.g., timestamp into first 6 bytes
            bytes[0] = (byte)((now >> 40) & 0xFF);
            bytes[1] = (byte)((now >> 32) & 0xFF);
            bytes[2] = (byte)((now >> 24) & 0xFF);
            bytes[3] = (byte)((now >> 16) & 0xFF);
            bytes[4] = (byte)((now >> 8) & 0xFF);
            bytes[5] = (byte)(now & 0xFF);

            // UUID v7 version
            bytes[6] &= 0x0F;
            bytes[6] |= 0x70;

            // Variant
            bytes[8] &= 0x3F;
            bytes[8] |= 0x80;

            return new Guid(bytes);
        }
    }
}