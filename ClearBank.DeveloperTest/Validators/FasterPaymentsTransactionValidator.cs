using ClearBank.DeveloperTest.Constants;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentsTransactionValidator : ITransactionValidator
    {
        public TransactionValidationResult Validate(Account account, MakePaymentRequest request)
        {
            if((account.AllowedPaymentSchemes & AllowedPaymentSchemes.FasterPayments) == 0)
            {
                return TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);
            }

            if(request.Amount >= account.Balance)
            {
                return TransactionValidationResult.FailureResult(FailureCodeConstants.INSUFFICIENT_FUNDS);
            }

            return TransactionValidationResult.SuccessResult();
        }
    }
}