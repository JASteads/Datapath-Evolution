using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickEvents : MonoBehaviour
{
    /*
    Canvas clickCanvas;
    Button nodeOut, nodeIn;
    Image dragWire;
    RectTransform targetLocation;

    Transform dragStartTF;
    const float WIRE_WIDTH = 20;
    /*
    void Start()
    {
        GameObject canvasObj = InterfaceTool.CanvasSetup(
            "Click Canvas", transform, out clickCanvas);
        Stage2Object stageObj = new Stage2Object("Stage Object");
        stageObj.GetTF().SetParent(canvasObj.transform, false);

        Stage2ObjectNode NodeOutObj = new Stage2ObjectNode(stageObj, "Out Node", true, NodeType.OUTPUT);
        Stage2ObjectNode NodeInObj = new Stage2ObjectNode(stageObj, "In Node", true, NodeType.INPUT);

        
        GameObject nodeOutObj = InterfaceTool.ButtonSetup(
            "Node Out", clickCanvas.transform, out Image nOutImg,
            out nodeOut, null, null);

        EventTrigger.Entry dragStart = new EventTrigger.Entry
        { eventID = EventTriggerType.BeginDrag },
            dragEvent = new EventTrigger.Entry
            { eventID = EventTriggerType.Drag },
            dragEnd = new EventTrigger.Entry
            { eventID = EventTriggerType.EndDrag };

        dragStart.callback.AddListener(data
            => StartWireDraw(data as PointerEventData));
        dragEvent.callback.AddListener(data
            => UpdateWireDraw(data as PointerEventData));
        dragEnd.callback.AddListener(data
            => FinishWireDraw(data as PointerEventData));

        EventTrigger eTrig = nodeOutObj.AddComponent<EventTrigger>();
        eTrig.triggers.Add(dragStart);
        eTrig.triggers.Add(dragEvent);
        eTrig.triggers.Add(dragEnd);

        InterfaceTool.FormatRect(nOutImg.rectTransform,
            new Vector2(50, 50), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(-200, 0));

        Text nodeOutText = InterfaceTool.CreateBody(
            "O", nOutImg.rectTransform, 32);

        GameObject nodeInObj = InterfaceTool.ButtonSetup(
            "Node In", clickCanvas.transform, out Image nInImg,
            out nodeIn, null, null);
        nodeInObj.tag = "InputNode";
        InterfaceTool.FormatRect(nInImg.rectTransform,
            new Vector2(50, 50), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(200, 0));
        
        InterfaceTool.ImgSetup(
            "Target Location", clickCanvas.transform,
            out Image targetImg, false);

        targetLocation = targetImg.rectTransform;

        InterfaceTool.FormatRectNPos(targetLocation,
            new Vector2(25, 25), Vector2.zero, Vector2.zero,
            new Vector2(0.5f, 0.5f));

        Text nodeInText = InterfaceTool.CreateBody(
            "I", nInImg.rectTransform, 32);

        GameObject lineObj = InterfaceTool.ImgSetup(
            "Drag Line", clickCanvas.transform, out dragWire, false);
        InterfaceTool.FormatRectNPos(dragWire.rectTransform,
            new Vector2(1, WIRE_WIDTH));
        dragWire.gameObject.SetActive(false);
        targetLocation.gameObject.SetActive(false);
        
    }
    
    void StartWireDraw(PointerEventData data)
    {
        Transform selectTF = data.selectedObject.transform;

        dragStartTF = selectTF;
        dragWire.transform.SetParent(selectTF, false);
        InterfaceTool.FormatRectNPos(dragWire.rectTransform,
            new Vector2(0, WIRE_WIDTH), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0, 0.5f));

        targetLocation.localPosition = new Vector3(data.position.x, data.position.y, 0);

        dragWire.gameObject.SetActive(true);
        targetLocation.gameObject.SetActive(true);
    }

    void UpdateWireDraw(PointerEventData data)
    {
        Vector2 screenRes = new Vector2(
            Screen.width, Screen.height) / 2;
        Vector2 startPos = (Vector2)dragStartTF.localPosition
            + screenRes;
        Vector2 diffVector = data.position - startPos;
        Quaternion newRotation = Quaternion.Euler(
            0, 0, 
            Mathf.Atan2(diffVector.y, diffVector.x) * Mathf.Rad2Deg);

        dragWire.rectTransform.sizeDelta = new Vector2(
            Vector2.Distance(startPos, data.position), WIRE_WIDTH);
        dragWire.rectTransform.rotation = newRotation;
        targetLocation.anchoredPosition = data.position;
    }

    void FinishWireDraw(PointerEventData data)
    {
        if (IsInInput(data))
            ConnectNodes(dragWire.rectTransform,
                dragStartTF, data.pointerEnter.transform);

        dragWire.gameObject.SetActive(false);
        targetLocation.gameObject.SetActive(false);
    }

    bool IsInInput(PointerEventData data)
    {
        return data.pointerEnter && data.pointerEnter.tag
            == "InputNode";
    }

    void ConnectNodes(RectTransform wireTF, Transform src,
        Transform dest)
    {
        ConnectWire connectObj = InterfaceTool.ButtonSetup(
            $"Connector Wire", src,
            out Image wireImg, out Button delButton, null,
            null).AddComponent<ConnectWire>();

        connectObj.InitConnectWire(dest, wireTF, wireImg, delButton);   
    }
    */
}