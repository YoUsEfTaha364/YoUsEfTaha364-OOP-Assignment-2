using System;

namespace SrpLab.Checkout;

public class GiftMessage
{
     public string GiftMessageCard(string fromName,List<(string Sku, decimal Price, int Qty)> _lines,decimal total)
    {
        // Customer-facing copy will change with marketing, not with totals.
        var items = string.Join(", ", _lines.Select(l => l.Sku));
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {total:C}\n";
    }

}
