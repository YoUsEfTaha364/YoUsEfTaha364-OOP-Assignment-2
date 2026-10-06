namespace part3;

public class Member : Person
{
    private readonly List<Loan> _currentLoans = new();
    private readonly List<Loan> _loanHistory = new();

    private int _readingPoints;

    public IReadOnlyList<Loan> CurrentLoans => _currentLoans;

    public IReadOnlyList<Loan> LoanHistory => _loanHistory;

    public int ReadingPoints => _readingPoints;

    public decimal DiscountPercentage { get; }

    protected int MaxLoanItems { get; }

    protected int PointsPerReturnedLoan { get; }

    protected Member(
        int id,
        string fullName,
        string phone,
        int maxLoanItems,
        decimal discountPercentage,
        int pointsPerReturnedLoan)
        : base(id, fullName, phone)
    {
        MaxLoanItems = maxLoanItems;
        DiscountPercentage = discountPercentage;
        PointsPerReturnedLoan = pointsPerReturnedLoan;
    }

    public Loan BorrowItem(Item item)
    {
        if (_currentLoans.Count >= MaxLoanItems)
            throw new InvalidOperationException(
                "Loan limit reached.");

        if (item.IsWithdrawn)
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");

        if (item.IsOnLoan)
            throw new InvalidOperationException(
                "Item is already on loan.");

        item.MarkAsBorrowed();

        Loan loan = new Loan(
            Guid.NewGuid(),
            DateTime.Now,
            this,
            item);

        _currentLoans.Add(loan);
        _loanHistory.Add(loan);

        return loan;
    }

    public void ReturnItem(Item item)
    {
        Loan loan = FindCurrentLoan(item);

        loan.Return();

        _currentLoans.Remove(loan);

        _readingPoints += PointsPerReturnedLoan;
    }

    private Loan FindCurrentLoan(Item item)
    {
        foreach (Loan loan in _currentLoans)
        {
            if (loan.Item == item)
                return loan;
        }

        throw new InvalidOperationException(
            "This item is not currently borrowed by this member.");
    }

    public Loan BorrowItem(Item item, DateTime borrowDate)
{
    if (_currentLoans.Count >= MaxLoanItems)
        throw new InvalidOperationException(
            "Loan limit reached.");

    if (item.IsWithdrawn)
        throw new InvalidOperationException(
            "A withdrawn item cannot be borrowed.");

    if (item.IsOnLoan)
        throw new InvalidOperationException(
            "Item is already on loan.");

    item.MarkAsBorrowed();

    Loan loan = new Loan(
        Guid.NewGuid(),
        borrowDate,
        this,
        item);

    _currentLoans.Add(loan);
    _loanHistory.Add(loan);

    return loan;
}
}