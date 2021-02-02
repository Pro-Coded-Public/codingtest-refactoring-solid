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
    public class FasterPayments_PaymentIsRequested_FromAFasterPaymentAccountInsufficientFunds : GivenSubject<PaymentService, IMakePaymentResult>
    {
        public FasterPayments_PaymentIsRequested_FromAFasterPaymentAccountInsufficientFunds()
        {
            Given(
                () =>
                {
                    The<IAccountDataStore>();
                    SetThe<ITransactionValidator>()
                        .To(TransactionValidatorFactory.CreateFasterPaymentsTransactionValidator());
                });
            When(
                () => Subject.MakePayment(
                    new MakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS_INSUFFICENT_FUNDS,
                    PaymentScheme = PaymentScheme.FasterPayments
                }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_code_is_insufficient_funds()
        { Result.FailureCode.Should().Be(FailureCodeConstants.INSUFFICIENT_FUNDS); }

        [Fact]
        public void Then_the_MakePaymentResult_is_failure() { Result.Success.Should().BeFalse(); }
    }
}