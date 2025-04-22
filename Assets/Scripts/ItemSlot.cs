using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item itemInSlot;
    public GameObject itemSlotImage;
    public TMP_Text quantityText;

    void Awake()
    {
        if (itemInSlot != null)
        {
            Instantiate(itemInSlot, transform.position, Quaternion.identity);
            itemSlotImage.SetActive(true);
            itemSlotImage.GetComponent<Image>().sprite = itemInSlot.ItemSprite;
            quantityText.gameObject.SetActive(true);
            quantityText.text = itemInSlot.ItemQtty != null ? itemInSlot.ItemQtty.ToString() : "0";
        }
    }
}
