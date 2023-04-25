using UnityEngine;

public abstract class Level
{
    private string name;

    public Level(string name) {
        this.name = name;
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
}