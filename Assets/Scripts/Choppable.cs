using UnityEngine;

/*
This script is what makes the tree choppable

Member functions:
ChopTree(): Will force the player to walk towards the tree and perform the chopping animation
SetVisualActive(bool active): Enables or disables the little radius around the bottom of the tree if the player is withing range

*/

public class Choppable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float interactionRadius = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject radiusVisual;

    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        SetVisualActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        playerInRange = dist <= interactionRadius;
        
        if (playerInRange)
        {
   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChopTree();
            }
        }
    }

    void ChopTree()
    {
        Debug.Log("Tree chopped!");
        gameObject.SetActive(false);
        InventoryManager.Instance.AddItem(ResourceManager.Instance.itemList[0]);
    }

    public void SetVisualActive(bool active)
    {
        radiusVisual.SetActive(active);
    }
}
