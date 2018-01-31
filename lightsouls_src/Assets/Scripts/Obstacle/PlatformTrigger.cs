using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {

    public GameObject platform;
    public LightElf player;
    public Vector2 dir;
    private void Update()
    {
        if (platform == null)
        {
            Debug.Log(gameObject.transform.parent.name);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        platform.GetComponent<BoxCollider>().isTrigger = true;
    }
}
