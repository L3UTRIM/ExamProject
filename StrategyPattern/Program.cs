using StrategyPattern;

Console.WriteLine("===========================================");
Console.WriteLine("   STRATEGY PATTERN DEMO - Payment Methods");
Console.WriteLine("===========================================\n");

var paymentContext = new PaymentContext();

Console.WriteLine("--- Customer chooses CREDIT CARD ---");
var creditCard = new CreditCardPayment("1234567890123456", "John Doe");
paymentContext.SetPaymentStrategy(creditCard);
paymentContext.ProcessPayment(150.00m);

Console.WriteLine("\n--- Customer switches to PAYPAL ---");
var paypal = new PayPalPayment("john@email.com");
paymentContext.SetPaymentStrategy(paypal);
paymentContext.ProcessPayment(150.00m);

Console.WriteLine("\n--- Customer switches to CRYPTOCURRENCY ---");
var crypto = new CryptoPayment("0x1234567890ABCDEF");
paymentContext.SetPaymentStrategy(crypto);
paymentContext.ProcessPayment(150.00m);

Console.WriteLine("\n--- Customer switches to BANK TRANSFER ---");
var bankTransfer = new BankTransferPayment("ACC123456789");
paymentContext.SetPaymentStrategy(bankTransfer);
paymentContext.ProcessPayment(150.00m);

Console.WriteLine("\n===========================================");
Console.WriteLine("   Strategy Pattern: DIFFERENT algorithms, SAME interface");
Console.WriteLine("   Can switch strategies at RUNTIME!");
Console.WriteLine("===========================================");
