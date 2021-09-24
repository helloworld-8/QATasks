using System;
using Task1.Classes;
using Task1.Exceptions;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is an online electricity declaration system.");

            DateTime declarationDate = DateTime.Now;

            try {
                DeclarationClass declarationClass = new DeclarationClass();
                declarationClass.Declare(declarationDate);
                Console.WriteLine(declarationClass.AccountingPeriodStartDate);
                Console.WriteLine(declarationClass.AccountingPeriodEndDate);
            }
            catch (DeclarationIsNotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DeclarationPeriodCanNotBeSetException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
