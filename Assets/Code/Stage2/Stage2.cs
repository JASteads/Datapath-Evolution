using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : Level
{
    private List<Stage2Object> objects = new List<Stage2Object>();
    private Dictionary<ControlSignal, int> expectedControlSignals = new Dictionary<ControlSignal, int>(), currentControlSignals = new Dictionary<ControlSignal, int>();
    Transform parent;

    public Stage2(string name, Transform parent) : base(name)
    {
        this.parent = parent;
    }

    public Stage2(string name, int regDst, int regWrite, int pcSrc, int aluSrc, int memRead, int memWrite, int memToReg) : base(name) {
        expectedControlSignals.Add(ControlSignal.REG_DST, regDst);
        expectedControlSignals.Add(ControlSignal.REG_WRITE, regWrite);
        expectedControlSignals.Add(ControlSignal.PC_SRC, pcSrc);
        expectedControlSignals.Add(ControlSignal.ALU_SRC, aluSrc);
        expectedControlSignals.Add(ControlSignal.MEM_READ, memRead);
        expectedControlSignals.Add(ControlSignal.MEM_WRITE, memWrite);
        expectedControlSignals.Add(ControlSignal.MEM_TO_REG, memToReg);
        //default all current to 0
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            currentControlSignals.Add(signal, 0);
        }
    }

    public override bool CheckWinCondition() {
        foreach (ControlSignal signal in Enum.GetValues(typeof(ControlSignal))) {
            if (currentControlSignals[signal] != expectedControlSignals[signal]) {
                return false;
            }
        }
        foreach (Stage2Object obj in objects) {
            foreach (Stage2ObjectNode component in obj.GetNodes()) {
                if (component.GetCurrentState() != component.GetExpectedState()) {
                    return false;
                }
            }
        }
        return true;
    }

    public void AddLevelObject(Stage2Object levelObject) {
        objects.Add(levelObject);
        levelObject.GetTF().SetParent(parent, false);
    }

    public void AddPreset(List<Stage2Object> objects) {
        objects.ForEach(obj => this.objects.Add(obj));
    }

    public void SetSignal(ControlSignal key, int value) {
        currentControlSignals.Add(key, value);
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

    public enum ControlSignal {
        REG_DST, REG_WRITE, PC_SRC, ALU_SRC, MEM_READ, MEM_WRITE, MEM_TO_REG
    }
}
