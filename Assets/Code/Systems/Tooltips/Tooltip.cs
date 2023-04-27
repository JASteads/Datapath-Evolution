using UnityEngine;
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
        tf = textBox.transform;
        InterfaceTool.FormatRect(boxImg.rectTransform,
            new Vector2(400, 700), Vector2.one,
            Vector2.one, Vector2.one, new Vector2(-100, -100));
        boxImg.color = new Color(0, 0, 0, 0.5f);

        headerTxt = InterfaceTool.CreateHeader("Sample Text",
            textBox.transform, new Vector2(300, 50), new Vector2(40, -80), 24);
        bodyTxt = InterfaceTool.CreateBody("Insert text here",
            textBox.transform, 14);
        InterfaceTool.FormatRect(bodyTxt.rectTransform,
            new Vector2(-80, -200), new Vector2(0, 0),
            new Vector2(1, 1), new Vector2(0, 1),
            new Vector2(40, -100));
        bodyTxt.alignment = TextAnchor.UpperLeft;
        bodyTxt.color = Color.white;

        textBox.SetActive(false);
    }

    public void SetActive(bool _isActive)
    {
        isActive = _isActive;
        if (isActive) tf.SetAsLastSibling();
    }

    public void AssignTooltip(Transform target)
    {
        EventTrigger.Entry enterEvent = new EventTrigger.Entry
        { eventID = EventTriggerType.PointerEnter },
            exitEvent = new EventTrigger.Entry
            { eventID = EventTriggerType.PointerExit };

        enterEvent.callback.AddListener(data
           => ShowTooltip(data as PointerEventData));
        exitEvent.callback.AddListener(data
            => HideTooltip(data as PointerEventData));

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