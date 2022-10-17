

namespace DestinationMessurment.Service.Common.Guard
{
    [Serializable]
    public sealed class ThrowException : Exception
    {
        public ThrowException(string reason)
            : base(reason)
        {
        }
    }
}
