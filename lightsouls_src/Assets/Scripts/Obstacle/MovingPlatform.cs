using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float movingSpeed = 1.5f;
    public float screenWidth = 14f;
    public float interval = 2f;
    private bool movingFlag = true; //false for moving left
    private GameObject attactedObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= screenWidth / 2 - transform.localScale.x - interval)
            movingFlag = false;
        if (transform.position.x <= -screenWidth / 2 + transform.localScale.x + interval)
            movingFlag = true;
        if (movingFlag)
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * movingSpeed);
            if (attactedObject != null)
                attactedObject.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * movingSpeed);

        }

        else
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);
            if (attactedObject != null)
                attactedObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
            attactedObject = collision.gameObject;

    }
    void OnTriggerExit(Collider collision)
    {
        if (attactedObject != null)
            attactedObject = null;
    }

    



}
