
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Tests.Builders
{
    /// <summary>
    /// A builder pattern is used to create repeatable examples of test data
    /// </summary>
    public class AccountBuilder
    {
        readonly Account _account;

        public AccountBuilder(string accountNumber)
        {
            _account = new Account
            {
                AccountNumber = accountNumber,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = 100,
                Status = AccountStatus.Live
            };
        }

        public Account Build() { return _account; }

        public AccountBuilder WithAccountNumber(string accountNumber)
        {
            _account.AccountNumber = accountNumber;

            return this;
        }

        public AccountBuilder WithBacs()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;

            return this;
        }

        public AccountBuilder WithChaps()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;

            return this;
        }

        public AccountBuilder WithFasterPayments()
        {
            _account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;

            return this;
        }

        public AccountBuilder WithInsufficientFunds()
        {
            _account.Balance = -1;

            return this;
        }

        public AccountBuilder WithStatusDisabled()
        {
            _account.Status = AccountStatus.Disabled;

            return this;
        }
    }
}