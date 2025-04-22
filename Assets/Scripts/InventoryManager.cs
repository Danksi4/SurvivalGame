using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance { get { return _instance; } }

    public GameObject inventoryMenu;
    public GameObject inventoryMenuBG;
    private bool menuActivated;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;  // Assign this instance as the singleton
            DontDestroyOnLoad(gameObject); // Optionally keep it across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuActivated)
        {
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            inventoryMenuBG.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !menuActivated)
        {
            Time.timeScale = 0; // Essentially pauses the game
            inventoryMenu.SetActive(true);
            inventoryMenuBG.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(Item item)
    {

    }
}
