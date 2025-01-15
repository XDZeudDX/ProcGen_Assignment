using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersToSpawn : MonoBehaviour
{

    public GameObject flowerToSpawn;

    public int numFlower = 1;
    

    public float itemXSpreadFlower = 10;
    public float itemYSpreadFlower = 0;
    public float itemZSpreadFlower = 10;

    private bool hasSpawned = false;
    public Vector3 moveDistance = new Vector3(10, 0, 0);

    private Vector3 spawnOrigin;

    // Start is called before the first frame update
    void Start()
    {
        spawnOrigin = transform.position;
    }

    void SpreadFlowers()
    {
        Vector3 randomPos = spawnOrigin + new Vector3(Random.Range(-itemXSpreadFlower, itemXSpreadFlower), Random.Range(-itemYSpreadFlower, itemYSpreadFlower), Random.Range(-itemZSpreadFlower, itemZSpreadFlower)) + transform.position;
        GameObject cloneFlower = Instantiate(flowerToSpawn, randomPos, Quaternion.identity);

    }

        private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;

            for (int i = 0; i < numFlower; i++)
            {
                SpreadFlowers();
            }

            // Move the trigger to a new position
            transform.position += moveDistance;

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

