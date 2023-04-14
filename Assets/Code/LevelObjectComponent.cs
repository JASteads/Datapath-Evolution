using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObjectComponent
{
    private Image image;

    private bool currentState = false, expectedState = false;

    public LevelObjectComponent(LevelObject obj, string name, bool expectedState) {
        this.expectedState = expectedState;
        InterfaceTool.ImgSetup(name, obj.GetImage().transform, out image, true);
    }

    public Image GetImage() {
        return image;
    }

    public void SetImage(Image image) {
        this.image = image;
    }

    public bool GetCurrentState() {
        return currentState;
    }

    public void SetCurrentState(bool state) {
        currentState = state;
    }

    public bool GetExpectedState() {
        return expectedState;
    }

    public void SetPosition(Vector2 vec) {
        image.rectTransform.anchoredPosition = vec;
    }
}
