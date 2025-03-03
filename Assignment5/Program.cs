using Assignment5.exception;
using Assignment5.model;
using Assignment5.repository;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            Console.WriteLine("Please enter your Acc/no. : ");
            InvalidAccNo:
            IUserOperations operations = new UserOperations();
            bool isSuccess = operations.GetUserByAccNo(Console.ReadLine());
            if (!isSuccess)
            {
                Console.WriteLine("Try again");
                goto InvalidAccNo;
            }
            #endregion

            #region question2 
            Console.WriteLine("Press 1 for  commercial insurance : ");
            Console.WriteLine("Press 2 for 2 wheeler insurance : ");
            Console.WriteLine("Press 3 for 3 wheeler insurance : ");
            WrongOption:
            if (!int.TryParse(Console.ReadLine(), out int option) || option < 1 || option > 3)
            {
                Console.WriteLine("Invalid option");
                goto WrongOption;
            }
            if(option == 1)
            {
                new Commercial().InsuranceCalculation();
            }
            if (option == 2) 
            { 
                new TwoWheeler().InsuranceCalculation();
            }
            if (option == 3)
            {
                new ThreeWheelers().InsuranceCalculation();
            }
            #endregion
        }
    }
}
