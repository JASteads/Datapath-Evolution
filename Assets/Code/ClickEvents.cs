using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickEvents : MonoBehaviour
{
    Canvas clickCanvas;
    Button nodeOut, nodeIn;
    Image dragWire;
    RectTransform targetLocation;

    Vector2 dragStartPos;
    const float WIRE_WIDTH = 20;
    const float CANVAS_SCALE = 0.009259259f;

    UnityEngine.Events.UnityAction startDrag;

    void Start()
    {
        GameObject canvasObj = InterfaceTool.CanvasSetup(
            "Click Canvas", transform, out clickCanvas);

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
        dragStartPos = data.position * CANVAS_SCALE;
        dragWire.transform.SetParent(
            data.selectedObject.transform, false);
        InterfaceTool.FormatRectNPos(dragWire.rectTransform,
            new Vector2(0, WIRE_WIDTH), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0, 0.5f));

        targetLocation.localPosition = new Vector3(data.position.x, data.position.y, 0);

        dragWire.gameObject.SetActive(true);
        targetLocation.gameObject.SetActive(true);
    }

    void UpdateWireDraw(PointerEventData data)
    {
        targetLocation.anchoredPosition = data.position;

        Vector2 diffVector = data.position - data.pressPosition;
        float wireLen = Mathf.Sqrt(
            (diffVector.x * diffVector.x) +
            (diffVector.y * diffVector.y));

        Vector2 normDiff = diffVector.normalized;

        Quaternion newRotation = new Quaternion(
            0, 0, Mathf.Tan(normDiff.y / normDiff.x), 1);

        dragWire.rectTransform.sizeDelta = new Vector2(
            wireLen, WIRE_WIDTH);
        dragWire.rectTransform.rotation = newRotation;
    }

    void FinishWireDraw(PointerEventData data)
    {
        Debug.Log($"End position : {data.position}");
        dragWire.gameObject.SetActive(false);
        targetLocation.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}