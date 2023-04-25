using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndSnapEvent
{
    readonly RectTransform target;
    readonly DropLocationList dList;

    public DragAndSnapEvent(RectTransform _target,
        DropLocationList _dList)
    {
        target = _target;
        dList = _dList;

        EventTrigger.Entry dragStart = new EventTrigger.Entry
        { eventID = EventTriggerType.BeginDrag },
            dragEvent = new EventTrigger.Entry
            { eventID = EventTriggerType.Drag },
            dragEnd = new EventTrigger.Entry
            { eventID = EventTriggerType.EndDrag };

        dragStart.callback.AddListener(data
           => StartDrag(data as PointerEventData));
        dragEvent.callback.AddListener(data
            => UpdateDrag(data as PointerEventData));
        dragEnd.callback.AddListener(data
            => EndDrag(data as PointerEventData));

        EventTrigger eTrig = target.gameObject
            .AddComponent<EventTrigger>();
        eTrig.triggers.Add(dragStart);
        eTrig.triggers.Add(dragEvent);
        eTrig.triggers.Add(dragEnd);
    }

    void StartDrag(PointerEventData data)
    {

    }

    void UpdateDrag(PointerEventData data)
    {
        target.position = data.position;
    }

    void EndDrag(PointerEventData data)
    {
        DropLocation dropLocation =
            dList.SearchLocations(data.pointerEnter.transform);

        if (dropLocation.GetTF().tag != "Drag Object")
        {
            Debug.Log("Snapping");
            target.SetParent(dropLocation.GetTF(), false);
        }
    }
}