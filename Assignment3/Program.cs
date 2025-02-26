using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Assignment3.Model;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            Car car1 = new Car();
            car1.SetCarDetails(1, "Mahendra", "TUV100", "2015", 500000);
            car1.DisplayCarDetails();
            #endregion

            #region question2
            Car car2 = new Car();
            car2.CarId = 2;
            car2.Brand = "MaruthiSuzuki";
            car2.Model = "Shift";
            car2.Year = "2018";
            car2.Price = 700000;
            car2.DisplayCarDetails();

            Car car3 = new Car(3, "TATA", "Nano", "2010", 150000);
            car3.DisplayCarDetails();
            #endregion

            #region question3
            StringBuilder sb = new StringBuilder("");
            Console.WriteLine("Type Password");
        wrongPassword:
            sb.Append(Console.ReadLine());
            if (sb.Length < 6)
            {
                Console.WriteLine("Length must be atleast 6 character long");
                Console.WriteLine("Try Again");
                sb.Clear();
                goto wrongPassword;
            }
            else if (!sb.ToString().Any(Char.IsLower))//!Regex.IsMatch(sb.ToString(), "(?=.*[a-z])")
            {
                Console.WriteLine("Require atleast 1 lowercase");
                Console.WriteLine("Try Again");
                sb.Clear();
                goto wrongPassword;
            }
            else if (!sb.ToString().Any(Char.IsUpper))//!Regex.IsMatch(sb.ToString(), "(?=.*[A-Z])")
            {
                Console.WriteLine("Require atleast 1 uppercase");
                Console.WriteLine("Try Again");
                sb.Clear();
                goto wrongPassword;
            }
            else if (!sb.ToString().Any(Char.IsDigit))//!Regex.IsMatch(sb.ToString(), "(?=.*\\d)")
            {
                Console.WriteLine("Require atleast 1 digit");
                Console.WriteLine("Try Again");
                sb.Clear();
                goto wrongPassword;
            }
            Console.WriteLine("Password created successfully");
            Console.WriteLine("Password : " + sb.ToString());
            #endregion
        }
    }
}
