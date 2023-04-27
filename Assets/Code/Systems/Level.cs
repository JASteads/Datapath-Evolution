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
        SysManager.tooltip.SetActive(false);
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

    protected void CreateWinScreen(string description, Action nextLevel) {
        GameObject winObj = InterfaceTool.ImgSetup("You Win!", levelObj.transform, out Image winImg, false);
        InterfaceTool.FormatRect(winImg.rectTransform, new Vector2(1200, 400), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        winImg.color = new Color(0.25F, 0.25F, 0.25F);
        Text winText = InterfaceTool.CreateHeader("You Win!",
            winImg.transform, new Vector2(0, 200), new Vector2(0, -250), 32);
        winText.alignment = TextAnchor.MiddleCenter;
        //next level
        GameObject nextObj = InterfaceTool.ButtonSetup(description, winObj.transform, out Image nextImg, out Button nextButton, null, null);
        InterfaceTool.FormatRect(nextImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(150, -100));
        nextButton.onClick.AddListener(() => {
            GameObject.Destroy(nextObj);
            nextLevel.Invoke();
        });
        nextImg.color = new Color(0.5F, 0.5F, 0.5F);
        Text nextText = InterfaceTool.CreateHeader(description, nextImg.transform, new Vector2(0, 40), new Vector2(0, -50), 24);
        nextText.alignment = TextAnchor.MiddleCenter;
        nextText.color = Color.black;
        //review level
        GameObject reviewObject = InterfaceTool.ButtonSetup("Review Level", winObj.transform, out Image reviewImage, out Button reviewButton, null, () => {
            nextObj.transform.SetParent(SysManager.canvas.transform);
            InterfaceTool.FormatRect(nextImg.rectTransform, nextImg.rectTransform.sizeDelta, new Vector2(1, 0), new Vector2(1, 0), new Vector2(1, 0), new Vector2(-20, 20));
            winObj.SetActive(false);
            SysManager.tooltip.SetActive(true);
        });
        InterfaceTool.FormatRect(reviewImage.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(-150, -100));
        reviewImage.color = new Color(0.5F, 0.5F, 0.5F);
        Text reviewText = InterfaceTool.CreateHeader("Review Level", reviewImage.transform, new Vector2(0, 40), new Vector2(0, -50), 24);
        reviewText.alignment = TextAnchor.MiddleCenter;
        reviewText.color = Color.black;
    }
}