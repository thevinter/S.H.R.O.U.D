using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PickedItems 
{
    public static List<float> itemPositions = new List<float>();
    public static List<float> openedChests = new List<float>();

    static public void OpenChest(float pos)
    {
        openedChests.Add(pos);
    }

    static public bool IsOpened(float pos)
    {
        foreach (float i in openedChests)
        {
            if (i == pos)
                return true;
        }
        return false;
    }


    static public void AddItem(float pos)
    {
        itemPositions.Add(pos);
    }

    static public bool IsPresent(float pos)
    {
        foreach (float i in itemPositions)
        {
            if (i == pos)
                return true;
        }
        return false;
    }   

}
