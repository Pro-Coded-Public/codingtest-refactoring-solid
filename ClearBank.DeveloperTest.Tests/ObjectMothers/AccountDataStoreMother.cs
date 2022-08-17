using ClearBank.DeveloperTest.Tests.Builders;

using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace ClearBank.DeveloperTest.Tests.ObjectMothers;

/// <summary>
/// An ObjectMother is used to inject known behaviour for a specified interface. This approach supports delivering
/// both known data, and exceptions, for comprehensive testing
/// </summary>
public class AccountDataStoreMother : ObjectMother<IAccountDataStore>
{
    protected override IAccountDataStore Create()
    {
        IAccountDataStore sub = Substitute.For<IAccountDataStore>();

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_BACS))
            .Returns(new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_BACS).WithBacs().Build());

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_CHAPS))
            .Returns(new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_CHAPS).WithChaps().Build());

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_CHAPS_DISABLED))
            .Returns(
                new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_CHAPS_DISABLED).WithChaps()
                    .WithStatusDisabled()
                    .Build());

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS))
            .Returns(
                new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS).WithFasterPayments().Build());

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS_INSUFFICENT_FUNDS))
            .Returns(
                new AccountBuilder(AccountNumberConstants.ACCOUNT_WITH_FASTERPAYMENTS_INSUFFICENT_FUNDS).WithFasterPayments(
                    )
                    .WithInsufficientFunds()
                    .Build());

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_MISSING)).ReturnsNull();

        _ = sub.GetAccount(Arg.Is<string>(AccountNumberConstants.ACCOUNT_EXCEPTION))
            .Throws(new Exception("Exception from AccountDataStore"));

        return sub;
    }
}