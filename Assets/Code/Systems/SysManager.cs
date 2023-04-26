using UnityEngine;

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

        /*** Test instance of Stage 2 ***/

        currentLevel = new Stage2("Stage 2", clickCanvasObj.transform, true, false, false, true, false, true, false);

        /***   End of Test Stage 2   ***/
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}