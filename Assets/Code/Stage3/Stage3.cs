using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Stage3 : Level
{
    private static Vector2 DEF_VEC = new Vector2(0.5F, 0.5F);

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
        GameObject descriptionObj = InterfaceTool.ImgSetup("Okay", levelObj.transform, out Image descriptionImg, false);
        InterfaceTool.FormatRect(descriptionImg.rectTransform, new Vector2(1200, 400), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, 0));
        descriptionImg.color = new Color(0.5F, 0.5F, 0.5F, 0.5F);
        Text descriptionText = InterfaceTool.CreateHeader("blah blah blah insert stage 3 description here.",
            descriptionImg.transform, new Vector2(0, 200), new Vector2(0, -250), 32);
        descriptionText.alignment = TextAnchor.MiddleCenter;
        descriptionText.color = Color.black;

        GameObject okayObj = InterfaceTool.ButtonSetup("Okay", descriptionObj.transform, out Image okayImg, out Button button, null, null);
        InterfaceTool.FormatRect(okayImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -100));
        button.onClick.AddListener(() => {
            ResetObjects();
            CreatePhase1Objects();
        });
        okayImg.color = new Color(0.3F, 0.3F, 0.3F, 1);
        Text okayText = InterfaceTool.CreateHeader("Okay", okayImg.transform, new Vector2(0, 40), new Vector2(0, -50), 24);
        okayText.alignment = TextAnchor.MiddleCenter;
        okayText.color = Color.black;
    }

    private void CreatePhase1Objects() {
        System.Random rand = new System.Random();
        List<DropLocation> dropLocations = new List<DropLocation>();
        //slots
        for (int i = 0; i < 4; i++) {
            Stage3P1SlotObject obj = new Stage3P1SlotObject(levelObj, i, new Vector2((i * 250) - 375, 100), dropLocations);
        }
        //list
        DropLocationList dropLocationList = new DropLocationList(dropLocations);
        //draggables
        List<string> names = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        List<string> persistentNames = new List<string>{"IF/ID", "ID/EX", "EX/MEM", "MEM/WB"};
        int xPos = -375;
        while (names.Count > 0) {
            int index = rand.Next(names.Count);
            string name = names[index];
            Stage3P1DraggableObject obj = new Stage3P1DraggableObject(levelObj, name, persistentNames.IndexOf(name), dropLocationList, new Vector2(xPos, -200));
            names.RemoveAt(index);
            xPos += 250;
        }
        //valid check
        GameObject winCheckObj = InterfaceTool.ButtonSetup("Check Indexes", levelObj.transform, out Image winCheckImg, out Button button, null, () => {
            bool valid = true;
            dropLocationList.dLocations.ForEach(dropLocation => {
                if (!dropLocation.IsCorrectState()) {
                    valid = false;
                }
            });
            if (valid) {
                ResetObjects();
            }
        });
        InterfaceTool.FormatRect(winCheckImg.rectTransform, new Vector2(180, 60), DEF_VEC, DEF_VEC, DEF_VEC, new Vector2(0, -400));
        winCheckImg.color = Color.gray;
        Text txt = InterfaceTool.CreateHeader("Check Indexes", winCheckImg.transform, new Vector2(60, 20), new Vector2(35, -40), 16);
        txt.color = Color.black;
    }
}