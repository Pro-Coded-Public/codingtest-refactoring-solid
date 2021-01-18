using System;

using Chill;

using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Tests.Constants;

using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace ClearBank.DeveloperTest.Tests.ObjectMothers
{
    /// <summary>
    /// An ObjectMother is used to inject known behaviour for a specified interface. This approach supports delivering
    /// both known data, and exceptions, for comprehensive testing
    /// </summary>
    public class AccountDataStoreMother : ObjectMother<IAccountDataStore>
    {
        protected override IAccountDataStore Create()
        {
            var sub = Substitute.For<IAccountDataStore>();

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_BACS))
                .Returns(new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_BACS).WithBacs().Build());

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_CHAPS))
                .Returns(new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_CHAPS).WithChaps().Build());

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_CHAPS_DISABLED))
                .Returns(
                    new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_CHAPS_DISABLED).WithChaps()
                        .WithStatusDisabled()
                        .Build());

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS))
                .Returns(
                    new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS).WithFasterPayments().Build());

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS_INSUFFICENT_FUNDS))
                .Returns(
                    new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS_INSUFFICENT_FUNDS).WithFasterPayments(
                        )
                        .WithInsufficientFunds()
                        .Build());

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_MISSING)).ReturnsNull();

            sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_EXCEPTION))
                .Throws(new Exception("Exception from AccountDataStore"));

            return sub;
        }
    }
}