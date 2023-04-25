using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : Level
{
    private static Vector2 DEF_VEC = new Vector2(0.5F, 0.5F);

    private List<Stage2Object> objects = new List<Stage2Object>();
    private Dictionary<ControlSignal, bool> expectedControlSignals = new Dictionary<ControlSignal, bool>(), currentControlSignals = new Dictionary<ControlSignal, bool>();
    private bool validControlSignals = false;
    Transform parent;

    public Stage2(string name, Transform parent, bool regDst, bool regWrite, bool pcSrc, bool aluSrc, bool memRead, bool memWrite, bool memToReg) : base(name) {
        this.parent = parent;
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
        //create objects
        CreateObjects();
    }

    public override bool CheckWinCondition() {
        if (!validControlSignals) {
            return false;
        }
        foreach (Stage2Object obj in objects) {
            foreach (Stage2ObjectNode node in obj.GetNodes()) {
                if (node.GetCurrentState() != node.GetExpectedState()) {
                    return false;
                }
            }
        }
        return true;
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
        levelObject.GetTF().SetParent(parent, false);
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

    private void CreateObjects() {
        CreateControlObjects();
    }

    private void CreateControlObjects() {
        //control
        GameObject control = InterfaceTool.ImgSetup("Control", SysManager.canvas.transform, out Image controlImg, false);
        InterfaceTool.FormatRect(controlImg.rectTransform, new Vector2(300, 600), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        //signal toggles
        int yOffset = 240;
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            CreateControlToggle(signal, controlImg, yOffset);
            yOffset -= 80;
        }
        //control signal check
        GameObject winCheck = InterfaceTool.ButtonSetup("Check Signals", controlImg.transform, out Image winCheckImg, out Button button, null, () => {
            CheckControlSignals();
            if (validControlSignals) {
                GameObject.Destroy(control);
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
        AddLevelObject(LevelObjectPresets.createRegisterFile(-200, 0, false, false, false, false, false, false));
        AddLevelObject(LevelObjectPresets.createALU(200, 0, true, true, false));
        AddLevelObject(LevelObjectPresets.createDataMemory(600, 0, true, true, false));
    }

    public enum ControlSignal {
        REG_DST, REG_WRITE, PC_SRC, ALU_SRC, MEM_READ, MEM_WRITE, MEM_TO_REG
    }
}
