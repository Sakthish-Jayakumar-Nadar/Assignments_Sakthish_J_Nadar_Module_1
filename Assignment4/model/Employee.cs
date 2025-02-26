using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.model
{
    internal class Employee
    {
        public string name;
        public double salary;
        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee name : {name} \t Employee salary : {salary}");
        }
    }
}
