
using System;

namespace ClearBank.DeveloperTest.Validators
{
    public class TransactionValidationResult
    {
        public static TransactionValidationResult FailureResult(int validationError)
        { return new TransactionValidationResult { IsValid = false, ValidationError = validationError }; }

        public static TransactionValidationResult SuccessResult()
        { return new TransactionValidationResult { IsValid = true }; }

        public bool IsValid { get; private set; }

        public int ValidationError { get; private set; }
    }
}