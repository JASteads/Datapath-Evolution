using UnityEngine;

public class DropLocation
{
    public static int UNSET = -1;

    readonly Transform tf;
    readonly int expectedState;
    public int state;

    public DropLocation(Transform _target, int _expectedState)
    {
        expectedState = _expectedState;
        tf = _target;
        state = UNSET;
    }

    public Transform GetTF()
    {
        return tf;
    }
    
    public bool IsCorrectState()
    {
        return state == expectedState;
    }
}