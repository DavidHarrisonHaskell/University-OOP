namespace University_OOP_Project;

class Student : Person
{

    private double _gpa;
    private List<string> _courses = new List<string>();

    public double GPA
    {
        get { return _gpa; }
        set { _gpa = value; }
    }


    public List<string> Courses
    {
        get { return _courses; }
        set { if (value != null) _courses = value; }
    }


    public Student(string name, int age, double gpa, List<string> courses) : base(name, age)
    {
        GPA = gpa;
        Courses = courses;
    }

    public void EnrollCourse(string course)
    {
        Courses.Add(course);
    }

    public override string GetInfo()
    {
        return $"Role: Student, " + base.GetInfo() + $"GPA: {GPA}, Courses: {string.Join(", ", Courses)}";
    }
}