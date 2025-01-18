namespace WebHW.Animals;

public interface IAnimal
{
    string Name { get; set; }
    string HostName { get; set; }
    int Age { get; set; }

    void SaySomething()
    {
        Console.WriteLine(" I am default implementation");
    }

    void TellAboutYourself()
    {
        Console.WriteLine($"My name is '{Name}', and my host is '{HostName}', I am {Age} years old");
    }
}
