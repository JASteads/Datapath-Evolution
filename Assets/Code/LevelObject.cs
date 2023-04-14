using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelObject
{
    private List<LevelObjectComponent> components;
    private Image image;

    public LevelObject(string name, List<LevelObjectComponent> components) {
        this.components = components;
        InterfaceTool.ImgSetup(name, null, out image, false);
    }

    public List<LevelObjectComponent> GetComponents() {
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
}
