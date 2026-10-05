using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    InputAction inventoryAction;
    [SerializeField] private GameObject InventoryCanvas;
    private bool InventoryActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryAction = InputSystem.actions.FindAction("Inventory");
        InventoryCanvas.SetActive(false);
        InventoryActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryAction.triggered && !InventoryCanvas != null && InventoryActive == false)
        {
            InventoryActive = true;
            InventoryCanvas.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Inventory dibuka");
        }
        else if (inventoryAction.triggered && !InventoryCanvas != null && InventoryActive == true)
        {
            InventoryActive = false;
            InventoryCanvas.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("Inventory ditutup");
        }
    }
}
