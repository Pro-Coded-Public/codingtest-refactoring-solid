namespace ClearBank.DeveloperTest.Types;

public class MakePaymentResult : IMakePaymentResult
{
    public static MakePaymentResult FailureResult(int failureCode = FailureCodeConstants.UNKNOWN) => new() { Success = false, FailureCode = failureCode };

    public static MakePaymentResult SuccessResult() => new() { Success = true };

    public int FailureCode { get; private set; }

    public bool Success { get; private set; }
}