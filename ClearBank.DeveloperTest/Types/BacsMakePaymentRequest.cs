
using System;

using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Types
{
    public class BacsMakePaymentRequest : IMakePaymentRequest
    {
        public decimal Amount { get; set; }

        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentScheme PaymentScheme { get; set; }

        public ITransactionValidator TransactionValidator
        {
            get;
        } = TransactionValidatorFactory.CreateBacsTransactionValidator();
    }
}