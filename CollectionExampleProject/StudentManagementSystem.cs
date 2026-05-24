namespace CollectionExampleProject
{
    public class StudentManagementSystem
    {
        public static List<Student> allStudents = new List<Student>();
        public static HashSet<string> courses = new HashSet<string>();

        private static Dictionary<int, Student> studentDB = new Dictionary<int, Student>();
        static Queue<Student> appointments = new Queue<Student>();
        static Stack<string> actionHistory = new Stack<string>();
        

        public void AddStudent(int id, string name, double grade)
        {
            Student student = new Student(id, name, grade);
            allStudents.Add(student);
            studentDB[id] = student;
            actionHistory.Push($"Added student: {name}");
            Console.WriteLine($"Added: {student}");
        }

        public void FindById(int id)
        {
            if (studentDB.TryGetValue(id, out Student? s))
                Console.WriteLine("Found: " + s);
            else
                Console.WriteLine($"ID {id} not found.");
        }

        public void UndoLastAction(int id)
        {
            if (actionHistory.Count > 0)
            {
                var student = allStudents.Where(s => s.Id == id).FirstOrDefault();
                allStudents.Remove(student);
                studentDB.Remove(id);
                Console.WriteLine("Undone: " + actionHistory.Pop());
            }                
            else
                Console.WriteLine("Nothing to undo.");
        }

        public void AddCourse(string course)
        {
            courses.Add(course);
        }

        public void BookAppointment(Student student)
        {
            appointments.Enqueue(student);
        }

        public Student ServeAppointment()
        {
            return appointments.Dequeue();
        }
    }
}
