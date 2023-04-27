using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject pMainMenu, pStageSelect, pCreditsScreen;
    GameObject mainMenu, stageSelect, creditsScreen,
        previewScreen;

    List<GameObject> screens = new List<GameObject>();
    Button backButton, startButton;
    RectTransform menuParent;
    StagePreview sPreview;

    void Start()
    {
        Transform menu;
        
        menuParent = new GameObject("Menus").AddComponent<RectTransform>();
        menuParent.SetParent(SysManager.canvas.transform, false);
        InterfaceTool.FormatRect(menuParent);

        mainMenu = Instantiate(pMainMenu, menuParent);
        stageSelect = Instantiate(pStageSelect, menuParent);
        creditsScreen = Instantiate(pCreditsScreen, menuParent);
        previewScreen = new GameObject("Preview Screen");

        stageSelect.SetActive(false);
        creditsScreen.SetActive(false);
        screens.Add(mainMenu);

        // TITLE SCREEN CONFIGURATION
        
        menu = mainMenu.transform;
        {
            Button startButton = menu.GetChild(3).GetComponent<Button>();
            Button stageButton = menu.GetChild(4).GetComponent<Button>();
            Button credButton = menu.GetChild(5).GetComponent<Button>();
            Button quitButton = menu.GetChild(6).GetComponent<Button>();

            startButton.onClick.AddListener(() =>
            {
                SysManager.SetLevel(SysManager.GetStage1());
                UnloadScreens();
            });
            stageButton.onClick.AddListener(() =>
            { LoadScreen(stageSelect); });
            credButton.onClick.AddListener(() =>
            { LoadScreen(creditsScreen); });
            quitButton.onClick.AddListener(SysManager.Quit);
        }

        // STAGE SELECT CONFIGURATION

        menu = stageSelect.transform;
        {
            Button[] stageButtons = new Button[5];

            stageButtons[0] = menu.GetChild(1).GetComponent<Button>();
            stageButtons[1] = menu.GetChild(2).GetComponent<Button>();
            stageButtons[2] = menu.GetChild(3).GetComponent<Button>();
            stageButtons[3] = menu.GetChild(5).GetChild(1)
                .GetComponent<Button>();
            stageButtons[4] = menu.GetChild(6).GetChild(1)
                .GetComponent<Button>();

            for (int i = 0; i < stageButtons.Length; i++)
            {
                int val = i;
                stageButtons[i].onClick.AddListener(() =>
                {
                    startButton.interactable = val < 3;
                    LoadScreen(previewScreen);
                    sPreview.Set(val);
                });
            }
        }

        // PREVIEW SCREEN CONFIGURATION

        {
            RectTransform pScreenTF = 
                previewScreen.AddComponent<RectTransform>();
            pScreenTF.SetParent(menuParent, false);
            InterfaceTool.FormatRect(pScreenTF);
            sPreview = new StagePreview(previewScreen.transform);

            GameObject startButtonObj = InterfaceTool.ButtonSetup(
                "Start Button", pScreenTF, out Image sImg,
                out startButton, null, StartGame);
            InterfaceTool.FormatRect(sImg.rectTransform,
                new Vector2(200, 100), Vector2.zero, 
                Vector2.zero, Vector2.zero, 
                new Vector2(300, 250));
            InterfaceTool.CreateBody(
                "START", sImg.rectTransform, 18);

            previewScreen.SetActive(false);
        }
        

        // BACK BUTTON CONFIGURATION

        GameObject backButtonObj = InterfaceTool.ButtonSetup(
            "Back Button", menuParent, out Image bImg,
            out backButton, null, ExitScreen);
        InterfaceTool.FormatRect(bImg.rectTransform,
            new Vector2(50, 50), Vector2.zero, Vector2.zero,
            Vector2.zero, new Vector2(50, 50));
        InterfaceTool.CreateBody("<<", bImg.rectTransform, 18);
        bImg.gameObject.SetActive(false);
    }

    void UnloadScreens()
    {
        Destroy(menuParent.gameObject);
        Destroy(gameObject.GetComponent<MainMenu>());
    }

    void LoadScreen(GameObject screen)
    {
        screens[screens.Count - 1].SetActive(false);
        screens.Add(screen);
        screen.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    void ExitScreen()
    {
        int topIndex = screens.Count - 1;

        screens[topIndex].SetActive(false);
        screens[topIndex - 1].SetActive(true);
        screens.RemoveAt(topIndex);
        backButton.gameObject.SetActive(screens.Count > 1);
    }

    void StartGame()
    {
        switch (sPreview.selectedStage)
        {
            case 0:
                SysManager.SetLevel(SysManager.GetStage1());
                break;
            case 1:
                SysManager.SetLevel(SysManager.GetStage2());
                break;
            case 2:
                SysManager.SetLevel(SysManager.GetStage3());
                break;
        }
        UnloadScreens();
    }
}