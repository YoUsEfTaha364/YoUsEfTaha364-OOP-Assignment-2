using System;

namespace PatternsLab.Problems.Builder;

public class FluentBuilder
{

    // mandatory
    private string StudentEmail { get; }
    private string CourseCode { get; }
    private string AccessMode { get; }
    


    //optional
   private string? GroupCode { get; set; }
    private string? DiscountCode { get;  set; }
    private bool SendWhatsApp { get; set; }
    private bool SendEmailWelcome { get; set;}
    private string? MentorNote { get; set; }
    private DateOnly? PreferredStart { get; set; }



    public FluentBuilder(string studentEmail, string courseCode, string accessMode)
    {

            if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

       

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
    }


    public FluentBuilder SetGroupCode(string groupcode)
    {
        GroupCode=groupcode;

        return this;
    }
    public FluentBuilder SetDiscountCode(string discountcode)
    {
        DiscountCode=discountcode;

        return this;
    }
    public FluentBuilder SetSendWhatsApp()
    {
        SendWhatsApp=true;

        return this;
    }
    public FluentBuilder SetEmailWelcome()
    {
        SendEmailWelcome=true;

        return this;
    }
    
    public FluentBuilder SetMentorNote(string note)
    {
        MentorNote=note;

        return this;
    }
    public FluentBuilder SetPrefferedStart(DateOnly start)
    {
        PreferredStart=start;

        return this;
    }

    public CourseRegistration Build()
    {
        
        if (AccessMode == "LiveGroup" && string.IsNullOrWhiteSpace(GroupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (AccessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(GroupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(StudentEmail,CourseCode,AccessMode,GroupCode,DiscountCode,SendWhatsApp,SendEmailWelcome,MentorNote,PreferredStart);
    }



}
