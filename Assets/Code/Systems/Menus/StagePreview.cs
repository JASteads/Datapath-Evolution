using UnityEngine;
using UnityEngine.UI;

public class StagePreview
{
    public GameObject obj;
    Text title, desc;
    public int selectedStage;

    public StagePreview(Transform parent)
    {
        obj = new GameObject("Stage Preview");
        obj.transform.SetParent(parent, false);
        InterfaceTool.FormatRect(obj.AddComponent<RectTransform>());
        
        GameObject background = InterfaceTool.ImgSetup("Background",
            obj.transform, out Image bg, true);
        InterfaceTool.FormatRect(bg.rectTransform);
        bg.color = new Color(0, 0, 0, 0.5f);

        GameObject descObj = InterfaceTool.TextSetup("Description",
            background.transform, out desc, false);
        InterfaceTool.FormatRect(desc.rectTransform,
            new Vector2(600, 400), new Vector2(0, 0.5f),
            new Vector2(0, 0.5f), new Vector2(0, 0.5f),
            new Vector2(300, 0));
        InterfaceTool.FormatText(desc, SysManager.DEFAULT_FONT,
            18, Color.white, TextAnchor.UpperLeft, FontStyle.Normal);
        title = InterfaceTool.CreateHeader("Stage Title",
            descObj.transform, new Vector2(200, 80),
            Vector2.zero, 32);
    }

    public void Set(int index)
    {
        selectedStage = index;

        switch (index)
        {
            case 0:
                title.text = "The Single Datapath";
                desc.text = "Assemble the single datapath by " +
                    "placing components into the correct positions.";
                break;
            case 1:
                title.text = "Instructions";
                desc.text = "Given an instruction, toggle the " +
                    "necessary control signals needed to complete " +
                    "it. Then, wire up the necessary components " +
                    "based on those signals.";
                break;
            case 2:
                title.text = "In the Pipeline";
                desc.text = "Drag and drop pipeline state " +
                    "hardware into the correct positions. " +
                    "Then, optimize a set of instructions " +
                    "given in a pipeline diagram.";
                break;
            case 3:
                title.text = "Superscalars [Unavailable]";
                desc.text = "Superscalar technology improves the" +
                    " execution speed of instructions by allowing" +
                    " the processor to issue multiple instructions" +
                    " at the same time, utilizing multiple" +
                    " functional components within the processor. " +
                    "Processors using superscalar technology can " +
                    "execute multiple instructions in a single" +
                    " clock cycle. To support simultaneous" +
                    " execution of multiple instructions, a" +
                    " superscalar processor must have at least two" +
                    " or more instruction pipelines that can work" +
                    " simultaneously. The processor uses" +
                    " sophisticated algorithms to determine which" +
                    " instructions can be executed in parallel " +
                    "while maintaining correct execution order and" +
                    " data dependencies. This allows the processor" +
                    " to achieve higher instruction throughput," +
                    " resulting in improved performance.";
                break;
            case 4:
                title.text = "Hyperthreading [Unavailable]";
                desc.text = "Hyperthreading is a technology" +
                    " introduced by Intel that simulates two" +
                    " logical cores inside a multi-threaded" +
                    " processor as two physical chips, allowing a" +
                    " single processor to execute two threads in" +
                    " parallel. This makes it compatible with" +
                    " multi-threaded operating systems and" +
                    " software. Hyper-Threading technology" +
                    " maximizes the use of idle CPU resources," +
                    " enabling more work to be completed in the" +
                    " same amount of time.";
                break;
            default:
                Debug.Log("Invalid stage preview index");
                break;
        }
    }
}
