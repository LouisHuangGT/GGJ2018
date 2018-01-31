using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Blackhole : MonoBehaviour {
    
    public GameObject manager;
    bool enterFlag = false;
    Collider player;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}
    IEnumerator wait(float s)
    {
        yield return new WaitForSeconds(s);
        manager.GetComponent<GameManager>().ReStart();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lightmode" )
        {
            enterFlag = true ;
            Vector3 dir = Vector3.Normalize( transform.position - other.transform.position);
            other.gameObject.GetComponent<LightElf>().dir = dir;
            other.gameObject.GetComponent<LightElf>().speed = 15f;
            other.gameObject.GetComponent<LightElf>().LockState();
            float waitTime = Vector3.Distance(transform.position, other.transform.position)/ other.gameObject.GetComponent<LightElf>().speed;
            Debug.Log(waitTime);
            Destroy(other.gameObject,waitTime*0.8f);
            StartCoroutine(wait(waitTime*3.0f));
        }
    }
}
