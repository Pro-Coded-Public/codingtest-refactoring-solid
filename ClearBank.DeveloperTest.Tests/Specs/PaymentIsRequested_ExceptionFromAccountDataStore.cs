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
    public class PaymentIsRequested_ExceptionFromAccountDataStore : GivenSubject<PaymentService, MakePaymentResult>
    {
        public PaymentIsRequested_ExceptionFromAccountDataStore()
        {
            Given(() => The<IAccountDataStore>());
            When(
                () => Subject.MakePayment(
                    new BacsMakePaymentRequest
                {
                    DebtorAccountNumber = AccountNumberConstants.ACCOUNT_EXCEPTION,
                    PaymentScheme = PaymentScheme.Bacs
                }));
        }

        [Fact]
        public void Then_a_MakePaymentResult_is_returned() { Result.Should().NotBeNull(); }

        [Fact]
        public void Then_the_MakePaymentResult_code_is_exception()
        { Result.FailureCode.Should().Be(FailureCodeConstants.EXCEPTION); }

        [Fact]
        public void Then_the_MakePaymentResult_is_failure() { Result.Success.Should().BeFalse(); }
    }
}