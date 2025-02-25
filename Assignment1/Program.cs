namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            string name;
            int age;
            double percentage;
            Console.WriteLine("Please Enter");
            Console.WriteLine("Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Age : ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Percentage : ");
            percentage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Name is {name}, age is {age}, percentage is {percentage}");
            #endregion

            #region question2
            Console.WriteLine("Enter Age : ");
            bool isProper;
            isProper = int.TryParse(Console.ReadLine(), out age);
            Console.WriteLine(isProper ? age : "Bad Input");
            #endregion

            #region question3
            string? email;
            Console.WriteLine("Enter Email : ");
            email = Console.ReadLine();
            Console.WriteLine((email != null && email.Length > 0) ? email : "Email cannot be empty");
            #endregion

            #region question4
            wrongDate:
            Console.WriteLine("Input discharge Date : ");
            bool isDate = DateTime.TryParse(Console.ReadLine(), out DateTime date);
            if (!isDate)
            {
                Console.WriteLine("Invalid input");
                goto wrongDate;
            }
            Console.WriteLine((date != null) ? "Discharge date : " + date.ToString("dd/MM/yyyy") : "Not Discharged");
            #endregion
        }
    }
}
