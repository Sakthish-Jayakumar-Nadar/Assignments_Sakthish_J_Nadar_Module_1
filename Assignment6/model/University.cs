namespace Assignment6.model
{
    internal class University
    {
        Dictionary<int, WorkShope> workShopes;
        public University()
        {
            workShopes = new Dictionary<int, WorkShope>();
        }
        public void CreateWorkShope(WorkShope workShope)
        {
            bool isAdded = workShopes.TryAdd<int, WorkShope>(workShope.Id,workShope);
            if (isAdded)
            {
                Console.WriteLine($"{workShope.Name} created successfully");
            }
            else
            {
                Console.WriteLine($"{workShope.Name} already exist");
            }
        }
        public void RegisterForWorkShope(Student student,int workshopeId)
        {
            bool isWorkShope = workShopes.TryGetValue(workshopeId, out WorkShope value);
            if (isWorkShope)
            {
                bool isStudentAdded = value.Students.TryAdd<int, Student>(student.Id, student);
                if (isStudentAdded)
                {
                    Console.WriteLine($"Student id : {student.Id}, Registered successfully for {value.Name}");
                }
                else
                {
                    Console.WriteLine($"Student id : {student.Id}, Already registered for {value.Name}");
                }
            }
            else
            {
                Console.WriteLine("Workshope does not exist");
            }
        }
    }
}
