using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.model
{
    internal static class EmployeeExtention
    {
        public static void CalculateExperience(this Employee employee)
        {
            TimeSpan timeSpan = DateTime.Now - employee.JoinDate;
            double years = Math.Round(timeSpan.Days / 360.0,2);
            Console.WriteLine($"EmployeeID : {employee.Id} \t Experiance : {years}Yrs");
        }
    }
}
