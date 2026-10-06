namespace part3;

public class Item
{
    public Guid CatalogNumber { get; }
    public string Title { get; }

    public int LoanPeriodDays { get; }

    private decimal _baseLateFeePerDay;
    private decimal _multiplier;

    public decimal DailyLateFee
    {
        get
        {
            return _baseLateFeePerDay * _multiplier;
        }
    }

    public bool IsWithdrawn { get; private set; }

    public bool IsOnLoan { get; private set; }

    protected Item(
        Guid catalogNumber,
        string title,
        int loanPeriodDays,
        decimal baseLateFeePerDay,
        decimal lateFeeMultiplier)
    {
        CatalogNumber = catalogNumber;
        Title = title;
        LoanPeriodDays = loanPeriodDays;
        _baseLateFeePerDay = baseLateFeePerDay;
        _multiplier = lateFeeMultiplier;
    }

    public void UpdateLateFee(decimal newBaseFee)
    {
        if (newBaseFee < 0)
            throw new ArgumentOutOfRangeException(nameof(newBaseFee));

        _baseLateFeePerDay = newBaseFee;
    }

    public void Withdraw()
    {
        if (IsOnLoan)
            throw new InvalidOperationException(
                "An item on loan cannot be withdrawn.");

        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    internal void MarkAsBorrowed()
    {
        if (IsWithdrawn)
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");

        if (IsOnLoan)
            throw new InvalidOperationException(
                "An item that is already on loan cannot be borrowed.");

        IsOnLoan = true;
    }

    internal void MarkAsReturned()
    {
        IsOnLoan = false;
    }

    internal void MarkAsLost()
    {
        IsOnLoan = false;
    }
}