using System;
using System.Reflection.Metadata.Ecma335;

namespace SrpLab.Checkout;

public class CouponParser
{
   public decimal ParseCoupon(string _couponRaw,decimal subtotal)
    {
         if (string.IsNullOrWhiteSpace(_couponRaw)) return 0m;
        var t = _couponRaw.Trim().ToUpperInvariant();
        if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
            return Math.Round(subtotal * pct / 100m, 2);
        if (t.Contains("FREESHIP")) return 0m; // ship is elsewhere — still parsed here
        if (t == "WELCOME10") return Math.Min(10m, subtotal);
        return 0m;
    }
}
