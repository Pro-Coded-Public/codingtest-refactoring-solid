
using System;

using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Types
{
    public abstract class MakePaymentRequest
    {
        public decimal Amount { get; set; }

        public string CreditorAccountNumber { get; set; }

        public string DebtorAccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public abstract PaymentScheme PaymentScheme { get; }

        public virtual ITransactionValidator TransactionValidator { get; set; }
    }
}