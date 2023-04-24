using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SysManager
{
    public static Camera mainCam;
    public static Canvas canvas;
    public static readonly Font DEFAULT_FONT;
    public static readonly Sprite DEFAULT_BUTTON;

    public static Stage2 currentLevel;

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

        currentLevel = new Stage2("level 2", false, false, false, false, false, false, false);
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
