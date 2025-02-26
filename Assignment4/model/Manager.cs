using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment4.model
{
    internal class Manager : Employee
    {
        public double bonus;
        public Manager(string name, double salary, double bonus):base(name, salary)
        {
            this.bonus = bonus;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Manager name : {name} \t Manager salary with bonus : {salary + bonus}");
        }
    }
}