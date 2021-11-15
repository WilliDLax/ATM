using System;

//Simple demonstration of using delegates for callbacks and anonymous methods
//using simple ATM operations as an example

namespace ATM
{
    public delegate void CallBalance(double balance);
    public delegate void CreateAnonymous();

    class Program
    {
        //created for call back purposes
        static void Call(double balance)
        {
            Console.WriteLine("Your remaining balance is {0}", balance);
        }

        static void Main(string[] args)
        {
            ATM atm = new ATM();

            //Withdraw money, calls back balance after withdrawal
            atm.Withdraw(Call);

            //Transfer money using an anonymous method
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
