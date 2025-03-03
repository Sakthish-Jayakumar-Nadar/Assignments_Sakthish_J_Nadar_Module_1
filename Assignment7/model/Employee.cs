using System.Runtime.CompilerServices;

namespace Assignment7.model
{
    internal class Employee
    {
        public int Id { get; }
        public string Name { get; }    
        public DateTime JoinDate { get; }

        public Employee(int id, string name, DateTime joinDate)
        {
            Id = id;
            Name = name;    
            JoinDate = joinDate;
        }
    }
}
