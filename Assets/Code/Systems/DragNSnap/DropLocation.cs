using UnityEngine;
using UnityEngine.UI;

public class DropLocation
{
    public static int UNSET = -1;
    readonly Color locationColor = new Color(0, 0, 0, 0.4f);
    readonly Transform tf;
    readonly int expectedState;

    int state;

    DropLocation(string name, RectTransform parent,
        int _expectedState, Vector2 newPos)
    {
        expectedState = _expectedState;
        tf = InterfaceTool.ImgSetup($"Drop Location {expectedState}",
            parent, out Image img, true).transform;
        InterfaceTool.FormatRect(img.rectTransform,
            new Vector2(200, 200), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            newPos);
        img.color = locationColor;

        state = UNSET;
    }

    public void SetState(int newState)
    {
        state = newState;
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