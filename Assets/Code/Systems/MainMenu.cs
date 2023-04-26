using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject prefab, stageSelect, creditsScreen;
    List<GameObject> menuStack = new List<GameObject>();
    GameObject currentMenu;
    
    Transform menu;
    Button startButton, stageButton, creditButton, quitButton,
        backButton;

    void Start()
    {
        menu = Instantiate(prefab, transform).transform;

        startButton = menu.GetChild(3).GetComponent<Button>();
        stageButton = menu.GetChild(4).GetComponent<Button>();
        creditButton = menu.GetChild(5).GetComponent<Button>();
        quitButton = menu.GetChild(6).GetComponent<Button>();

        GameObject backButtonObj = InterfaceTool.ButtonSetup(
            "Back Button", SysManager.canvas.transform, 
            out Image bImg, out backButton, null, null);

        startButton.onClick.AddListener(() =>
        {
            SysManager.SetLevel(SysManager.GetStage1());
            UnloadMenus();
        });
        stageButton.onClick.AddListener(() =>
        { Debug.Log("Click"); });
        creditButton.onClick.AddListener(() =>
        { Debug.Log("Click"); });
        quitButton.onClick.AddListener(SysManager.Quit);
    }

    void UnloadMenus()
    {
        Destroy(backButton.gameObject);
        Destroy(menu.gameObject);
        Destroy(gameObject.GetComponent<MainMenu>());
    }
}