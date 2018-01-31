using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public GameObject spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dead");
        if (other.tag == "lightmode" || other.tag == "Player")
         other.transform.position = spawnPoint.transform.position;
    }
}
