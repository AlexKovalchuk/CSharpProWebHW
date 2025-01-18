namespace WebHW.Animals;

public class Dog :IAnimal
{
    public Dog()
    {
        Name = "Huan";
        HostName = "Manwë";
        Age = 777;
    }

    public Dog(string name, string hostName, int age)
    {
        Name = name;
        HostName = hostName;
        Age = age;
    }

    public string Name { get; set; }
    public string? HostName { get; set; }
    public int Age { get; set; }
}
