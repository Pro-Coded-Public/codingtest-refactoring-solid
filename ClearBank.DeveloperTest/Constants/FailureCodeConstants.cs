using System;

namespace ClearBank.DeveloperTest.Constants
{
    public static class FailureCodeConstants
    {
        public const int ACCOUNT_NOT_FOUND = 404;
        public const int ACCOUNT_NOT_LIVE = 405;
        public const int EXCEPTION = 500;
        public const int INSUFFICIENT_FUNDS = 406;
        public const int UNKNOWN = 400;
        public const int UNSUPPORTED_PAYMENT_SCHEME = 407;
    }
}