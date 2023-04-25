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

        Stage2Object stageObj = new Stage2Object("Stage Object");
        
        InterfaceTool.FormatRectNPos(stageObj.GetTF(), Vector2.zero);

        Stage2ObjectNode nodeOutObj = new Stage2ObjectNode(stageObj, "Out Node", true, NodeType.OUTPUT, 0);
        Stage2ObjectNode nodeInObj = new Stage2ObjectNode(stageObj, "In Node", true, NodeType.INPUT, 0);

        nodeOutObj.GetTF().anchoredPosition = new Vector2(-400, 0);

        stageObj.AddNode(nodeOutObj);
        stageObj.AddNode(nodeInObj);

        (currentLevel as Stage2).AddLevelObject(stageObj);

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
