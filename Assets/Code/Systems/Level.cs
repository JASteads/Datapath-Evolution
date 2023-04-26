using UnityEngine;

public abstract class Level
{
    readonly string name;
    protected GameObject levelObj;

    public Level(string name) {
        this.name = name;
        levelObj = new GameObject("Stage");
        levelObj.transform.SetParent(
            SysManager.canvas.transform, false);
    }

    public string GetName() {
        return name;
    }

    public virtual void OnLevelStart() {
        Debug.Log("Activation on level start.");
    }

    public virtual void EnableTooltips() {
        Debug.Log("Tooltips to be enabled!");
    }
    
    public virtual void OnWin() {
        Debug.Log("Level" + GetName() + "complete");
    }

    public abstract bool CheckWinCondition();

    protected void Destroy() {
        GameObject.Destroy(levelObj);
    }

    protected void ResetObjects() {
        Destroy();
        levelObj = new GameObject("Stage");
        levelObj.transform.SetParent(
            SysManager.canvas.transform, false);
    }
}