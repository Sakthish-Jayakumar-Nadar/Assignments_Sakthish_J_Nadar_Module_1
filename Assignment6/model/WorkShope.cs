using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.model
{
    internal class WorkShope
    {
        int id;
        public int Id { get { return id; } }
        string name;
        public string Name { get { return name; } }
        public Dictionary<int, Student> Students;
        public WorkShope(int id, string name)
        {
            this.id = id;
            this.name = name;
            Students = new Dictionary<int, Student>();
        }
    }
}
