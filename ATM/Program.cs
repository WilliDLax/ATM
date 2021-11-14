using System;

namespace ATM
{
    public delegate void CallBalance(double balance);
    public delegate void CreateAnonymous();

    class Program
    {
        static void Call(double balance)
        {
            Console.WriteLine("Your remaining balance is {0}", balance);
        }

        static void Main(string[] args)
        {
            //Operations of an atm
            ATM atm = new ATM();

            //Check balance

            //Withdraw money
            atm.Withdraw(Call);

            //Transfer money
            CreateAnonymous transfer = delegate()
            {
                Console.WriteLine("How much would you like to transfer? ");
                double amount = double.Parse(Console.ReadLine());

                atm.Balance -= amount;
                Console.WriteLine("Your balance after transfer is {0}",atm.Balance);
            };
            transfer();
        }

    }


    class ATM
    {
        public double Balance { get; set; } = 50000;

        public void Withdraw(CallBalance call)
        {
            Console.WriteLine("Enter withdrawal amount: ");
            double amount = double.Parse(Console.ReadLine());

            Balance -= amount;
            call(Balance);
        }
    }
}
