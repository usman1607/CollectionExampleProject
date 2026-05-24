namespace CollectionExampleProject
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student(int id, string name, double grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public override string ToString() 
        {
            return $"[{Id}] {Name} — Grade: {Grade}";
        }
    }
}
