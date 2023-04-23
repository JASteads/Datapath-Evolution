using UnityEngine;
using UnityEngine.UI;

public class ConnectWire : MonoBehaviour
{
    const float WIRE_WIDTH = 10;
    Stage2ObjectComponent targetComponent;
    
    public void InitConnectWire(Transform target, 
        RectTransform wireTF, Image wireImg, Button delButton)
    {
        GameObject connectObj = InterfaceTool.ButtonSetup(
            $"Connector Wire", target,
            out wireImg, out delButton, null,
            null);

        delButton.onClick.AddListener(()
            => DeleteWire(connectObj.transform));

        InterfaceTool.FormatRectNPos(wireImg.rectTransform,
            new Vector2(wireTF.sizeDelta.x, WIRE_WIDTH),
            new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f),
            new Vector2(0, 0.5f));

        Stage2Object Stage2Object = SysManager.currentLevel.GetStage2Object(wireTF);
        if (Stage2Object != null) {
            targetComponent = Stage2Object.GetStage2ObjectComponent(wireTF);
        }
        if (targetComponent == null)
            Debug.Log("No level object component found");
        else
            targetComponent.SetCurrentState(true);
    }

    void DeleteWire(Transform targetNode)
    {
        targetComponent?.SetCurrentState(false);
        Destroy(gameObject);
    }
}