using System;
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

    private void CreatePhase1Objects() {
        System.Random rand = new System.Random();
        List<DropLocation> dropLocations = new List<DropLocation>();
        int xPos = -375;
        // slots
        for (int i = 0; i < 4; i++) {
            SlotObject obj = new SlotObject(levelObj, i, new Vector2((i * 250) + xPos, 100), dropLocations);
        }
        // list
        DropLocationList dropLocationList = new DropLocationList(dropLocations);
        // draggables
        List<string> names = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        List<string> persistentNames = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        while (names.Count > 0) {
            int index = rand.Next(names.Count);
            string name = names[index];
            DraggableObject obj = new DraggableObject(levelObj, name, persistentNames.IndexOf(name), dropLocationList, new Vector2(xPos, -200));
            names.RemoveAt(index);
            xPos += 250;
        }
        // incorrect answers
        Text incorrectReasons = InterfaceTool.CreateHeader("", levelObj.transform, new Vector2(400, 800), new Vector2(515, -400), 20);
        incorrectReasons.alignment = TextAnchor.MiddleCenter;
        // valid check
        CreateCheckAnswerButton(() => {
            bool correct = true;
            incorrectReasons.text = "";
            foreach (DropLocation dropLocation in dropLocationList.dLocations) {
                if (!dropLocation.IsCorrectState()) {
                    correct = false;
                    if (dropLocation.state != -1) {
                        incorrectReasons.text += "-" + GetIncorrectReason(dropLocation.state) + "\n";
                    }
                }
            }
            return correct;
        }, () => {
            CreateWinScreen("To Phase 2", () => {
                ResetObjects();
                CreatePhase2Objects();
            });
        });
    }

    private void CreatePhase2Objects() {
        // diagram
        diagram = levelObj.AddComponent<Diagram>();
        diagram.obj.transform.SetParent(levelObj.transform, false);
        diagram.obj.transform.localPosition = new Vector3(0, 70, 0);
        diagram.slots[0] = new Slot(0);
        diagram.slots[1] = new Slot(2);
        diagram.slots[2] = new Slot(3);
        diagram.slots[3] = new Slot(4);
        // valid check
        CreateCheckAnswerButton(() => {
            foreach (Slot slot in diagram.slots) {
                if (!slot.CheckPosition()) {
                    return false;
                }
            }
            return true;
        }, () => {
            CreateWinScreen("Return to Title", () => {
                SysManager.SetLevel(null);
            });
        });
    }

    private String GetIncorrectReason(int index) {
        string reason = "";
        switch(index) {
            case 0:
                reason = "The IF/ID stage is where the instructions are fetched from memory. It needs to be the first stage because it determines which instruction is being executed, and the rest of the datapath relies on this information.";
                break;
            case 1:
                reason = "The ID/EX stage is responsible for decoding the instructions and preparing them for execution in the next stage.";
                break;
            case 2:
                reason = "The EX/MEM allows the execution stage to complete before the memory stage begins. It ensures the correct data is stored in the memory.";
                break;
            case 3:
                reason = "The MEM/WB is the result of memory operations are stored and being written back to the register file.";
                break;
            default:
                break;
        }
        return reason;
    }
}