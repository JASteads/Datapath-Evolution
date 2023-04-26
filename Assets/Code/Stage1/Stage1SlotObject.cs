using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1SlotObject
{
    private Image image;

    public Stage1SlotObject(GameObject levelObj, int slot, Vector2 position, List<DropLocation> dropLocations)
    {
        InterfaceTool.ImgSetup("Slot " + slot, levelObj.transform, out image, null, true);
        InterfaceTool.FormatRect(image.rectTransform, new Vector2(180, 180), position);
        image.color = Color.gray;
        dropLocations.Add(new DropLocation(GetTF(), slot));
    }

    public Image GetImage()
    {
        return image;
    }

    public void SetImage(Image image)
    {
        this.image = image;
    }

    public RectTransform GetTF()
    {
        return image.rectTransform;
    }
}
