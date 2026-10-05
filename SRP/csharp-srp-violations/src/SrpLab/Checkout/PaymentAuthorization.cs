using System;

namespace SrpLab.Checkout;

public class PaymentAuthorization
{
   public string AuthorizePaymentStub(string cardLast4,decimal total,int count)
    {
        // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
        var payload = $"{total:0.00}|{cardLast4}|{count}";
        var hash = payload.GetHashCode();
        return $"AUTH-{Math.Abs(hash):X8}";
    }
}
