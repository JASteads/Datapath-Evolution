using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : Level
{
    private string name;
    private List<Stage2Object> objects = new List<Stage2Object>();
    private Dictionary<ControlSignal, int> requiredControlSignals = new Dictionary<ControlSignal, int>(), currentControlSignals = new Dictionary<ControlSignal, int>();
    private bool isLevelComplete = false;

    public Stage2(string name) {
        this.name = name;
    }

    public void AddLevelObject(Stage2Object levelObject) {
        objects.Add(levelObject);
        levelObject.GetImage().transform.SetParent(SysManager.canvas.transform, false);
    }

    public void AddPreset(List<Stage2Object> objects) {
        objects.ForEach(obj => this.objects.Add(obj));
    }

    public void SetRequiredControlSignals(int regDst, int regWrite, int pcSrc, int aluSrc, int memRead, int memWrite, int memToReg) {
        requiredControlSignals.Add(ControlSignal.REG_DST, regDst);
        requiredControlSignals.Add(ControlSignal.REG_WRITE, regWrite);
        requiredControlSignals.Add(ControlSignal.PC_SRC, pcSrc);
        requiredControlSignals.Add(ControlSignal.ALU_SRC, aluSrc);
        requiredControlSignals.Add(ControlSignal.MEM_READ, memRead);
        requiredControlSignals.Add(ControlSignal.MEM_WRITE, memWrite);
        requiredControlSignals.Add(ControlSignal.MEM_TO_REG, memToReg);
        //default all current to 0
        foreach (KeyValuePair<ControlSignal, int> signal in requiredControlSignals) {
            currentControlSignals.Add(signal.Key, 0);
        }
    }

    public void SetSignal(ControlSignal key, int value) {
        currentControlSignals.Add(key, value);
    }

    public void CheckState() {
        // never runs with no required signals
        foreach (KeyValuePair<ControlSignal, int> requiredSignal in requiredControlSignals) {
            foreach (KeyValuePair<ControlSignal, int> currentSignal in currentControlSignals) {
                if (requiredSignal.Key == currentSignal.Key && requiredSignal.Value != currentSignal.Value) {
                    return;
                }
            }
        }
        objects.ForEach(obj => {
            obj.GetComponents().ForEach(component => {
                if (component.GetCurrentState() != component.GetExpectedState()) {
                    return;
                }
            });
        });
        isLevelComplete = true;
        Debug.Log("Level " + name + " completed");
    }

    public string GetName() {
        return name;
    }

    public override bool CheckWinCon() {
        return isLevelComplete;
    }

    public Stage2Object GetStage2Object(RectTransform rectTransform) {
        Stage2Object found = null;
        objects.ForEach(obj => {
            if (obj.GetImage().rectTransform == rectTransform) {
                found = obj;
            }
        });
        return found;
    }

    public enum ControlSignal {
        REG_DST, REG_WRITE, PC_SRC, ALU_SRC, MEM_READ, MEM_WRITE, MEM_TO_REG
    }
}
