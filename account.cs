namespace test;

 public class Account
    {
        private static readonly Random random = new Random();
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; set; }

        public const double MinimumInitialBalance = 100;

        public Account(string ownerName, double initialBalance)
        {
            AccountNumber = random.Next(1, int.MaxValue);
            OwnerName = ownerName;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"AccountNumber: {AccountNumber}, OwnerName: {OwnerName}, Balance: {Balance:C}";
        }
    }
