using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRefract : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lightmode")
        {
            LightElf le = collision.gameObject.GetComponent<LightElf>();
            le.Refract(-transform.up,0.3f);
        }
    }

}
