namespace CollectionExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new StudentManagementSystem();

            manager.AddStudent(1, "Usman", 85);
            manager.AddStudent(2, "Aisha", 92);
            manager.AddStudent(3, "Emeka", 78);

            manager.AddCourse("C# Programming");
            manager.AddCourse("Data Structures");
            manager.AddCourse("C# Programming");  // duplicate — ignored
            manager.AddCourse("Web Development");

            manager.FindById(2);

            manager.BookAppointment(StudentManagementSystem.allStudents[0]);
            manager.BookAppointment(StudentManagementSystem.allStudents[1]);
            Console.WriteLine("Serving: " + manager.ServeAppointment());

            manager.UndoLastAction(3);

            // Sort by grade descending
            StudentManagementSystem.allStudents.Sort((a, b) => b.Grade.CompareTo(a.Grade));
            Console.WriteLine("\nRanking:");
            foreach (var s in StudentManagementSystem.allStudents)
                Console.WriteLine("  " + s);

            Console.WriteLine("\nUnique courses:");
            foreach (string c in StudentManagementSystem.courses)
                Console.WriteLine("  - " + c);

            var count = StudentManagementSystem.allStudents.Count;
            var sumGrade = StudentManagementSystem.allStudents.Sum(s => s.Grade);

            Console.WriteLine($"\nTotal Student count is: {count} and the average grade is: {sumGrade/count}");
        }
    }
}