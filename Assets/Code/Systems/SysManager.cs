using UnityEngine;
using UnityEngine.UI;

public class SysManager
{
    public static Camera mainCam;
    public static Canvas canvas;
    public static readonly Font DEFAULT_FONT;
    public static readonly Sprite DEFAULT_BUTTON;
    public static Sprite[] sprites;

    public static Level currentLevel;

    static SysManager()
    {
        DEFAULT_FONT = Resources.GetBuiltinResource<Font>(
            "Arial.ttf");
        DEFAULT_BUTTON = null;
        sprites = Resources.LoadAll<Sprite>("Graphics");

        InterfaceTool.defaultFont = DEFAULT_FONT;
    }

    [RuntimeInitializeOnLoadMethod]
    static void StartApplication()
    {
        mainCam = new GameObject("Main Camera")
            .AddComponent<Camera>();
        mainCam.tag = "MainCamera";
        mainCam.orthographic = true;
        mainCam.backgroundColor = new Color(0.2f, 0.2f, 0.5f);

        GameObject clickCanvasObj = InterfaceTool.CanvasSetup(
            "Main Canvas", null, out canvas);
        // clickCanvasObj.AddComponent<MainMenu>();

        currentLevel = new Stage3("Stage 3");

        GameObject testObj = InterfaceTool.ImgSetup("Test",
            canvas.transform, out Image img, true);
        InterfaceTool.FormatRectNPos(img.rectTransform,
            new Vector2(50, 50), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        DragAndSnapEvent dse = new DragAndSnapEvent(testObj.transform, null);
        // clickCanvasObj.AddComponent<MainMenu>();

        currentLevel = new Stage3("Stage 3");

    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
