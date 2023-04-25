using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConnectWire
{
    const float WIRE_WIDTH = 20, CONNECT_WIDTH = 10;
    readonly Vector2 canvasRes = new Vector2(1920, 1080);
    
    Stage2ObjectNode src, dest;
    Button delButton;
    Image wireImg;

    public ConnectWire(Stage2ObjectNode _src)
    {
        src = _src;
        GameObject connectObj = InterfaceTool.ButtonSetup(
            $"Connector Wire", src.GetTF(),
            out wireImg, out delButton, null,
            DeleteWire);

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

        EventTrigger eTrig = src.GetTF().gameObject
            .AddComponent<EventTrigger>();
        eTrig.triggers.Add(dragStart);
        eTrig.triggers.Add(dragEvent);
        eTrig.triggers.Add(dragEnd);

        wireImg.gameObject.SetActive(false);
    }

    public RectTransform GetTF()
    {
        return wireImg.rectTransform;
    }

    void StartWireDraw(PointerEventData data)
    {
        if (dest != null) return;

        Vector2 screenRes = new Vector2(
            Screen.width, Screen.height) / 2;

        GetTF().SetParent(src.GetTF(), false);
        InterfaceTool.FormatRectNPos(wireImg.rectTransform,
            new Vector2(0, WIRE_WIDTH), new Vector2(1, 0.5f),
            new Vector2(1, 0.5f), new Vector2(0, 0.5f));

        GetTF().anchoredPosition = Vector2.zero;

        wireImg.gameObject.SetActive(true);
        GetTF().gameObject.SetActive(true);
    }

    void UpdateWireDraw(PointerEventData data)
    {
        Vector2 scaleRatio = canvasRes / new Vector2(
            Screen.width, Screen.height);
        if (dest != null) return;

        Vector2 screenRes = new Vector2(
            Screen.width, Screen.height) / 2;
        Vector2 mousePos = (data.position - screenRes) * scaleRatio;
        
        Vector2 startPos = src.GetTF().anchoredPosition;
        Vector2 diffVector = mousePos - startPos;
        Quaternion newRotation = Quaternion.Euler(
            0, 0,
            Mathf.Atan2(diffVector.y, diffVector.x) * Mathf.Rad2Deg);

        GetTF().sizeDelta = new Vector2(
            Vector2.Distance(startPos, mousePos), WIRE_WIDTH);
        GetTF().rotation = newRotation;
    }

    void FinishWireDraw(PointerEventData data)
    {
        if (dest != null) return;

        if (IsInInput(data))
            CompleteConnect(data.pointerEnter.transform);
        else
            wireImg.gameObject.SetActive(false);
    }

    public void CompleteConnect(Transform target)
    {
        InterfaceTool.FormatRectNPos(GetTF(),
            new Vector2(GetTF().sizeDelta.x, CONNECT_WIDTH),
            new Vector2(1, 0.5f), new Vector2(1, 0.5f),
            new Vector2(0, 0.5f));

        dest = (SysManager.currentLevel as Stage2)
            .GetStage2Object(target.parent)?
            .GetStage2ObjectNode(target);

        if (dest == null)
        {
            Debug.Log("No level object component found");
            wireImg.gameObject.SetActive(false);
        }   
        else
        {
            Debug.Log("Connection made");
            src.SetCurrentState(true);
            dest.SetCurrentState(true);
        }
    }

    bool IsInInput(PointerEventData data)
    {
        return data.pointerEnter && data.pointerEnter.tag
            == "Input Node";
    }

    void DeleteWire()
    {
        delButton.gameObject.SetActive(false);
        dest.SetCurrentState(false);
        src.SetCurrentState(false);

        dest = null;
    }
}