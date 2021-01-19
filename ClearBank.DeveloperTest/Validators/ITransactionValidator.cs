
using System;

using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
    public interface ITransactionValidator
    {
        TransactionValidationResult Validate(Account account, IMakePaymentRequest request);
    }
}