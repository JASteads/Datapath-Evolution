using UnityEngine;
using UnityEngine.UI;

public class Diagram : MonoBehaviour
{
    const int SLOT_COUNT = 4;

    public GameObject prefab;
    Slot[] slots;

    void Start()
    {
        const int INS_INDEX = 5;

        prefab = Instantiate(prefab);
        
        Button[] rightButtons = new Button[SLOT_COUNT],
            leftButtons = new Button[SLOT_COUNT];
        slots = new Slot[SLOT_COUNT];

        for (int i = 0; i < SLOT_COUNT; i++)
        {
            int slotNum = i;

            rightButtons[i] = prefab.transform.GetChild(INS_INDEX)
                .GetChild(i).GetChild(0).GetComponent<Button>();
            rightButtons[i].onClick.AddListener(() 
                => MoveRight(slotNum));
            leftButtons[i] = prefab.transform.GetChild(INS_INDEX)
                .GetChild(i).GetChild(1).GetComponent<Button>();
            leftButtons[i].onClick.AddListener(()
                => MoveLeft(slotNum));
        }
    }

    void MoveLeft(int slotNum)
    {
        
    }

    void MoveRight(int slotNum)
    {

    }
}
