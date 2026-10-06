namespace part3;

public class PremiumMember : Member
{
    public PremiumMember(
        int id,
        string fullName,
        string phone,
        decimal discountPercentage)
        : base(
            id,
            fullName,
            phone,
            10,
            discountPercentage,
            5)
    {
    }
}