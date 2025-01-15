using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinesToSpawn : MonoBehaviour
{

    public GameObject pineToSpawn;

    public int numPines = 1;
    

    public float itemXSpreadPines = 10;
    public float itemYSpreadPines = 0;
    public float itemZSpreadPines = 10;

    private bool hasSpawned = false;

    private Vector3 spawnOrigin;


    // Start is called before the first frame update
    void Start()
    {
        spawnOrigin = transform.position;
    }

    void SpreadPines()
    {
        Vector3 randomPos = spawnOrigin + new Vector3(Random.Range(-itemXSpreadPines, itemXSpreadPines), itemYSpreadPines, Random.Range(-itemZSpreadPines, itemZSpreadPines)) + transform.position;
        GameObject clonePine = Instantiate(pineToSpawn, randomPos, Quaternion.identity);

    }

        private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;
            
            for (int i = 0; i < numPines; i++)
            {
                SpreadPines();
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
    
    

