using System;

namespace SrpLab.CourseEnrollment;

public class TuitionInvoiceGenerator
{
    public string TuitionInvoiceLine(string studentEmail,string CourseCode,decimal Tuition,bool IsSeated)
    {
        // Finance formatting / tax later — separate from enrollment capacity.
        if (!IsSeated) return $"{CourseCode},WAITLIST,0.00";
        var vat = Math.Round(Tuition * 0.14m, 2);
        return $"{CourseCode},TUITION,{Tuition:0.00},VAT,{vat:0.00},TOTAL,{(Tuition + vat):0.00}";
    }
}
