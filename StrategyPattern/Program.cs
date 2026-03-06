namespace StrategyPattern
{
    // Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // Concrete Strategies
    public class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;
        private string _cardHolder;

        public CreditCardPayment(string cardNumber, string cardHolder)
        {
            _cardNumber = cardNumber;
            _cardHolder = cardHolder;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Credit Card] Paid ${amount:F2} using card ending in {_cardNumber.Substring(_cardNumber.Length - 4)}");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"[PayPal] Paid ${amount:F2} using PayPal account: {_email}");
        }
    }

    public class CryptoPayment : IPaymentStrategy
    {
        private string _walletAddress;

        public CryptoPayment(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Cryptocurrency] Paid ${amount:F2} from wallet: {_walletAddress.Substring(0, 8)}...");
        }
    }

    public class BankTransferPayment : IPaymentStrategy
    {
        private string _accountNumber;

        public BankTransferPayment(string accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"[Bank Transfer] Paid ${amount:F2} from account: {_accountNumber}");
        }
    }

    // Context
    public class PaymentContext
    {
        private IPaymentStrategy? _strategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ProcessPayment(decimal amount)
        {
            _strategy?.Pay(amount);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("   STRATEGY PATTERN DEMO - Payment Methods");
        Console.WriteLine("===========================================\n");

        var paymentContext = new StrategyPattern.PaymentContext();

        Console.WriteLine("--- Customer chooses CREDIT CARD ---");
        var creditCard = new StrategyPattern.CreditCardPayment("1234567890123456", "John Doe");
        paymentContext.SetPaymentStrategy(creditCard);
        paymentContext.ProcessPayment(150.00m);

        Console.WriteLine("\n--- Customer switches to PAYPAL ---");
        var paypal = new StrategyPattern.PayPalPayment("john@email.com");
        paymentContext.SetPaymentStrategy(paypal);
        paymentContext.ProcessPayment(150.00m);

        Console.WriteLine("\n--- Customer switches to CRYPTOCURRENCY ---");
        var crypto = new StrategyPattern.CryptoPayment("0x1234567890ABCDEF");
        paymentContext.SetPaymentStrategy(crypto);
        paymentContext.ProcessPayment(150.00m);

        Console.WriteLine("\n--- Customer switches to BANK TRANSFER ---");
        var bankTransfer = new StrategyPattern.BankTransferPayment("ACC123456789");
        paymentContext.SetPaymentStrategy(bankTransfer);
        paymentContext.ProcessPayment(150.00m);

        Console.WriteLine("\n===========================================");
        Console.WriteLine("   Strategy Pattern: DIFFERENT algorithms, SAME interface");
        Console.WriteLine("   Can switch strategies at RUNTIME!");
        Console.WriteLine("===========================================");
    }
}
