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

        if(other.CompareTag("Pine"))
    {
        Destroy(other.gameObject);

        Debug.Log($"Destroyed: {other.gameObject.name}");
    }

        if(other.CompareTag("Tree"))
    {
        Destroy(other.gameObject);

        Debug.Log($"Destroyed: {other.gameObject.name}");
    }

        if(other.CompareTag("Shrub"))
    {
        Destroy(other.gameObject);

        Debug.Log($"Destroyed: {other.gameObject.name}");
    }

        if(other.CompareTag("Flower"))
    {
        Destroy(other.gameObject);

        Debug.Log($"Destroyed: {other.gameObject.name}");
    }

}

}
