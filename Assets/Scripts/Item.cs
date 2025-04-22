using UnityEngine;

public class Item : MonoBehaviour
{
    // Item identifiers
    private int itemId;
    [SerializeField] private string itemName;
    public string ItemName { get { return itemName; } }

    // Item characteristics
    private int itemQtty;
    public int ItemQtty { get { return itemQtty; } }
    private bool isStackable;
    private string itemSize;
    private int itemStackSize;

    // Item visuals
    [SerializeField] private Sprite itemSprite;
    public Sprite ItemSprite { get { return itemSprite; } }

    // Other
    private InventoryManager inventoryManager;

    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    void Start()
    {
        itemId = ResourceManager.Instance.GenerateItemId();
        inventoryManager = InventoryManager.Instance;
    }

    void AddItemsToPlayerInventory()
    {
        inventoryManager.AddItem(this);
    }
}
