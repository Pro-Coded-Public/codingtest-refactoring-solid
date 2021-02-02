using Chill;

using ClearBank.DeveloperTest.Constants;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.Constants;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

using FluentAssertions;

using Xunit;

namespace ClearBank.DeveloperTest.Tests.Specs
{
    public class PaymentIsRequested_FromMissingAccount : GivenSubject<PaymentService, IMakePaymentResult>
    {
        public PaymentIsRequested_FromMissingAccount()
        {
            Given(
                () =>
                {
                    The<IAccountDataStore>();
                    SetThe<ITransactionValidator>().To(TransactionValidatorFactory.CreateBacsTransactionValidator());
                });
            When(
                () => Subject.MakePayment(
                    new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_MISSING,
                    PaymentScheme = PaymentScheme.Bacs
                }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_code_is_account_not_found()
        { Result.FailureCode.Should().Be(FailureCodeConstants.ACCOUNT_NOT_FOUND); }

        [Fact]
        public void Then_the_MakePaymentResult_is_failure() { Result.Success.Should().BeFalse(); }
    }
}