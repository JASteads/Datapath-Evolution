using UnityEngine;

public class SysManager
{
    public static Camera mainCam;
    public static readonly Font DEFAULT_FONT;
    public static readonly Sprite DEFAULT_BUTTON;

    static SysManager()
    {
        DEFAULT_FONT = Resources.GetBuiltinResource<Font>(
            "Arial.ttf");
        DEFAULT_BUTTON = null;

        InterfaceTool.defaultFont = DEFAULT_FONT;
    }

    [RuntimeInitializeOnLoadMethod]
    static void StartApplication()
    {
        mainCam = new GameObject("Main Camera")
            .AddComponent<Camera>();
        mainCam.tag = "MainCamera";
        mainCam.orthographic = true;

        GameObject testObj = new GameObject("Test Env");
        testObj.AddComponent<ClickEvents>();
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
