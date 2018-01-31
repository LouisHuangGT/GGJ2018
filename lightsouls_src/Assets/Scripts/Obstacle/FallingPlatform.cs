using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float fallingTime = 3f;
    float timer = 0f;
    bool isFalling = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer >= fallingTime && isFalling)
        {
            gameObject.transform.parent.GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().isTrigger = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            timer = Time.time;
            isFalling = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
}