using System;

namespace SrpLab.GradeBookF;

public class HonorPolicy
{
  public bool Meets(decimal average, string letter)
    {
        return average >= 85 && letter is "A" or "B";
    }
}
