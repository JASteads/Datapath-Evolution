using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Level
{
    public static Vector2 DEF_VEC = new Vector2(0.5F, 0.5F);

    readonly string name;
    protected GameObject levelObj;

    public Level(string name) {
        this.name = name;
        levelObj = new GameObject("Stage");
        levelObj.transform.SetParent(
            SysManager.canvas.transform, false);
    }

    public string GetName() {
        return name;
    }

    public virtual void EnableTooltips() {
        Debug.Log("Tooltips to be enabled!");
    }
    
    public virtual void OnWin() {
        Debug.Log("Level" + GetName() + "complete");
    }

    public abstract bool CheckWinCondition();

    public void Destroy() {
        GameObject.Destroy(levelObj);
    }

    protected void ResetObjects() {
        Destroy();
        levelObj = new GameObject("Stage");
        levelObj.transform.SetParent(
            SysManager.canvas.transform, false);
    }

    protected void CreateIntroductionBox(string description, Action action) {
        GameObject descriptionObj = InterfaceTool.ImgSetup("Okay", levelObj.transform, out Image descriptionImg, false);
        InterfaceTool.FormatRect(descriptionImg.rectTransform, new Vector2(1200, 400), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        descriptionImg.color = new Color(0.5F, 0.5F, 0.5F, 0.5F);
        Text descriptionText = InterfaceTool.CreateHeader(description,
            descriptionImg.transform, new Vector2(0, 200), new Vector2(0, -250), 32);
        descriptionText.alignment = TextAnchor.MiddleCenter;
        descriptionText.color = Color.black;

        GameObject okayObj = InterfaceTool.ButtonSetup("Okay", descriptionObj.transform, out Image okayImg, out Button button, null, null);
        InterfaceTool.FormatRect(okayImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -100));
        button.onClick.AddListener(() => {
            ResetObjects();
            SysManager.quitObj.SetActive(true);
            action.Invoke();
        });
        okayImg.color = new Color(0.3F, 0.3F, 0.3F);
        Text okayText = InterfaceTool.CreateHeader("Okay", okayImg.transform, new Vector2(0, 40), new Vector2(0, -50), 24);
        okayText.alignment = TextAnchor.MiddleCenter;
        okayText.color = Color.black;
    }
}