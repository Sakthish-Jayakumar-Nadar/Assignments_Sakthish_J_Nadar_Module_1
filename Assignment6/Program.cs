using Assignment6.model;

namespace Assignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1
            Banks banks = new Banks();
            Customer customer1 = new Customer(1, "Sakthish J. Nadar");
            customer1.GetTokenNo(banks);
            Customer customer2 = new Customer(2, "Om Auti");
            customer2.GetTokenNo(banks);
            Customer customer3 = new Customer(3, "Shreekan");
            customer3.GetTokenNo(banks);
            banks.NextInQueue();
            banks.OutFromQueue();
            banks.NextInQueue();
            #endregion

            Console.WriteLine("\n \n");

            #region question2
            University university = new University();
            WorkShope art = new WorkShope(1, "Art workshop");
            WorkShope music = new WorkShope(2, "Music workshop");
            WorkShope literature = new WorkShope(3, "Literature workshop");
            Student student1 = new Student(1, "Sakthish J. Nadar");
            Student student2 = new Student(2, "Om Auti");
            Student student3 = new Student(3, "Shreekant");
            Student student5 = new Student(5, "Rahul");
            Student student6 = new Student(6, "Parnit");
            university.CreateWorkShope(art);
            university.CreateWorkShope(music);
            university.CreateWorkShope(literature);
            university.CreateWorkShope(literature);
            university.RegisterForWorkShope(student1, art.Id);
            university.RegisterForWorkShope(student2, art.Id);
            university.RegisterForWorkShope(student2, music.Id);
            university.RegisterForWorkShope(student2, music.Id);
            university.RegisterForWorkShope(student3, music.Id);
            university.RegisterForWorkShope(student5, literature.Id);
            university.RegisterForWorkShope(student6, literature.Id);
            #endregion
        }
    }
}
