using System;

namespace SrpLab.CourseEnrollment;

public class WelcomePacketGenerator
{
         public string WelcomePacketMarkdown(string studentEmail, string studentName,string CourseCode, bool IsSeated,int WaitlistPosition)
    {
        // Content design changes with academy marketing — not with seat algorithms.
        var status =IsSeated ? "confirmed seat" : $"waitlist #{WaitlistPosition}";
        return $"# Welcome to {CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{CourseCode.ToLowerInvariant()}\n";
    }
}
