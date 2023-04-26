using UnityEngine;
using UnityEngine.UI;

public class Stage3P1Object
{
    private Button button;
    private int expectedIndex;

    public Stage3P1Object(string name, int expectedIndex) {
        InterfaceTool.ButtonSetup(name, SysManager.canvas.transform, out Image buttonImg, out button, null, null);
        this.expectedIndex = expectedIndex;
    }

    public RectTransform GetTF() {
        return button.image.rectTransform;
    }

    public void SetPosition(Vector2 vec) {
        button.image.rectTransform.anchoredPosition = vec;
    }
}
