using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotObject
{
    private Image image;

    public SlotObject(GameObject levelObj, int slot, Vector2 position, List<DropLocation> dropLocations) {
        InterfaceTool.ImgSetup("Slot " + slot, levelObj.transform, out image, SysManager.sprites[10], true);
        InterfaceTool.FormatRect(image.rectTransform, new Vector2(180, 180), position);
        dropLocations.Add(new DropLocation(GetTF(), slot));
    }

    public RectTransform GetTF() {
        return image.rectTransform;
    }
}
