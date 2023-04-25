using UnityEngine;
using UnityEngine.UI;

public class Stage2ObjectNode
{
    bool currentState = false;
    Button button;

    readonly bool expectedState;
    readonly ConnectWire link;
    readonly NodeType type;

    public Stage2ObjectNode(Stage2Object obj, string name,
        bool expectedState, NodeType type)
    {
        float nodePos;
        this.type = type;
        this.expectedState = expectedState;
        GameObject nodeObj = InterfaceTool.ButtonSetup(name,
            obj.GetTF(), out Image image, out button, null, null);

        if (type == NodeType.OUTPUT)
        {
            nodePos = 1;
            link = new ConnectWire(this);
        }
        else nodePos = 0;

        InterfaceTool.FormatRectNPos(image.rectTransform,
            new Vector2(50, 50), new Vector2(nodePos, 0.5f),
            new Vector2(nodePos, 0.5f), new Vector2(nodePos, 0.5f));
    }

    public Stage2ObjectNode(Stage2Object obj, string name,
        bool expectedState, NodeType type, float yOffset)
    {
        float nodePos;
        this.type = type;
        this.expectedState = expectedState;
        InterfaceTool.ButtonSetup(name, obj.GetTF(),
            out Image image, out button, null, null);

        if (type == NodeType.OUTPUT)
        {
            nodePos = 1;
            link = new ConnectWire(this);
        }
        else nodePos = 0;

        InterfaceTool.FormatRect(image.rectTransform,
            new Vector2(50, 50), new Vector2(nodePos, 0.5f),
            new Vector2(nodePos, 0.5f), new Vector2(nodePos, 0.5f),
            new Vector2(0, yOffset));
    }

    public RectTransform GetTF()
    {
        return button.image.rectTransform;
    }

    public bool GetCurrentState()
    {
        return currentState;
    }

    public void SetCurrentState(bool state)
    {
        currentState = state;
    }

    public bool GetExpectedState()
    {
        return expectedState;
    }
}

public enum NodeType
{
    INPUT,
    OUTPUT
};