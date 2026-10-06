using System;

namespace SrpLab.Kitchen;

public class ExpoLaneSelector
{
  public string Select(
        bool hasAllergens,
        int estimatedMinutes)
    {
        return hasAllergens
            ? "LANE-ALLERGY"
            : estimatedMinutes > 20
                ? "LANE-SLOW"
                : "LANE-FAST";
    }
}
