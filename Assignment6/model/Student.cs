namespace Assignment6.model
{
    internal class Student
    {
        int id;
        public int Id { get { return id; } }
        string name;
        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
