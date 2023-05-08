using UnityEngine;
using UnityEngine.UI;

public class Diagram : MonoBehaviour
{
    const int INS_INDEX = 4;
    const int SLOTS_INDEX = 3;
    public readonly static int SLOT_COUNT = 4;
    public Slot[] slots = new Slot[SLOT_COUNT];

    public GameObject obj;
    RectTransform[] slotTF = new RectTransform[SLOT_COUNT];
    readonly Button[] rightButtons = new Button[SLOT_COUNT],
            leftButtons = new Button[SLOT_COUNT];
    readonly Vector2 deltaSlot = new Vector2(130, 0);
    

    void Awake()
    {
        obj = Instantiate(
            Resources.Load("Prefabs/Pipeline Diagram") as GameObject,
            SysManager.canvas.transform);
        obj.transform.localPosition = Vector3.zero;
        obj.SetActive(false);
        for (int i = 0; i < SLOT_COUNT; i++)
        {
            int slotNum = i;

            rightButtons[i] = obj.transform.GetChild(INS_INDEX)
                .GetChild(i).GetChild(0).GetComponent<Button>();
            rightButtons[i].onClick.AddListener(() 
                => MoveRight(slotNum));
            leftButtons[i] = obj.transform.GetChild(INS_INDEX)
                .GetChild(i).GetChild(1).GetComponent<Button>();
            leftButtons[i].onClick.AddListener(()
                => MoveLeft(slotNum));
            leftButtons[i].interactable = false;
            
            slotTF[i] = obj.transform.GetChild(SLOTS_INDEX)
                .GetChild(i).GetComponent<RectTransform>();
        }
        obj.SetActive(true);
    }

    void MoveLeft(int slotNum)
    {
        if (SysManager.currentLevel.IsFrozen()) return;
        
        int newPos = slots[slotNum].Translate(false);
        slotTF[slotNum].anchoredPosition -= deltaSlot;

        if (newPos == 0 || newPos == Slot.NO_MOVE)
            leftButtons[slotNum].interactable = false;
        rightButtons[slotNum].interactable = newPos < Slot.MAX_POS;
    }

    void MoveRight(int slotNum)
    {
        if (SysManager.currentLevel.IsFrozen()) return;
        
        int newPos = slots[slotNum].Translate(true);
        slotTF[slotNum].anchoredPosition += deltaSlot;

        if (newPos == Slot.MAX_POS || newPos == Slot.NO_MOVE)
            rightButtons[slotNum].interactable = false;
        leftButtons[slotNum].interactable = newPos > 0;
    }
    
    public bool IsCorrectPositions()
    {
        foreach (Slot s in slots)
            if (!s.CheckPosition()) return false;
        return true;
    }
}
