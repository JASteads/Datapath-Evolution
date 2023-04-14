using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private List<LevelObject> objects = new List<LevelObject>();
    private bool isLevelComplete = false;

    public Level(List<LevelObject> objects) {
        this.objects = objects;
        this.objects.ForEach(obj => {
            obj.GetImage().transform.SetParent(SysManager.canvas.transform, false);
        });
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

    public bool IsLevelComplete() {
        return isLevelComplete;
    }
}
