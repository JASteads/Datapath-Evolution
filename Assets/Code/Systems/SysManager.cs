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
        clickCanvasObj.AddComponent<MainMenu>();
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public static void SetLevel(Level level) {
        if (currentLevel != null) {
            currentLevel.Destroy();
        }
        currentLevel = level;
    }

    public static Level GetStage1() {
        return new Stage1();
    }

    public static Level GetStage2() {
        return new Stage2(true, false, false, true, false, true, false);
    }

    public static Level GetStage3() {
        return new Stage3();
    }
}
