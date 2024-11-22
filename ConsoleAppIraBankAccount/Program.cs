using System;
using System.Net.Http.Headers;

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount("1", "Irina", 25000);
        BankAccount account2 = new BankAccount("2", "NeIrina", 14000);

        account1.PutOnAccount(2000);
        account1.WithdrowFromAcc(3000);

        account2.Transfer(account1, 1500);

        Console.WriteLine($"\nТекущие балансы:");
        Console.WriteLine($"Счет {account1.AccountNumber}: {account1.CheckBalance()}");
        Console.WriteLine($"Счет {account2.AccountNumber}: {account2.CheckBalance()}");
    }
}

class BankAccount
{
    public string AccountNumber;
    public string OwnerName;
    public decimal Balance;

    public BankAccount()
    {
        AccountNumber = "";
        OwnerName = "";
        Balance = 0;
    }

    public BankAccount(string accountNumber, string ownerName, decimal balance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = balance;
    }

    public void PutOnAccount(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"На счет {AccountNumber} было зачислено {amount} рублей. \n Баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Пополнение не может быть отрицатльным.");
        }
    }

    public bool WithdrowFromAcc(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Сумма снятия не должна превышать текущий баланс средств на счету.");
            return false;
        }
        if (amount <= 0)
        {
            Console.WriteLine("Снятие отрицательной суммы невозможно.");
            return false;
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"Со счета {AccountNumber} снято {amount} рублей. \n Баланс: {Balance}.");
            return true;
        }
    }

    public decimal CheckBalance()
    {
        return Balance;
    }

    public void Transfer(BankAccount otherAccount, decimal amount)
    {
        if (WithdrowFromAcc(amount))
        {
            otherAccount.PutOnAccount(amount);
            Console.WriteLine($"Перевод {amount} рублей со счета {AccountNumber} на счет {otherAccount.AccountNumber} выполнен.\n Баланс: {Balance}.");
        }
        else
        {
            Console.WriteLine("Сумма перевода не может превышать текущий баланс.");
        }
    }
}

//🙌🙌😎😍😁💖🤳💖💖❤❤❤👏 
