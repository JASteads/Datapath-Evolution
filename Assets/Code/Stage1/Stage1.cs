using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1 : Level
{
    public Stage1() : base("Stage 1")
    {   
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
        System.Random rand = new System.Random();
        List<DropLocation> dropLocations = new List<DropLocation>();
        int xPos = -500;
        //slots
        for (int i = 0; i < 5; i++) {
            SlotObject obj = new SlotObject(levelObj, i, new Vector2((i * 250) + xPos, 100), dropLocations);
        }
        //list
        DropLocationList dropLocationList = new DropLocationList(dropLocations);
        //draggables
        List<string> names = new List<string>{"PC", "Instruction Memory", "Register File", "ALU", "Data Memory"};
        List<string> persistentNames = new List<string>{"PC", "Instruction Memory", "Register File", "ALU", "Data Memory"};
        while (names.Count > 0) {
            int index = rand.Next(names.Count);
            string name = names[index];
            DraggableObject obj = new DraggableObject(levelObj, name, persistentNames.IndexOf(name), dropLocationList, new Vector2(xPos, -200));
            names.RemoveAt(index);
            xPos += 250;
        }
        //valid check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Indexes", levelObj.transform, out Image winCheckImg, out Button button, null, () => {
            bool valid = true;
            dropLocationList.dLocations.ForEach(dropLocation => {
                if (!dropLocation.IsCorrectState()) {
                    valid = false;
                }
            });
            if (valid) {
                ResetObjects();
                SysManager.SetLevel(SysManager.GetStage2());
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        winCheckImg.color = Color.gray;
        Text txt = InterfaceTool.CreateHeader("Check Indexes", winCheckImg.transform, new Vector2(60, 20), new Vector2(35, -40), 16);
        txt.color = Color.black;
    }
}

