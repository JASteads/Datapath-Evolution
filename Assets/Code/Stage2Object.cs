using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Object
{
    private List<Stage2ObjectComponent> components = new List<Stage2ObjectComponent>();
    private Image image;

    public Stage2Object(string name) {
        InterfaceTool.ImgSetup(name, null, out image, false);
    }

    public List<Stage2ObjectComponent> GetComponents() {
        return components;
    }

    public Image GetImage() {
        return image;
    }

    public void SetImage(Image image) {
        this.image = image;
    }

    public void SetPosition(Vector2 vec) {
        image.rectTransform.anchoredPosition = vec;
    }

    public Stage2ObjectComponent GetStage2ObjectComponent(RectTransform rectTransform) {
        Stage2ObjectComponent found = null;
        GetComponents().ForEach(component => {
            if (component.GetImage().rectTransform == rectTransform) {
                found = component;
            }
        });
        return found;
    }
}
