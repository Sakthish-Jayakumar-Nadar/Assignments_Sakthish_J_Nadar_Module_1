namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            double baseSalary = 0;
        wrongSalaryInput:
            Console.WriteLine("Please enter basic your basic salary");
            bool isProper = double.TryParse(Console.ReadLine(), out baseSalary);
            if (!isProper || baseSalary <= 0)
            {
                Console.WriteLine("Invalid salary");
                goto wrongSalaryInput;
            }
            double tax = baseSalary / 10;
            Random ratingGenerator = new Random();
            int rating = ratingGenerator.Next(1, 11);
            Console.WriteLine("Basic salary : " + (baseSalary));
            Console.WriteLine("Tax deduction : " + (tax));
            Console.WriteLine("Rating : " + (rating));
            if (rating < 5)
            {
                Console.WriteLine("Final salary : " + (baseSalary - tax));
            }
            else if (rating < 8)
            {
                Console.WriteLine("Final salary : " + (baseSalary));
            }
            else {
                Console.WriteLine("Final salary : " + (baseSalary + tax));
            }
            #endregion

            #region question2
            Console.WriteLine("Welcom to Indian Railway");
            wrongOption:
            Console.WriteLine("Press 1 for General ticket (200rs/ticket)");
            Console.WriteLine("Press 2 for Sleeper ticket (500rs/ticket)");
            Console.WriteLine("Press 3 for Ac ticket (1000rs/ticket)");
            Console.WriteLine("Press 4 to exit");
            int option = 0;
            bool isOption = int.TryParse(Console.ReadLine(),out option);
            if (!isOption || option > 4 || option < 0)
            {
                Console.WriteLine("Invalid option");
                goto wrongOption;
            }
        wrongTicketCount:
            bool isNumber = true;
            int numberOfTickets = 0;
            if (option < 4)
            {
                Console.WriteLine("Please enter number of tickets");
                isNumber = int.TryParse(Console.ReadLine(), out numberOfTickets);
            }
            if (!isNumber || numberOfTickets < 0) 
            {
                goto wrongTicketCount;
            }
            if (option == 1)
            {
                Console.WriteLine("General (200rs/ticket) * " + numberOfTickets + " = " + (200 * numberOfTickets) + "Rs");
                goto wrongOption;
            }
            else if (option == 2)
            {
                Console.WriteLine("Sleeper (500rs/ticket) * " + numberOfTickets + " = " + (500 * numberOfTickets) + "Rs");
                goto wrongOption;
            }
            else if (option == 3)
            {
                Console.WriteLine("Ac (1000rs/ticket) * " + numberOfTickets + " = " + (1000 * numberOfTickets) + "Rs");
                goto wrongOption;
            }
            Console.WriteLine("Thank You");
            #endregion

            #region question3
            int[,] userAndWallet = new int[5, 2]{
                { 1, 1000 },
                { 2, 1500 },
                { 3, 2000 },
                { 4, 2500 },
                { 5, 3000 },
            };
        wrongId:
            Console.WriteLine("Enter Id to check wallet");
            bool isId = int.TryParse(Console.ReadLine(), out int id);
            if (!isId || id < 0 || id > 5) {
                Console.WriteLine("Invalid Id");
                goto wrongId;
            }
            for (int i = 0; i < userAndWallet.GetLength(0); i++)
            {
                if (userAndWallet[i,0] == id)
                {
                    Console.WriteLine("Your wallet amount is " + userAndWallet[i,1] + "Rs");
                }
            }
            #endregion
        }
    }
}
