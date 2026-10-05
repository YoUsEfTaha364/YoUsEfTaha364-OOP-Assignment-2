using System;

namespace SrpLab.Warehouse;

public class WmsXmlBatchGenerator
{
       public string Generate(
        string batchId,
        IReadOnlyList<(string Sku, int Allocated)> allocations)
    {
        var parts = allocations
            .Select(a =>
                $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");

        return $"<batch id=\"{batchId}\">" +
               $"{string.Join("", parts)}</batch>";
    }

}
