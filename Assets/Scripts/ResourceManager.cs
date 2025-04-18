using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Instance { get { return _instance; } }

    //playerInventory = PlayerInventoryManager.Instance;

    public Dictionary<int, string> resourceList = new Dictionary<int, string>()
    // Maps an item id to the string of the item
    {
        {1, "Wood"}
    };

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
}
