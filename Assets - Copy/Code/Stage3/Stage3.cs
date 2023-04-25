using UnityEngine;

public class Stage3 : Level
{
    public Stage3(string name) : base(name)
    {

    }

    public override void OnLevelStart()
    {
        Debug.Log("Activation on level start.");
    }

    public override void EnableTooltips()
    {
        Debug.Log("Tooltips to be enabled!");
    }

    public override void OnWin()
    {
        Debug.Log("Level" + GetName() + "complete");
    }

    public override bool CheckWinCondition()
    {
        return false;
    }
}