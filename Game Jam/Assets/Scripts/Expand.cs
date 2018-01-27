using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour {

    [HideInInspector]
    public GameObject[] WaveSource;
    public float expanding_Speed = 1;

    private bool hold_flag = false;
    private GameObject Picked_Object;
    private Vector3 lastHitPoint;
    public bool start_expanding = false;
	// Use this for initialization
	void Start () {

        WaveSource = GameObject.FindGameObjectsWithTag("Wave");
        Debug.Log(WaveSource.Length);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (start_expanding)
        {
            float delta = Time.deltaTime * expanding_Speed;
            for (int i = 0; i < WaveSource.Length; i++)
            {
                WaveSource[i].transform.localScale = new Vector3(WaveSource[i].transform.localScale.x + delta,
                                                                    WaveSource[i].transform.localScale.y, WaveSource[i].transform.localScale.z + delta);
            }
 
        }
        
        if(Input.GetMouseButtonDown(0))
         {
             Debug.Log("Mouse Button Down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo))
            {
                Debug.DrawLine(ray.origin,hitInfo.point);

                GameObject gameObj = hitInfo.collider.gameObject;

                Debug.Log("click object name is " + gameObj.name);

                if(gameObj.tag == "Wave")
                {
                    hold_flag = true;
                    Picked_Object = gameObj;
                    lastHitPoint = hitInfo.point;


                    Debug.Log("pick up");
                }
             }
         }

        if (hold_flag)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo,Mathf.Infinity,LayerMask.GetMask("Wave")))
                {
                    // Debug.DrawLine(ray.origin,hitInfo.point);

                    GameObject gameObj = hitInfo.collider.gameObject;

                    Debug.Log("click object name is " + gameObj.name);
                    
                    Vector3 delta_position =  hitInfo.point - lastHitPoint;

                    Picked_Object.transform.Translate(new Vector3(delta_position.x, 0, delta_position.z));
                    lastHitPoint = hitInfo.point;

                }
 
            }

            if (Input.GetMouseButtonUp(0))
            {
                Picked_Object = null;
                hold_flag = false;
 
            }
 
        }
		
	}
}
