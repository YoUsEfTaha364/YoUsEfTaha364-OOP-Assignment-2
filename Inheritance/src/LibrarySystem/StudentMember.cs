namespace part3;

public class StudentMember : Member
{
    public StudentMember(
        int id,
        string fullName,
        string phone)
        : base(
            id,
            fullName,
            phone,
            3,
            0,
            0)
    {
    }
}