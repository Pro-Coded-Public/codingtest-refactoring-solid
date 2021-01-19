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
    public class Chaps_PaymentIsRequested_FromANonChapsAccount : GivenSubject<PaymentService, MakePaymentResult>
    {
        public Chaps_PaymentIsRequested_FromANonChapsAccount()
        {
            Given(() => The<IAccountDataStore>());
            When(
                () => Subject.MakePayment(
                    new ChapsMakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS,
                    PaymentScheme = PaymentScheme.Chaps
                }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_code_is_unsupported_payment_scheme()
        { Result.FailureCode.Should().Be(FailureCodeConstants.UNSUPPORTED_PAYMENT_SCHEME); }

        [Fact]
        public void Then_the_MakePaymentResult_is_failure() { Result.Success.Should().BeFalse(); }
    }
}