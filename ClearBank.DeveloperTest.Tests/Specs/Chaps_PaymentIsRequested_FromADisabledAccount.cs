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
    public class Chaps_PaymentIsRequested_FromADisabledAccount : GivenSubject<PaymentService, MakePaymentResult>
    {
        public Chaps_PaymentIsRequested_FromADisabledAccount()
        {
            Given(
                () =>
                {
                    The<IAccountDataStore>();
                    SetThe<ITransactionValidator>().To(TransactionValidatorFactory.CreateChapsTransactionValidator());
                });
            When(
                () => Subject.MakePayment(
                    new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_CHAPS_DISABLED,
                    PaymentScheme = PaymentScheme.Chaps
                }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_code_is_account_not_live()
        { Result.FailureCode.Should().Be(FailureCodeConstants.ACCOUNT_NOT_LIVE); }

        [Fact]
        public void Then_the_MakePaymentResult_is_failure() { Result.Success.Should().BeFalse(); }
    }
}