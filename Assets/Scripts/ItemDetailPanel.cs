using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailPanel : MonoBehaviour
{
    [SerializeField] private Image itemimage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemDescriptionText;
    [SerializeField] private TMP_Text itemQtyText;

    public void Show(ItemDetails item,int quantity)
    {
        if (item == null)
        {
            Clear();
            return;
        }

        itemimage.sprite = item.ItemIcon;
        itemimage.enabled = true;
        itemNameText.text = item.ItemName;
        itemQtyText.text = "Quantity: " + quantity;
        itemDescriptionText.text = item.ItemDescription;
    }

    public void Clear()
    {
        itemimage.sprite = null;
        itemimage.enabled = false;
        itemNameText.text = "";
        itemQtyText.text = "";
        itemDescriptionText.text = "";
    }
}
