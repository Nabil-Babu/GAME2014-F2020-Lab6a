using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public GameObject spawnPoint;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            collider.gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
