using UnityEngine;

public class Diagram : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        Instantiate(prefab);

        // Add functionality to the buttons and movable slots
    }
}
