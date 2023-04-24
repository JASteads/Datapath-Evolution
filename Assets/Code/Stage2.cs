using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : Level
{
    private List<Stage2Object> objects = new List<Stage2Object>();
    private Dictionary<ControlSignal, bool> expectedControlSignals = new Dictionary<ControlSignal, bool>(), currentControlSignals = new Dictionary<ControlSignal, bool>();
    private bool validControlSignals = false;

    public Stage2(string name, bool regDst, bool regWrite, bool pcSrc, bool aluSrc, bool memRead, bool memWrite, bool memToReg) : base(name) {
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
    }

    public override bool CheckWinCondition() {
        if (!validControlSignals) {
            return false;
        }
        foreach (Stage2Object obj in objects) {
            foreach (Stage2ObjectComponent component in obj.GetComponents()) {
                if (component.GetCurrentState() != component.GetExpectedState()) {
                    return false;
                }
            }
        }
        return true;
    }

    public void CheckControlSignals() {
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            if (currentControlSignals[signal] != expectedControlSignals[signal]) {
                return;
            }
        }
        validControlSignals = true;
    }

    public void AddLevelObject(Stage2Object levelObject) {
        objects.Add(levelObject);
        levelObject.GetImage().transform.SetParent(SysManager.canvas.transform, false);
    }

    public void AddPreset(List<Stage2Object> objects) {
        objects.ForEach(obj => this.objects.Add(obj));
    }

    public void SetSignal(ControlSignal key, bool value) {
        currentControlSignals.Add(key, value);
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
