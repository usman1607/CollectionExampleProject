namespace CollectionExampleProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 
             * Challenge Extension
                Add a menu-driven interface using a while loop and switch statement so the user can choose actions at runtime — making the system fully interactive.
             * 
             */

            var myStudent = new Student(1, "Ade", 89);
            var myStudent2 = new Student(1, "Ade", 89);


            var manager = new StudentManagementSystem();
            var exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                Console.WriteLine();
                Console.Write("Inpute your option: ");
                string op = Console.ReadLine()!;
                
                switch (op)
                {
                    case "1":
                        Console.Write("Enter student ID: ");
                        var id = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter student Name: ");
                        var name = Console.ReadLine()!;
                        Console.Write("Enter student Grade: ");
                        var grade = double.Parse(Console.ReadLine()!);

                        manager.AddStudent(id, name, grade);
                        HoldScreen();
                        break;

                    case "2":
                        Console.Write($"Enter the ID to remove: ");
                        var idToRemove = int.Parse(Console.ReadLine()!);
                        manager.UndoLastAction(idToRemove);
                        HoldScreen();
                        break;

                    case "3":
                        Console.Write("Enter the course name: ");
                        var course = Console.ReadLine()!;
                        manager.AddCourse(course);
                        HoldScreen();
                        break;

                     case "4":
                        Console.WriteLine("What is the student Id to book appointment");
                        var studId = int.Parse(Console.ReadLine()!);
                        var student = StudentManagementSystem.allStudents.Find(s => s.Id == studId);
                        if (student == null)
                        {
                            Console.WriteLine("Student not found");
                        }else
                            manager.BookAppointment(student);

                        HoldScreen();
                        break;

                      case "5":
                        // Sort by grade descending
                        StudentManagementSystem.allStudents.Sort((a, b) => b.Grade.CompareTo(a.Grade));
                        Console.WriteLine("\nRanking:");
                        foreach (var s in StudentManagementSystem.allStudents)
                            Console.WriteLine("  " + s);

                        HoldScreen();
                        break;

                     case "6":
                        var count = StudentManagementSystem.allStudents.Count;
                        var sumGrade = StudentManagementSystem.allStudents.Sum(s => s.Grade);

                        Console.WriteLine($"\nTotal Student count is: {count} and the average grade is: {sumGrade / count}");

                        HoldScreen();
                        break;

                    case "7":
                        Console.Write($"Enter the ID to find: ");
                        var idToFind = int.Parse(Console.ReadLine()!);
                        manager.FindById(idToFind);

                        HoldScreen();
                        break;

                     case "8":
                        Console.WriteLine("Serving: " + manager.ServeAppointment());
                        break;

                     case "9":
                        Console.WriteLine("\nUnique courses:");
                        foreach (string c in StudentManagementSystem.courses)
                            Console.WriteLine("  - " + c);

                        HoldScreen();
                        break;

                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid inpute...\nPress any key to try again...");
                        Console.ReadKey();
                        break;
                }
                

            }


            
        }

        public static void HoldScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. To add new student.");
            Console.WriteLine("2. To undo last action.");
            Console.WriteLine("3. To add course.");
            Console.WriteLine("4. To book an appointment.");
            Console.WriteLine("5. To print all student.");
            Console.WriteLine("6. To print student count and grages.");
            Console.WriteLine("7. To print a student.");
            Console.WriteLine("8. Serve an appointment.");
            Console.WriteLine("9. Print all courses.");
            Console.WriteLine("0. To exit.");
        }
    }
}