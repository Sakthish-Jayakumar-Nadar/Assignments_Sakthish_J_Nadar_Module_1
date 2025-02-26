using Assignment4.model;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            User u1 = new User(1,"Om");
            User u2 = new User(2, "Auti");
            Console.WriteLine("Logged In user count : " + u1.GetTotalLoggedInUsers());
            Console.WriteLine("Logged In user count : " + u2.GetTotalLoggedInUsers());
            #endregion

            #region question2
            Employee employee = new Employee("Om", 100000);
            employee.DisplayDetails();
            Manager manager = new Manager("Sakthish", 10000000, 1000000);
            manager.DisplayDetails();
            #endregion
        }
    }
}
