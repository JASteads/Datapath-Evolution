using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : Level
{
    private List<Stage2Object> objects = new List<Stage2Object>();
    private Dictionary<ControlSignal, bool> expectedControlSignals = new Dictionary<ControlSignal, bool>(), currentControlSignals = new Dictionary<ControlSignal, bool>();
    private bool validControlSignals = false;

    public Stage2(bool regDst, bool regWrite, bool pcSrc, bool aluSrc, bool memRead, bool memWrite, bool memToReg) : base("Stage 2") {
        expectedControlSignals.Add(ControlSignal.REG_DST, regDst);
        expectedControlSignals.Add(ControlSignal.REG_WRITE, regWrite);
        expectedControlSignals.Add(ControlSignal.PC_SRC, pcSrc);
        expectedControlSignals.Add(ControlSignal.ALU_SRC, aluSrc);
        expectedControlSignals.Add(ControlSignal.MEM_READ, memRead);
        expectedControlSignals.Add(ControlSignal.MEM_WRITE, memWrite);
        expectedControlSignals.Add(ControlSignal.MEM_TO_REG, memToReg);
        //default all current to 0
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            currentControlSignals.Add(signal, false);
        }
        //introduction
        CreateIntroductionBox("This level will ask you to choose valid control signals for a STORE operation. Upon chosing the correct signals, you will then be asked to complete the datapath for the operation.",
            CreateControlObjects);
    }

    public override bool CheckWinCondition() {
        return false;
    }

    public void CheckControlSignals() {
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            if (currentControlSignals[signal] != expectedControlSignals[signal]) {
                validControlSignals = false;
                return;
            }
        }
        validControlSignals = true;
    }

    public void AddLevelObject(Stage2Object levelObject) {
        objects.Add(levelObject);
        levelObject.GetTF().SetParent(levelObj.transform, false);
    }

    public void AddPreset(List<Stage2Object> objects) {
        objects.ForEach(obj => this.objects.Add(obj));
    }

    public Stage2Object GetStage2Object(Transform target) {
        Stage2Object found = null;
        objects.ForEach(obj => {
            if (obj.GetTF() == target) {
                found = obj;
            }
        });
        return found;
    }

    private void CreateControlObjects() {
        //control
        GameObject controlObj = InterfaceTool.ImgSetup("Control Unit", levelObj.transform, out Image controlImg, SysManager.sprites[11], true);
        InterfaceTool.FormatRect(controlImg.rectTransform, new Vector2(300, 600), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        SysManager.tooltip.AssignTooltip(controlObj.transform);
        //signal toggles
        int yOffset = 240;
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            CreateControlToggle(signal, controlImg, yOffset);
            yOffset -= 80;
        }
        //incorrect answers
        Text descriptions = InterfaceTool.CreateHeader("", controlObj.transform, new Vector2(300, 800), new Vector2(400, -700), 20);
        descriptions.alignment = TextAnchor.MiddleCenter;
        //control signal check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Answer", controlImg.transform, out Image winCheckImg, out Button button, SysManager.sprites[1], () => {
            CheckControlSignals();
            if (validControlSignals) {
                ResetObjects();
                CreateDatapathObjects();
            }
            else {
                descriptions.text = "";
                foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
                    if (currentControlSignals[signal] != expectedControlSignals[signal]) {
                        descriptions.text += "-" + GetIncorrectDescriptionMessage(signal) + "\n";
                    }
                }
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        Text text = InterfaceTool.CreateHeader("Check Answer", winCheckImg.transform, new Vector2(0, 20), new Vector2(0, -40), 16);
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }

    private GameObject CreateControlToggle(ControlSignal signal, Image controlImg, int yOffset) {
        String name = signal.ToString();
        GameObject obj = InterfaceTool.ButtonSetup(name, controlImg.transform, out Image objImg, out Button button, SysManager.sprites[12], null);
        InterfaceTool.FormatRect(objImg.rectTransform, new Vector2(60, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(40, yOffset));
        SysManager.tooltip.AssignTooltip(obj.transform);
        button.onClick.AddListener(() => {
            bool on = currentControlSignals[signal];
            if (on) {
                objImg.sprite = SysManager.sprites[12];
            }
            else {
                objImg.sprite = SysManager.sprites[13];
            }
            currentControlSignals[signal] = !on;
        });
        Text text = InterfaceTool.CreateHeader(name, objImg.transform, new Vector2(60, 20), new Vector2(-110, -40), 16);
        text.color = Color.black;
        return obj;
    }

    private void CreateDatapathObjects() {
        // presets
        AddLevelObject(Stage2ObjectPresests.CreatePC(-850, 100, true));
        AddLevelObject(Stage2ObjectPresests.CreateInstructionMemory(-550, 100, true, true, true, false, true));
        AddLevelObject(Stage2ObjectPresests.CreateSignExtend(-50, -170, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateRegisterFile(-50, 100, true, true, false, false, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateALU(300, 100, true, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateDataMemory(650, 100, true, true, false));

        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Answer", levelObj.transform, out Image winCheckImg, out Button button, SysManager.sprites[1], () => {
            bool valid = true;
            foreach (Stage2Object obj in objects) {
                foreach (Stage2ObjectNode node in obj.GetNodes()) {
                    if (node.GetCurrentState() != node.GetExpectedState()) {
                        valid = false;
                    }
                }
            }
            if (valid) {
                Destroy();
                SysManager.SetLevel(SysManager.GetStage3());
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        Text text = InterfaceTool.CreateHeader("Check Answer", winCheckImg.transform, new Vector2(0, 20), new Vector2(0, -40), 16);
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
    }

    private string GetIncorrectDescriptionMessage(ControlSignal signal) {
        string message = ""; 
        switch (signal) {
            case ControlSignal.REG_DST:
                message = "The REG_DST signal selects the destination register for the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct register.";
                break;
            case ControlSignal.REG_WRITE:
                message = "The REG_WRITE signal enables the write operation to a register. It should not be turned on because the data is being written to memory and not to a register.";
                break;
            case ControlSignal.PC_SRC:
                message = "The PC_SRC signal selects the source of the program counter value. It should not be turned on because the program counter value is not being used in this datapath.";
                break;
            case ControlSignal.ALU_SRC:
                message = "The ALU_SRC signal selects the source of the data that is to be written to memory. It should not be turned off because if it is turned off, the data will not be written to the correct memory location.";
                break;
            case ControlSignal.MEM_READ:
                message = "The MEM_READ signal enables the memory read operation. It should not be turned on because the data is being written to memory and not being read from memory.";
                break;
            case ControlSignal.MEM_WRITE:
                message = "The MEM_WRITE signal enables the memory write operation. It should not be turned off because if it is turned off, the data will not be written to memory.";
                break;
            case ControlSignal.MEM_TO_REG:
                message = "The MEM_TO_REG signal selects the source of data to be written to a register. It should not be turned on because the data is being written to memory and not being selected data to send to the register file to write.";
                break;
            default:
                break;
        };
        return message;
    }

    public enum ControlSignal {
        REG_DST, REG_WRITE, PC_SRC, ALU_SRC, MEM_READ, MEM_WRITE, MEM_TO_REG
    }
}
