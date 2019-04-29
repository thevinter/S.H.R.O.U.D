using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldVariables 
{
    private static int currentDay = 1;
    public static bool dayChange = false;
    public static bool caveEvent = false;
    
    public static int GetCurrentDay()
    {
        return currentDay;
    }

    public static void IncrementCurrentDay()
    {
        currentDay++;
    }
}
