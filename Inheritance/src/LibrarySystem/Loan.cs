namespace part3;

public class Loan
{
    public Guid LoanId { get; }

    public DateTime BorrowDate { get; }

    public DateTime DueDate { get; }

    public DateTime? ReturnDate { get; private set; }

    public Member Member { get; }

    public Item Item { get; }

    public LoanStatus Status { get; private set; }

    public decimal LateFee { get; private set; }

    public Loan(
        Guid loanId,
        DateTime borrowDate,
        Member member,
        Item item)
    {
        LoanId = loanId;
        BorrowDate = borrowDate;

        Member = member;
        Item = item;

        DueDate = borrowDate.AddDays(item.LoanPeriodDays);

        Status = LoanStatus.Borrowed;
    }

    public void Return()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException(
                "Only a borrowed loan can be returned.");

        ReturnDate = DateTime.Now;

        Status = LoanStatus.Returned;

        Item.MarkAsReturned();

        CalculateLateFee();
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException(
                "Only a borrowed loan can be marked as lost.");

        Status = LoanStatus.Lost;

        Item.MarkAsLost();
    }

    private void CalculateLateFee()
    {
        if (ReturnDate <= DueDate)
        {
            LateFee = 0;
            return;
        }

        int lateDays = (ReturnDate.Value - DueDate).Days;

        decimal feeBeforeDiscount =lateDays * Item.DailyLateFee;

        LateFee = feeBeforeDiscount - (feeBeforeDiscount * Member.DiscountPercentage / 100);
    }
}