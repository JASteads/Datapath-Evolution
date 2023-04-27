using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2Object
{
    private List<Stage2ObjectNode> nodes = new List<Stage2ObjectNode>();
    private Image image;

    public Stage2Object(string name) {
        InterfaceTool.ImgSetup(name, null, out image, true);
    }

    public List<Stage2ObjectNode> GetNodes() {
        return nodes;
    }

    public void AddNode(Stage2ObjectNode newNode)
    {
        nodes.Add(newNode);
    }

    public RectTransform GetTF() {
        return image.rectTransform;
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

    public Stage2ObjectNode GetStage2ObjectNode(Transform target) {
        Stage2ObjectNode found = null;
        nodes.ForEach(node => {
            if (node.GetTF() == target)
                found = node;
        });
        return found;
    }
}
