using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Stage3 : Level
{
    private static Vector2 DEF_VEC = new Vector2(0.5F, 0.5F);

    private bool validPhase1 = false;

    public Stage3(string name) : base(name)
    {
        CreateObjects();
    }

    public override void OnLevelStart()
    {
        Debug.Log("Activation on level start.");
    }

    public override void EnableTooltips()
    {
        Debug.Log("Tooltips to be enabled!");
    }

    public override void OnWin()
    {
        Debug.Log("Level" + GetName() + "complete");
    }

    public override bool CheckWinCondition()
    {
        return false;
    }

    private void CreateObjects() {
        GameObject descriptionObj = InterfaceTool.ImgSetup("Okay", SysManager.canvas.transform, out Image descriptionImg, false);
        InterfaceTool.FormatRect(descriptionImg.rectTransform, new Vector2(1200, 400), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        descriptionImg.color = new Color(0.5F, 0.5F, 0.5F, 0.5F);
        Text descriptionText = InterfaceTool.CreateHeader("blah blah blah insert stage 3 description here.",
            descriptionImg.transform, new Vector2(0, 200), new Vector2(0, -250), 32);
        descriptionText.alignment = TextAnchor.MiddleCenter;
        descriptionText.color = Color.black;

        GameObject okayObj = InterfaceTool.ButtonSetup("Okay", descriptionObj.transform, out Image okayImg, out Button button, null, null);
        InterfaceTool.FormatRect(okayImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -100));
        button.onClick.AddListener(() => {
            GameObject.Destroy(descriptionObj);
            GameObject.Destroy(okayObj);
            CreatePhase1Objects();
        });
        okayImg.color = new Color(0.3F, 0.3F, 0.3F, 1);
        Text okayText = InterfaceTool.CreateHeader("Okay", okayImg.transform, new Vector2(0, 40), new Vector2(0, -50), 24);
        okayText.alignment = TextAnchor.MiddleCenter;
        okayText.color = Color.black;
    }

    private void CreatePhase1Objects() {
        Dictionary<string, int> names = new Dictionary<string, int>();
        names.Add("IF/ID", 0);
        names.Add("ID/EX", 1);
        names.Add("EX/MEM", 2);
        names.Add("MEM/WB", 3);
        System.Random rand = new System.Random();
        int xPos = -375;
        while (names.Count > 0) {
            string name = names.Keys.ElementAt(rand.Next(names.Count));
            Stage3P1Object obj = new Stage3P1Object(name, names[name]);
            InterfaceTool.FormatRect(obj.GetTF(), new Vector2(150, 150), new Vector2(xPos, -200));
            Text text = InterfaceTool.CreateHeader(name, obj.GetTF(), new Vector2(0, 30), new Vector2(0, -90), 24);
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            names.Remove(name);
            xPos += 250;
        }
    }
}