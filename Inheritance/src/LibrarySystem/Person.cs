namespace part3;

public class Person
{
    public int Id { get; }
    public string FullName { get; }
    public string Phone { get; }

    protected Person(int id, string fullName, string phone)
    {
        Id = id;
        FullName = fullName;
        Phone = phone;
    }
}