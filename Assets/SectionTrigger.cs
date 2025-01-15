using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{

    public GameObject floorSection; // Prefab for the floor to spawn
    public Vector3 moveDistance = new Vector3(20, 0, 0); // Distance to move the trigger
    

    private void OnTriggerEnter(Collider other)
    {
        var offset = new Vector3(8,0,0);
        // Check if the player collided with a trigger tagged "TriggerPosX"
        if (other.CompareTag("TriggerPosX"))
        {
            // Spawn a new floor at the trigger's current position
            Instantiate(floorSection, other.transform.position + offset, Quaternion.identity);

            // Move the trigger box 20 units in the positive X direction
            other.transform.position += moveDistance;

            // Optional: Debug logs to confirm actions
            Debug.Log("New floor spawned and trigger moved!");
        }

        
    }
}
