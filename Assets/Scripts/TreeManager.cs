using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/*
This script is applied to the TreeManager object and manages all trees in the scene

Member functions:
GetClosestTreeInRange(): Returns the closest tree (game object with the shoppable component)

*/

public class TreeManager : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 5f;
    [SerializeField] private Transform player;
    private List<Choppable> allTrees = new List<Choppable>();
    private Choppable currentClosest;

    void Start()
    {
        allTrees = FindObjectsOfType<Choppable>().ToList();
    }

    void Update()
    {
        Choppable closestTree = null;
        float closestDist = Mathf.Infinity;

        foreach (var tree in allTrees)
        {
            float dist = Vector3.Distance(player.position, tree.transform.position);
            if (dist <= interactionRadius && dist < closestDist)
            {
                closestTree = tree;
                closestDist = dist;
            }
        }

        // Update visuals
        if (closestTree != currentClosest)
        {
            if (currentClosest != null)
                currentClosest.SetVisualActive(false);

            currentClosest = closestTree;

            if (currentClosest != null)
                currentClosest.SetVisualActive(true);
        }
    }

    public Choppable GetClosestTreeInRange()
    {
        return currentClosest;
    }
}
