using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3P1DraggableObject
{
    private Image image;

    public Stage3P1DraggableObject(string name, int currentSlot, DropLocationList dropLocationList, Vector2 position) {
        InterfaceTool.ImgSetup(name, SysManager.canvas.transform, out image, null, true);
        InterfaceTool.FormatRect(image.rectTransform, new Vector2(150, 150), position);
        Text text = InterfaceTool.CreateHeader(name, GetTF(), new Vector2(0, 30), new Vector2(0, -90), 24);
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
        new DragAndSnapEvent(image, dropLocationList, currentSlot);
    }

    public Transform GetTF() {
        return image.transform;
    }

    public void SetPosition(Vector2 vec) {
        image.rectTransform.anchoredPosition = vec;
    }
}
