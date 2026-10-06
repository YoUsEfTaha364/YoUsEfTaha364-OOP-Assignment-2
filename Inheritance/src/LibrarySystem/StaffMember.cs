namespace part3;

public class StaffMember : Person
{
    public DateTime HireDate { get; }

    public decimal MonthlySalary { get; private set; }

    protected decimal ResponsibilityAllowance { get; }

    protected StaffMember(
        int id,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        decimal responsibilityAllowance = 0)
        : base(id, fullName, phone)
    {
        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        ResponsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentOutOfRangeException(nameof(percentage));

        MonthlySalary += MonthlySalary * percentage / 100;
    }

    public decimal MonthlyPay =>
        MonthlySalary + ResponsibilityAllowance;
}