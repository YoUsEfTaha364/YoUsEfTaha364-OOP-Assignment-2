namespace part3;

public class Shelver : StaffMember
{
    public string Section { get; private set; }

    public Shelver(
        int id,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        string section)
        : base(
            id,
            fullName,
            phone,
            hireDate,
            monthlySalary)
    {
        Section = section;
    }

    public void ReassignSection(string section)
    {
        Section = section;
    }
}