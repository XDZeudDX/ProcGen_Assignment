using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesToSpawn : MonoBehaviour
{


    public GameObject treeToSpawn;

    public int numTree = 1;
    

    public float itemXSpreadTree = 10;
    public float itemYSpreadTree = 0;
    public float itemZSpreadTree = 10;

    private bool hasSpawned = false;

    private Vector3 spawnOrigin;

    // Start is called before the first frame update
    void Start()
    {
        spawnOrigin = transform.position;
    }

    void SpreadTrees()
    {
        Vector3 randomPos = spawnOrigin + new Vector3(Random.Range(-itemXSpreadTree, itemXSpreadTree), Random.Range(-itemYSpreadTree, itemYSpreadTree), Random.Range(-itemZSpreadTree, itemZSpreadTree)) + transform.position;
        GameObject cloneTree = Instantiate(treeToSpawn, randomPos, Quaternion.identity);

    }

        private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;

            for (int i = 0; i < numTree; i++)
            {
                SpreadTrees();
            }

            // Reset hasSpawned after a delay
            StartCoroutine(ResetSpawn());
            
        }
    }


                private IEnumerator ResetSpawn()
    {
        // Optional: Add a delay before resetting (e.g., 1 second)
        yield return new WaitForSeconds(1f);

        // Reset hasSpawned for reuse
        hasSpawned = false;

        // Optional: Debug log for confirmation
        Debug.Log("Trigger reset and ready to spawn again.");
    }
}
    
    

