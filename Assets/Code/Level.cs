using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private string name;
    private List<LevelObject> objects = new List<LevelObject>();
    private Dictionary<string, int> requiredControlSignals = new Dictionary<string, int>(), currentControlSignals = new Dictionary<string, int>();
    private bool isLevelComplete = false;

    public Level(string name) {
        this.name = name;
    }

    public void AddLevelObject(LevelObject levelObject) {
        objects.Add(levelObject);
        levelObject.GetImage().transform.SetParent(SysManager.canvas.transform, false);
    }

    public void AddPreset(List<LevelObject> objects) {
        objects.ForEach(obj => this.objects.Add(obj));
    }

    public void setRequiredControlSignals(int regDst, int regWrite, int pcSrc, int aluSrc, int memRead, int memWrite, int memToReg) {
        requiredControlSignals.Add("RegDST", regDst);
        requiredControlSignals.Add("RegWrite", regWrite);
        requiredControlSignals.Add("PCSrc", pcSrc);
        requiredControlSignals.Add("ALUSrc", aluSrc);
        requiredControlSignals.Add("MemRead", memRead);
        requiredControlSignals.Add("MemWrite", memWrite);
        requiredControlSignals.Add("MemToReg", memToReg);
        //default all current to 0
        foreach (KeyValuePair<string, int> signal in requiredControlSignals) {
            currentControlSignals.Add(signal.Key, 0);
        }
    }

    public void CheckState() {
        // never runs with no required signals
        foreach (KeyValuePair<string, int> requiredSignal in requiredControlSignals) {
            foreach (KeyValuePair<string, int> currentSignal in currentControlSignals) {
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

    public bool IsLevelComplete() {
        return isLevelComplete;
    }

    public LevelObject GetLevelObject(RectTransform rectTransform) {
        LevelObject found = null;
        objects.ForEach(obj => {
            if (obj.GetImage().rectTransform == rectTransform) {
                found = obj;
            }
        });
        return found;
    }
}
