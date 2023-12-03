namespace MOROPO.VIDERHE.Terminal.Player.Security.Cryptography.Algorithms
{
    /// <summary>
    /// FNV-1a Hash functions
    /// </summary>
    public static class Fnv1a
    {
        /// <summary>
        /// Calculate 32-bit FNV-1a hash value
        /// </summary>
        public static uint Hash32(byte[] buffer)
        {
            const uint offsetBasis32 = 2166136261;
            const uint prime32 = 16777619;

            if (buffer == null)
            {
                throw new System.ArgumentNullException();
            }

            uint result = offsetBasis32;
            foreach (var b in buffer)
            {
                result = prime32 * (result ^ b);
            }
            return result;
        }

        /// <summary>
        /// Calculate 64-bit FNV-1a hash value
        /// </summary>
        public static ulong Hash64(byte[] buffer)
        {
            const ulong offsetBasis64 = 14695981039346656037;
            const ulong prime64 = 1099511628211;

            if (buffer == null)
            {
                throw new System.ArgumentNullException();
            }

            ulong result = offsetBasis64;
            foreach (var b in buffer)
            {
                result = prime64 * (result ^ b);
            }
            return result;
        }
    }
}
