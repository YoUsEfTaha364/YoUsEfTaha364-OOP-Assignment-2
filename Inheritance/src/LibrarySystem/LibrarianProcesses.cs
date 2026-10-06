namespace part3;

public class Librarian : StaffMember
{
    public Librarian(
        int id,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base(
            id,
            fullName,
            phone,
            hireDate,
            monthlySalary)
    {
    }

    public void ReturnItem(Member member, Item item)
    {
        member.ReturnItem(item);
    }

    public void MarkItemAsLost(Member member, Item item)
    {
        Loan loan = FindCurrentLoan(member, item);

        loan.MarkAsLost();
    }

    private Loan FindCurrentLoan(Member member, Item item)
    {
        foreach (Loan loan in member.CurrentLoans)
        {
            if (loan.Item == item)
                return loan;
        }

        throw new InvalidOperationException(
            "This item is not  borrowed by this member.");
    }
}