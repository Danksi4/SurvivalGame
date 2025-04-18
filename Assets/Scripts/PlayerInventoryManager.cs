using UnityEngine;
using System.Collections.Generic;

/*
This script keeps track of everything in the players inventory and handles adding and removing items from the players inventory

Member functions:
AddItemsToPlayerInventory(int itemId, int quantity): Adds a quanitity of some item to the player inventory given its item id

*/

public class PlayerInventoryManager : MonoBehaviour
{
    // Singleton definition
    private static PlayerInventoryManager _instance;
    public static PlayerInventoryManager Instance { get { return _instance; } }

    public Dictionary<int, int> playerInventory = new Dictionary<int, int>(); // Maps an item id to a quantity of that item

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

    public void AddItemsToPlayerInventory(int itemId, int quantity)
    {
        if (playerInventory.ContainsKey(itemId))
        {
            playerInventory[itemId] += quantity; // Increment the quantity
        }
        else
        {
            playerInventory.Add(itemId, quantity); // Add new item if it's not in inventory
        }

        PrintPlayerInventory();
    }

    void PrintPlayerInventory()
    {
        foreach(int key in playerInventory.Keys)
        {
            string itemName = ResourceManager.Instance.resourceList[key];
            int amount = playerInventory[key];
            Debug.Log($"{itemName}: {amount}");
        }
    }

}
