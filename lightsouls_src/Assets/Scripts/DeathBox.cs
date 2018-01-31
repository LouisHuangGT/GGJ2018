using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {

    public GameManager GM;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "Player" || other.tag == "lightmode")
        {

            GM.Death();

           // UICanvas.SetActive(true);
         //   Debug.Log("Dead");
        }
    }


}
