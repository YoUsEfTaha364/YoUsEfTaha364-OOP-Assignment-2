namespace part3;

public class Magazine : Item
{
    public Magazine(
        Guid catalogNumber,
        string title,
        decimal baseLateFeePerDay)
        : base(
            catalogNumber,
            title,
            3,
            baseLateFeePerDay,
            0.5m)
    {
    }
}