using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    public virtual void OnLevelStart() {
        Debug.Log("Activation on level start.");
    }

    public virtual bool CheckWinCon() {
        return false;
    }

    public virtual void EnableTooltips() {
        Debug.Log("Tooltips to be enabled!");
    }
    public virtual void OnWin() {
        Debug.Log("The player wins.");
    }

}