class Program
{
    static void Main(string[] args)
    {
        BankAccount person1 = new BankAccount("1101");
        BankAccount person2 = new BankAccount("1102");

        person1.deposit(40000);
        person1.transfer(person2, 1000);
        person1.withdraw(1000);

        person1.generate_statement();
        Console.WriteLine();
        person2.generate_statement();
        
    }
}

class BankAccount
{
    public BankAccount(string acc_number) 
    {
        account_number = acc_number;
    }   

    private string account_number;
    private int balance = 0;
    public List<string> transaction = new List<string>();

    public void deposit(int amount)
    {
        balance += amount;
        transaction.Add($"Deposit: + ${amount}");
    }

    public void withdraw(int amount)
    {
        balance -= amount;
        transaction.Add($"Withdrawal: -${amount}");
    }

    public void transfer(BankAccount account2, int amount)
    {
        balance -= amount;
        account2.balance += amount;
        
        transaction.Add($"Transfer to {account2.account_number}: -${amount}");
    }

    public void generate_statement()
    {
        Console.WriteLine($"Account name is: {account_number}");
        foreach(string s in transaction)
        {
            Console.WriteLine($"Transactions: {s}");
        }
        
        Console.WriteLine($"Balance: ${balance}");
    }

    public int get_balance()
    {
        return balance;
    }

    public void clear_transactions()
    {
        foreach(string s in transaction)
        {
            transaction.Remove(s);
            Console.WriteLine("Transactions was deleted");
        }
    }
}