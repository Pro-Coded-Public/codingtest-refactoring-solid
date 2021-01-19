using ClearBank.DeveloperTest.Constants;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public class BacsTransactionValidator : ITransactionValidator
    {
        public TransactionValidationResult Validate(Account account, IMakePaymentRequest request)
        {
            if((account.AllowedPaymentSchemes & AllowedPaymentSchemes.Bacs) == 0)
            {
                return TransactionValidationResult.FailureResult(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME);
            }

            return TransactionValidationResult.SuccessResult();
        }
    }
}