# ClearBank.DeveloperTest

## Steps taken, as part of the refactoring process

1. Create simple, naïve tests to exercise the original codebase, to identify existing code paths. These were quickly created in xUnit.

   This revealed a number of issues, including a logic error that meant code to perform a transaction against the target account would never be executed.

2. Create a set of specifications according to the intent of original code, combined with the high-level description in the candidate brief. 

   Specifications were put in place prior to refactoring, apart from introduction of an interface to decouple the AccountDataStore and BAckupDataStor.

   The BDD style test framework 'Chill' is used for its concise, expressive approach that also enhances readability of tests, with a clear statement of intent, without verbosity.

3. Dependency injection is used to provide an instance of IAccountDataStore.

4. A builder pattern is used to construct the Account object that is returned by the IAccountDataStore instance.

5. The concrete implementation of the IAccountDataStore instance uses NSubstitute to exhibit defined behaviours for the GetAccount method, based on the value of the account number that is passed to it (i.e. returning a value, or an exception). This allows all code paths to be exercised.

6. The PaymentService is refactored to remove the original switch statement, and the majority of conditional statements, and instead call a method on an object that is passed to the PaymentService in order to validate the state of the account, according to the business rules for the desired method of payment.

7. A failure code is returned to the caller to indicate the outcome of an operation, including validation error, or exception.

8. BackupAccountDataStore is not implemented in this solution, as no behaviour is expressed in the original code, and I have deemed that to be out-of-scope. Supporting this would be straightforward, by implementing BackupAccountDataStoreMother : ObjectMother<IAccountDataStore>, as per the existing AccountDataStoreMother approach.

## General approach

The general approach has been to refactor code to separate classes with clearly defined responsibilities, code against interfaces, favour composition, dependency inversion.

There are additional branches that show minor variations of the above approach, namely:

alternative-open-closed
Adds a property on the MakePaymentRequest class, to accept an instance of ITransactionValidator. Included as a demonstration of an object that is open for extension, closed for modification, favouring composition over inheritance. Personally, I prefer composition, as inheritance hierarchies can be fragile over time, and overly-complex.

alternative-liskov
Uses a subclass of an abstract MakePaymentRequest class, e.g. BacsMakePaymentRequest, that defines the creation of the relevant concrete implementation of ITransactionValidator, favouring inheritance over composition. Personally I do not recommend this.

alternative-open-closed2
NOTE: this breaks the requirement to not alter the signature of the MakePayment method of the IpaymentService, by switching to an interface IMakePaymentRequest rather than MakePaymentRequest. Included as I recommend coding against interfaces, rather than concrete types.


## Further enhancements if time permitted:

Make types immutable, e.g. MakePaymentRequest, MakePaymentResponse. 
Possibly use 'record' from c# 9, and other language features.
