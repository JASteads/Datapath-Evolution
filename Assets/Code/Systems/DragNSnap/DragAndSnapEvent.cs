using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndSnapEvent
{
    readonly Transform target, parent;
    readonly DropLocationList dList;
    readonly int state;

    Graphic rayTarget;
    Vector2 screenOffset, startPos;
    DropLocation dropLocation;

    public DragAndSnapEvent(Graphic _target,
        DropLocationList _dList, int _state)
    {
        dList = _dList;
        rayTarget = _target;
        target = _target.transform;
        state = _state;

        parent = target.parent;

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
        if (dropLocation != null)
        {
            dropLocation = null;
            target.SetParent(parent, false);
        }   

        rayTarget.raycastTarget = false;
        screenOffset = new Vector2(Screen.width, Screen.height) / 2;
        startPos = target.localPosition;
    }

    void UpdateDrag(PointerEventData data)
    {
        target.localPosition = data.position - screenOffset;
    }

    void EndDrag(PointerEventData data)
    {
        rayTarget.raycastTarget = true;

        if (dList == null)
        {
            target.localPosition = startPos;
            return;
        }

        dropLocation = dList.SearchLocations
            (data.pointerEnter.transform);

        if (dropLocation.GetTF().tag != "Drag Object")
        {
            target.SetParent(dropLocation.GetTF(), false);
            target.localPosition = Vector2.zero;
            dropLocation.SetState(state);
            
        }
        else target.localPosition = startPos;
        
    }
}