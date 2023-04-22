using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private string name;
    private List<LevelObject> objects = new List<LevelObject>();
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

    public void CheckState() {
        objects.ForEach(obj => {
            obj.GetComponents().ForEach(component => {
                if (component.GetCurrentState() != component.GetExpectedState()) {
                    return;
                }
            });
        });
        isLevelComplete = true;
        Debug.Log("level completed");
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
