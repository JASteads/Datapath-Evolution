using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1 : Level
{
    DropLocationList dList;

    public Stage1() : base("Stage 1")
    {
        List<DropLocation> dLocations = new List<DropLocation>();
        // Add locations

        dList = new DropLocationList(dLocations);
        CreateIntroductionBox("In this stage, the player will need to assemble a single datapath by dragging different components into empty fields. The goal is to correctly assemble the datapath that will allow the user to understand the execution of datapath instructions.",
            CreateStage1Objects);
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

    public void CreateStage1Objects()
    {

    }
}

