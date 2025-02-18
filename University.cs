namespace University_OOP_Project;

class University : IGraduatable
{

    public Dictionary<string, Person>? MyDictionary { get; set; } = new Dictionary<string, Person>();

    private List<Person> _people = new List<Person>();

    public List<Person> People
    {
        get { return _people; }
        set { _people = value; }
    }

    public void AddPerson(Person person)
    {
        if (person is Student || person is Professor)
        {
            People.Add(person);
            MyDictionary?.Add(person.Id, person);
        }
    }

    public Person? FindPerson(string id)
    {
        //Person? person = People.SingleOrDefault(p => p.Id == id); // original way of finding the student or professor
        if (MyDictionary?.GetValueOrDefault(id) != null) return MyDictionary.GetValueOrDefault(id);
        return null;
    }

    public void DisplayAllPeople()
    {
        if (People != null)
            People.ForEach(p => Console.WriteLine(p.GetInfo()));
        else
            Console.WriteLine("No Students or Professors are registered in the University.");
    }

    public void Graduate()
    {
        int numberOfPeopleRemoved = People.RemoveAll(p => p is Student s && s.GPA >= 90);
        if (numberOfPeopleRemoved > 1) Console.WriteLine($"Note: There were {numberOfPeopleRemoved} students removed since they were eligible to graduate.\r\n");
        else if (numberOfPeopleRemoved == 1) Console.WriteLine("Note: There was one student removed since he/she was eligible to graduate.\r\n");
    }
}
