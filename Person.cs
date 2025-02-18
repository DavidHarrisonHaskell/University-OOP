namespace University_OOP_Project;

abstract class Person
{
    private readonly string _id = Guid.NewGuid().ToString();
    private string _name = null!;
    private int _age;

    public string Id => _id;


    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }


    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }


    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual object GetInfo()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}, ";
    }


}
