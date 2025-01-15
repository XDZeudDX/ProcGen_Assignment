using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrubToSpawn : MonoBehaviour
{

    public GameObject shrubToSpawn;


    public int numShrub = 1;
    

    public float itemXSpreadShrub = 10;
    public float itemYSpreadShrub = 0;
    public float itemZSpreadShrub = 10;

    private bool hasSpawned = false;

    private Vector3 spawnOrigin;


    // Start is called before the first frame update
    void Start()
    {
        spawnOrigin = transform.position;
    }

    void SpreadShrub()
    {
        Vector3 randomPos = spawnOrigin + new Vector3(Random.Range(-itemXSpreadShrub, itemXSpreadShrub), Random.Range(-itemYSpreadShrub, itemYSpreadShrub), Random.Range(-itemZSpreadShrub, itemZSpreadShrub)) + transform.position;
        GameObject cloneShrub = Instantiate(shrubToSpawn, randomPos, Quaternion.identity);

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;
            
            for (int i = 0; i < numShrub; i++)
            {
                SpreadShrub();
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
    
    

