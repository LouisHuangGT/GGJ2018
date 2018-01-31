using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAnime : MonoBehaviour {
    public GameObject main_camera;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void startAnime()
    {
        main_camera.GetComponent<Animator>().SetTrigger("StartAnimation");
        canvas.SetActive(false);
 
    }
}
