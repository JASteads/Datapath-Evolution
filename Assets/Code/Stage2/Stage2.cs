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
        GameObject controlObj = InterfaceTool.ImgSetup("Control", levelObj.transform, out Image controlImg, false);
        InterfaceTool.FormatRect(controlImg.rectTransform, new Vector2(300, 600), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        controlImg.color = Color.gray;
        //signal toggles
        int yOffset = 240;
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            CreateControlToggle(signal, controlImg, yOffset);
            yOffset -= 80;
        }
        //control signal check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Signals", controlImg.transform, out Image winCheckImg, out Button button, null, () => {
            CheckControlSignals();
            if (validControlSignals) {
                ResetObjects();
                CreateDatapathObjects();
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        winCheckImg.color = Color.gray;
        Text txt = InterfaceTool.CreateHeader("Check Signals", winCheckImg.transform, new Vector2(60, 20), new Vector2(35, -40), 16);
        txt.color = Color.black;
    }

    private GameObject CreateControlToggle(ControlSignal signal, Image controlImg, int yOffset) {
        String name = signal.ToString();
        GameObject obj = InterfaceTool.ButtonSetup(name, controlImg.transform, out Image objImg, out Button button, null, null);
        InterfaceTool.FormatRect(objImg.rectTransform, new Vector2(60, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(40, yOffset));
        button.onClick.AddListener(() => {
            if (objImg.color == Color.red) {
                objImg.color = Color.blue;
            }
            else {
                objImg.color = Color.red;
            }
            currentControlSignals[signal] = !currentControlSignals[signal];
        });
        objImg.color = Color.red;
        Text txt = InterfaceTool.CreateHeader(name, objImg.transform, new Vector2(60, 20), new Vector2(-110, -40), 16);
        txt.color = Color.black;
        return obj;
    }

    private void CreateDatapathObjects() {
        // presets
        AddLevelObject(Stage2ObjectPresests.CreatePC(-850, -150, true));
        AddLevelObject(Stage2ObjectPresests.CreateInstructionMemory(-550, -150, true, true, true, false, true));
        AddLevelObject(Stage2ObjectPresests.CreateSignExtend(-50, -420, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateRegisterFile(-50, -150, true, true, false, false, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateALU(300, -150, true, true, true));
        AddLevelObject(Stage2ObjectPresests.CreateDataMemory(650, -150, true, true, false));

        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Datapath", levelObj.transform, out Image winCheckImg, out Button button, null, () => {
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
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(800, 450));
        winCheckImg.color = Color.gray;
        Text txt = InterfaceTool.CreateHeader("Check Datapath", winCheckImg.transform, new Vector2(0, 20), new Vector2(0, -40), 16);
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = Color.black;
    }

    public enum ControlSignal {
        REG_DST, REG_WRITE, PC_SRC, ALU_SRC, MEM_READ, MEM_WRITE, MEM_TO_REG
    }
}
