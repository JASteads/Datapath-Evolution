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

    public void CreateStage1Objects()
    {
        System.Random rand = new System.Random();
        List<DropLocation> dropLocations = new List<DropLocation>();
        int xPos = -500;
        // slots
        for (int i = 0; i < 5; i++) {
            SlotObject obj = new SlotObject(levelObj, i, new Vector2((i * 250) + xPos, 100), dropLocations);
        }
        // list
        DropLocationList dropLocationList = new DropLocationList(dropLocations);
        // draggables
        List<string> names = new List<string>{"PC", "Instruction\nMemory", "Register\nFile", "ALU", "Data\nMemory"};
        List<string> persistentNames = new List<string>{"PC", "Instruction\nMemory", "Register\nFile", "ALU", "Data\nMemory"};
        while (names.Count > 0) {
            int index = rand.Next(names.Count);
            string name = names[index];
            DraggableObject obj = new DraggableObject(levelObj, name, persistentNames.IndexOf(name), dropLocationList, new Vector2(xPos, -200));
            names.RemoveAt(index);
            xPos += 250;
        }
        // incorrect answers
        Text incorrectReasons = InterfaceTool.CreateHeader("", levelObj.transform, new Vector2(300, 800), new Vector2(625, -400), 20);
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
            CreateWinScreen("To Stage 2", () => {
                SysManager.SetLevel(SysManager.GetStage2());
            });
        });
    }

    private String GetIncorrectReason(int index) {
        string reason = "";
        switch(index) {
            case 0:
                reason = "The PC holds the memory address of the next instruction to be executed. It ensures the CPU knows what is the next instruction to execute first and continues executing instructions in the correct order.";
                break;
            case 1:
                reason = "The processor needs to fetch instructions from memory before it can execute them. If the instruction memory is not placed second, the processor will not be able to fetch instructions correctly.";
                break;
            case 2:
                reason = "The register file holds the data and needs to provide instructions to the processor before any data is accessed or processed.";
                break;
            case 3:
                reason = "The ALU performs arithmetic and logical operations on data. ALU requires the operands from the previous components in the path to perform ALU.";
                break;
            case 4:
                reason = "The data memory should be accessed after the arithmetic and logic operations have been performed. This is because the results of those operations need to be stored or retrieved from the data memory.";
                break;
            default:
                break;
        }
        return reason;
    }
}

