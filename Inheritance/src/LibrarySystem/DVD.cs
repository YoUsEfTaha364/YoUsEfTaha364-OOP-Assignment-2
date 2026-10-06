namespace part3;

public class DVD : Item
{
    public DVD(
        Guid catalogNumber,
        string title,
        decimal baseLateFeePerDay)
        : base(catalogNumber,title,7,baseLateFeePerDay,2m)
    {
    }
}