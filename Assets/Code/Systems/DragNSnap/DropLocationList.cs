using System.Collections.Generic;
using UnityEngine;

public class DropLocationList
{
    List<DropLocation> dLocations;

    public DropLocationList(List<DropLocation> dList)
    {
        dLocations = dList;
    }

    public DropLocation SearchLocations(Transform target)
    {
        DropLocation targetDrop = null;

        dLocations.ForEach(location =>
        {
            if (location.GetTF() == target)
                targetDrop = location;
        });

        return targetDrop;
    }
}