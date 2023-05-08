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
                        incorrectReasons.text += "-" + GetIncorrectReasonP1(dropLocation.state) + "\n";
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
        diagram.obj.transform.localPosition = new Vector3(-50, 15, 0);
        diagram.slots[0] = new Slot(0);
        diagram.slots[1] = new Slot(2);
        diagram.slots[2] = new Slot(3);
        diagram.slots[3] = new Slot(4);
        // incorrect answers
        Text incorrectReasons = InterfaceTool.CreateHeader("", levelObj.transform, new Vector2(300, 900), new Vector2(625, -445), 20);
        incorrectReasons.alignment = TextAnchor.MiddleCenter;
        // valid check
        CreateCheckAnswerButton(() => {
            bool correct = true;
            incorrectReasons.text = "";
            foreach (Slot slot in diagram.slots) {
                if (!slot.CheckPosition()) {
                    correct = false;
                    incorrectReasons.text += "-" + GetIncorrectReasonP2(slot.expectedPos) + "\n";
                }
            }
            return correct;
        }, () => {
            CreateWinScreen("Return to Title", () => {
                SysManager.SetLevel(null);
            });
        }, -450);
    }

    private String GetIncorrectReasonP1(int index) {
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

    private String GetIncorrectReasonP2(int index) {
        string reason = "";
        switch(index) {
            case 0:
                reason = "LW instruction is not placed in the first clock cycle(cc0) because it takes more than 1 clock cycle to complete. LW instruction uses base + offset to calculate the memory address which takes one clock cycle, loading memory is 2 cycles.";
                break;
            case 2:
                reason = "SW instruction is not placed in the clock cycle 2 is because LW instruction is using the clock cycle 1 and 2. Placing the SW instruction in the CC2 will cause a structural hazard which means the datapath can't perform two operations simultaneously in the same cycle. Therefore, the second instruction has to wait until the cc1 and cc2 are available before it can be executed.";
                break;
            case 3:
            case 4:
                reason = "MIPS pipeline stages need to wait one clock cycle to do the next instruction because each stage must complete its work before the next stage can use the results. This ensures that the correct information is passed between the stages and that the instruction is executed correctly.";
                break;
            default:
                break;
        }
        return reason;
    }
}