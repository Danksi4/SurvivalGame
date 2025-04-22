using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Instance { get { return _instance; } }

    private int currItemId = 0;
    public int CurrItemId { get { return currItemId; } }

    public int stackSize_smallItem = 20;
    public int stackSize_largeItem = 10;

    public List<Item> itemList = new List<Item>();

    public Dictionary<int, Item> resourceList = new Dictionary<int, Item>(); // Maps an item id to the string of the item

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

    public int GenerateItemId()
    {
        int newItemId = currItemId + 1;
        currItemId = newItemId;
        return newItemId;
    }

}
