﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Stage3 : Level
{
    private Diagram diagram;

    public Stage3() : base("Stage 3")
    {
        CreateIntroductionBox("In this stage, you will need to set the pipeline states in the correct positions, and optimize them to improve the performance.",
            CreatePhase1Objects);
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

    private void CreatePhase1Objects() {
        System.Random rand = new System.Random();
        List<DropLocation> dropLocations = new List<DropLocation>();
        int xPos = -375;
        //slots
        for (int i = 0; i < 4; i++) {
            SlotObject obj = new SlotObject(levelObj, i, new Vector2((i * 250) + xPos, 100), dropLocations);
        }
        //list
        DropLocationList dropLocationList = new DropLocationList(dropLocations);
        //draggables
        List<string> names = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        List<string> persistentNames = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        while (names.Count > 0) {
            int index = rand.Next(names.Count);
            string name = names[index];
            DraggableObject obj = new DraggableObject(levelObj, name, persistentNames.IndexOf(name), dropLocationList, new Vector2(xPos, -200));
            names.RemoveAt(index);
            xPos += 250;
        }
        //valid check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Answer", levelObj.transform, out Image winCheckImg, out Button button, SysManager.sprites[1], () => {
            bool valid = true;
            foreach (DropLocation dropLocation in dropLocationList.dLocations) {
                if (!dropLocation.IsCorrectState()) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                CreateWinScreen("To Phase 2", () => {
                    ResetObjects();
                    CreatePhase2Objects();
                });
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        Text text = InterfaceTool.CreateHeader("Check Answer", winCheckImg.transform, new Vector2(0, 20), new Vector2(0, -40), 16);
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }

    private void CreatePhase2Objects() {
        //diagram
        diagram = levelObj.AddComponent<Diagram>();
        diagram.obj.transform.SetParent(levelObj.transform, false);
        diagram.obj.transform.localPosition = new Vector3(0, 70, 0);
        diagram.slots[0] = new Slot(0);
        diagram.slots[1] = new Slot(2);
        diagram.slots[2] = new Slot(3);
        diagram.slots[3] = new Slot(4);
        //valid check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Answer", levelObj.transform, out Image winCheckImg, out Button button, SysManager.sprites[1], () => {
            bool valid = true;
            foreach (Slot slot in diagram.slots) {
                if (!slot.CheckPosition()) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                CreateWinScreen("Return to Title", () => {
                    SysManager.SetLevel(null);
                });
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        Text text = InterfaceTool.CreateHeader("Check Answer", winCheckImg.transform, new Vector2(0, 20), new Vector2(0, -40), 16);
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }
}