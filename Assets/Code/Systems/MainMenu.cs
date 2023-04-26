using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject prefab;

    public Button startButton, stageButton, creditButton, quitButton;

    void Start()
    {
        Instantiate(prefab, transform);

        startButton = prefab.transform.
            GetChild(3).GetComponent<Button>();
        stageButton = prefab.transform.
            GetChild(4).GetComponent<Button>();
        creditButton = prefab.transform.
            GetChild(5).GetComponent<Button>();
        quitButton = prefab.transform.
            GetChild(6).GetComponent<Button>();

        startButton.onClick.AddListener(() =>
        {
            Debug.Log("Click");
        });
        quitButton.onClick.AddListener(SysManager.Quit);
    }

}