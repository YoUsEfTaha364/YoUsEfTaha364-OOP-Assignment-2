namespace part3;

public class HeadLibrarian : StaffMember
{
    public HeadLibrarian(
        int id,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base( id,fullName, phone,hireDate, monthlySalary, 400)
    {
    }

    public void ChangeLateFeePrice(Item item, decimal newPrice)
    {
        item.UpdateLateFee(newPrice);
    }

    public void WithdrawItem(Item item)
    {
        item.Withdraw();
    }

    public void RestoreItem(Item item)
    {
        item.Restore();
    }
}