using UnityEngine;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour
{
    Canvas clickCanvas;
    Button nodeOut, nodeIn;
    Image dragLine;

    UnityEngine.Events.UnityAction startDrag;

    void Start()
    {
        GameObject canvasObj = InterfaceTool.CanvasSetup(
            "Click Canvas", transform, out clickCanvas);
        GameObject nodeOutObj = InterfaceTool.ButtonSetup(
            "Node Out", clickCanvas.transform, out Image nOutImg,
            out nodeOut, null, null);
        InterfaceTool.FormatRect(nOutImg.rectTransform,
            new Vector2(50, 50), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(-200, 0));

        GameObject nodeInObj = InterfaceTool.ButtonSetup(
            "Node In", clickCanvas.transform, out Image nInImg,
            out nodeIn, null, null);
        InterfaceTool.FormatRect(nInImg.rectTransform,
            new Vector2(50, 50), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(200, 0));

        GameObject lineObj = InterfaceTool.ImgSetup(
            "Drag Line", clickCanvas.transform, out dragLine, false);
        dragLine.gameObject.SetActive(false);
    }
    
    void Update()
    {
        
    }
}
