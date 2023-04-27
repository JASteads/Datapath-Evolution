﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip
{
    Transform tf;
    Text headerTxt, bodyTxt;
    bool isActive = false;

    public Tooltip(Transform parent)
    {
        GameObject textBox = InterfaceTool.ImgSetup("Tooltip",
            parent, out Image boxImg, false);
        InterfaceTool.FormatRect(boxImg.rectTransform,
            new Vector2(400, 700), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), Vector2.zero);

        headerTxt = InterfaceTool.CreateHeader("Sample Text",
            textBox.transform, new Vector2(300, 50), new Vector2(-50, 0), 24);
        bodyTxt = InterfaceTool.CreateBody("Insert text here",
            textBox.transform, 14);

        textBox.SetActive(false);
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
    }

    public void AssignTooltip(Transform target)
    {
        EventTrigger.Entry enterEvent = new EventTrigger.Entry
        { eventID = EventTriggerType.PointerEnter },
            exitEvent = new EventTrigger.Entry
            { eventID = EventTriggerType.PointerExit },
            moveEvent = new EventTrigger.Entry
            { eventID = EventTriggerType.Move };

        enterEvent.callback.AddListener(data
           => ShowTooltip(data as PointerEventData));
        exitEvent.callback.AddListener(data
            => HideTooltip(data as PointerEventData));
        moveEvent.callback.AddListener(data => MoveTooltip());

        EventTrigger eTrig = target.gameObject
            .AddComponent<EventTrigger>();
        eTrig.triggers.Add(enterEvent);
        eTrig.triggers.Add(exitEvent);
    }

    void ShowTooltip(PointerEventData data)
    {
        if (!isActive) return;

        TooltipLibrary.FetchInfo(data.pointerEnter.name,
            out string newHeader, out string newBody);

        headerTxt.text = newHeader;
        bodyTxt.text = newBody;

        tf.gameObject.SetActive(true);
    }

    void HideTooltip(PointerEventData data)
    {
        if (!isActive) return;

        tf.gameObject.SetActive(false);
    }

    void MoveTooltip()
    {
        if (!tf.gameObject.activeSelf) return;

        tf.localPosition = Input.mousePosition;
    }
}