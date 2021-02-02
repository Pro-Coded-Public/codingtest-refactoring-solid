namespace ClearBank.DeveloperTest.Types
{
    public interface IMakePaymentResult
    {
        int FailureCode { get; }
        bool Success { get; }
    }
}