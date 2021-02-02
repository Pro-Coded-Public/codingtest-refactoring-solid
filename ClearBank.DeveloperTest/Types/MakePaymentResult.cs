using ClearBank.DeveloperTest.Constants;

namespace ClearBank.DeveloperTest.Types
{
    public class MakePaymentResult : IMakePaymentResult
    {
        public static MakePaymentResult FailureResult(int failureCode = FailureCodeConstants.UNKNOWN)
        { return new MakePaymentResult { Success = false, FailureCode = failureCode }; }

        public static MakePaymentResult SuccessResult() { return new MakePaymentResult { Success = true }; }

        public int FailureCode { get; private set; }

        public bool Success { get; private set; }
    }
}