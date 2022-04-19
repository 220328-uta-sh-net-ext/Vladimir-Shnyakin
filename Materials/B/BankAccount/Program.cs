using Classes;

var account = new BankAccount("Vasya Pupkin", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
// Test that the initial balances must be positive.

Console.WriteLine(account.GetAccountHistory());