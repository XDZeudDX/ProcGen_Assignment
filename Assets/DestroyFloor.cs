using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyFloor : MonoBehaviour
{

private void OnTriggerEnter(Collider other) 
{
    if(other.CompareTag("Floor"))
    {
        Destroy(other.gameObject);

        Debug.Log($"Destroyed: {other.gameObject.name}");
    }
}

}
