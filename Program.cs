namespace University_OOP_Project;

internal class Program
{
    static void Main(string[] args)
    {

        // Create multiple Student and Professor objects.
        Console.WriteLine("DEMO: Create multiple Student and Professor objects.\r\n");

        Student student1 = new Student("Joey", 23, 93, ["Biology", "Chemistry", "Calculus"]);
        Student student2 = new Student("Mark", 23, 87, ["Biology", "Chemistry", "Geography"]);
        Student student3 = new Student("Chaim", 23, 77, ["Sociology", "Science", "Calculus"]);

        Professor professor1 = new Professor("Teacher Yoel", 34, (decimal)35888.45, ["Chemistry", "Biology", "Math"]);
        Professor professor2 = new Professor("Teacher Reuben", 34, (decimal)43000.54, ["Chemistry", "Science", "Math"]);
        Professor professor3 = new Professor("Teacher Yitzi", 34, (decimal)56000.76, ["Science", "Biology"]);

        //////////////////////////////////////////////////////////////////////////////////////////////

        // Store them in a University instance
        Console.WriteLine("DEMO: Store them in a University instance.\r\n");

        University university = new University();
        university.AddPerson(student1);
        university.AddPerson(student2);
        university.AddPerson(student3);
        university.AddPerson(professor1);
        university.AddPerson(professor2);
        university.AddPerson(professor3);

        //////////////////////////////////////////////////////////////////////////////////////////////

        // Display all people.
        Console.WriteLine("DEMO: Display all people.\r\n" +
                          "Note: For the sake of showing the Graduatable function's use,\r\n" +
                          "I included a student (Joey) whose GPA is over 90 (graduatable)\r\n" +
                          "After displaying all people through the console menu (selection 5),\r\n" +
                          "the Graduate function will be called and you can see that the\r\n" +
                          "student has been removed.\r\n");
        university.DisplayAllPeople();
        Console.WriteLine();

        //////////////////////////////////////////////////////////////////////////////////////////////


        // Ensuring a smooth cancellation of the program in case a user tries 
        // to cancel the program when asked prompted for a switch input
        Console.CancelKeyPress += (sender, e) =>
        {
            Console.WriteLine("Exiting Program.");
            e.Cancel = true;
            Environment.Exit(0);
        };
        while (true)
        {
            ConsoleMenu(university);
        }

    }


    static void ConsoleMenu(University university)
    {
        Console.WriteLine("\nEnter a number to perform an action:\r\n");
        Console.WriteLine("1. Add a student\r\n" +
                          "2. Add a professor\r\n" +
                          "3. Enroll student in a course\r\n" +
                          "4. Assign a subject to a professor\r\n" +
                          "5. Display all people\r\n");
        Console.WriteLine("Note: Press Ctrl + C to exit the program\n");

        // validate proper choice type and range
        int choice;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 1 || choice > 5)
            {
                Console.WriteLine("The number must be 1, 2, 3, 4, or 5. Please try again.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid choice: " + ex.Message + "\r\nPlease try again.");
            return;
        }

        // declaring various variables which will be used in the switch
        string Name; int age; Student student; bool success = false; Professor professor; string id;
        switch (choice)
        {
            case 1:
                while (!success)
                {
                    try
                    {
                        // Add a student
                        Console.WriteLine("Enter the student's name:\n");
                        Name = Console.ReadLine()!;
                        Console.WriteLine("Enter the student's age (whole numbers only):\n");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (age < 0 || age > 120) throw new Exception("Age must be between 0 and 120");
                        Console.WriteLine("Enter the student's GPA (can be in decimal format):\n");
                        double GPA = Convert.ToDouble(Console.ReadLine());
                        if (GPA < 0 || GPA > 100) throw new Exception("GPA msut be between 0 and 100");
                        Console.WriteLine("Enter the student's courses one at a time.\r\n");
                        List<string> listOfCourses = new List<string>();
                        while (true)
                        {
                            Console.WriteLine("Enter a course or STOP if you are finished adding courses:\n");
                            string course = Console.ReadLine()!;
                            if (course == "STOP") break;
                            listOfCourses.Add(course.Trim());
                        }
                        student = new Student(Name, age, GPA, listOfCourses);
                        university.AddPerson(student);
                        success = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Input: " + ex.Message + "\r\nPlease try again.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message + "\r\nPlease try again.");
                    }
                }
                break;
            case 2:
                // Add a professor
                success = false;
                while (!success)
                {
                    try
                    {
                        Console.WriteLine("Enter the professor's name:\n");
                        Name = Console.ReadLine()!;
                        Console.WriteLine("Enter the professor's age (whole numbers only):\n");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (age < 0 || age > 120) throw new Exception("Age must be between 0 and 120");
                        Console.WriteLine("Enter the professor's salary (can be in decimal format):\n");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter the subjects taught by the professor one at a time.\r\n");
                        List<string> listOfSubjects = new List<string>();
                        while (true)
                        {
                            Console.WriteLine("Enter a subject or STOP if you are finished adding courses:\n");
                            string subject = Console.ReadLine()!;
                            if (subject == "STOP") break;
                            listOfSubjects.Add(subject.Trim());
                        }
                        professor = new Professor(Name, age, salary, listOfSubjects);
                        university.AddPerson(professor);
                        success = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Input: " + ex.Message + "\r\nPlease try again.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message + "\r\nPlease try again.");
                    }
                }
                break;
            case 3:
                // Enroll student in a course
                success = false;
                while (!success)
                {
                    try
                    {
                        Console.WriteLine("Enter the id of a student\nfrom one of the student's listed above:\n");
                        id = Console.ReadLine()!;
                        student = (Student)university.FindPerson(id)!;
                        Console.WriteLine("Enter a course:\n");
                        string studentCourse = Console.ReadLine()!;
                        student.EnrollCourse(studentCourse);
                        success = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Input: " + ex.Message + "\r\nPlease try again.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message + "\r\nPlease try again.");
                    }
                }
                break;
            case 4:
                // Assign a subject to a professor 
                success = false;
                while (!success)
                {
                    try
                    {
                        Console.WriteLine("Enter the id of a professor\nfrom one of the professor's listed above:\n");
                        id = Console.ReadLine()!;
                        professor = (Professor)university.FindPerson(id)!;
                        Console.WriteLine("Enter a subject:\n");
                        string professorSubject = Console.ReadLine()!;
                        professor.AssignSubject(professorSubject);
                        success = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Input: " + ex.Message + "\r\nPlease try again.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message + "\r\nPlease try again.");
                    }
                }
                break;
            case 5:
                success = false;
                while (!success)
                {
                    try
                    {
                        university.Graduate(); // call the Graduate function to remove students whose GPA is over 90
                        university.DisplayAllPeople(); // Display all people
                        success = true;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Invalid Input: " + ex.Message + "\r\nPlease try again.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message + "\r\nPlease try again.");
                    }
                }
                break;
            default:
                break;
        }
    }
}
