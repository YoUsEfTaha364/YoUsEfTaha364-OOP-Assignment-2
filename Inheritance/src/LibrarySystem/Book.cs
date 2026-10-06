namespace part3;

public class Book : Item
{
    public Book(
        Guid catalogNumber,
        string title,
        decimal baseLateFeePerDay)
        : base( catalogNumber,   title,  21,baseLateFeePerDay,1m)
    {
    }
}