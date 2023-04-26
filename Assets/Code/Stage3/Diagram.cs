using UnityEngine;
using UnityEngine.UI;

public class Diagram : MonoBehaviour
{
    public GameObject prefab;

    // public Button leftRightButtons

    void Start()
    {
        Instantiate(prefab);

        // Add functionality to the buttons and movable slots
    }
}
