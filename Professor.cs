namespace University_OOP_Project;

class Professor : Person
{
    private decimal _salary;
    private List<string> _subjectsTaught = new List<string>();

    public decimal Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }

    public List<string> SubjectsTaught
    {
        get { return _subjectsTaught; }
        set { _subjectsTaught = value; }
    }

    public Professor(string name, int age, decimal salary, List<string> subjectsTaught) : base(name, age)
    {
        Salary = salary;
        SubjectsTaught = subjectsTaught;
    }

    public void AssignSubject(string subject)
    {
        SubjectsTaught.Add(subject);
    }

    public override string GetInfo()
    {
        return "Role: Professor, " + base.GetInfo() + $"Salary: {Salary}, Subjects Taught: {string.Join(", ", SubjectsTaught)}";
    }
}
