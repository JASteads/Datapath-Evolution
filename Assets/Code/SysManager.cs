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
        InterfaceTool.CanvasSetup("Canvas", null, out canvas);

        GameObject testObj = new GameObject("Test Env");
        // testObj.AddComponent<ClickEvents>();
        List<LevelObject> levelObjects = new List<LevelObject>();
        levelObjects.Add(new LevelObject("test1", new List<LevelObjectComponent>()));
        new Level(levelObjects);
    }

    public static void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
