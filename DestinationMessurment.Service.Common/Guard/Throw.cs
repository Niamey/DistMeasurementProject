

namespace DestinationMessurment.Service.Common.Guard
{
    public static class Throw
    {
        #region PublicMethods

        #region IfNull

        public static void IfNull(Object obj, string parameterName, string reason)
        {
            CheckParameterValue(parameterName);
            CheckParameterValue(reason);
            ThrowImpl((input) => input == null, obj, new ArgumentNullException(parameterName, reason));
        }
        #endregion

        #region IfNullOrWhiteSpace

        public static void IfNullOrWhiteSpace(string str, string parameterName)
        {
            CheckParameterValue(parameterName);
            string reason = string.Format("{0} cannot be null or empty", parameterName);
            IFNullOrWhiteSpace(str, parameterName, reason);
        }

        public static void IFNullOrWhiteSpace(string str, string parameterName, string reason)
        {
            IfNull(str, parameterName, reason);
            ThrowImpl((obj) => string.IsNullOrWhiteSpace(obj.ToString()), str, new ArgumentNullException(parameterName, reason));
        }
        #endregion

        #endregion

        #region PrivateMethods

        private static void CheckParameterValue(string parameter)
        {
            if (parameter == null)
            {
                throw new ThrowException("Input parameter has null value");
            }
        }

        private static void ThrowImpl(Func<object, bool> needToThrow, object obj, Exception ex)
        {
            bool isThrowEx = needToThrow(obj);

            if (!isThrowEx)
            {
                return;
            }

            if (ex == null)
            {
                throw new ThrowException("Exception is not provided");
            }

            throw ex;
        }
        #endregion
    }
}
