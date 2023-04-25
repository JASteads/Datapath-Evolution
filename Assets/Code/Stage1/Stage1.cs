using System.Collections.Generic;
using UnityEngine;

public class Stage1 : Level
{
    DropLocationList dList;

    public Stage1(string name) : base(name)
    {
        List<DropLocation> dLocations = new List<DropLocation>();
        // Add locations

        dList = new DropLocationList(dLocations);
    }    

    public override void OnLevelStart()
    {
        Debug.Log("Activation on level start.");
    }

    public override void EnableTooltips()
    {
        Debug.Log("Tooltips to be enabled!");
    }

    public override void OnWin()
    {
        Debug.Log("Level" + GetName() + "complete");
    }

    public override bool CheckWinCondition()
    {
        return false;
    }
}
