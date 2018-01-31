using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatform : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "lightmode")
        {
            LightElf le = collision.gameObject.GetComponent<LightElf>();
            le.Reflect(-transform.up);
        }
    }
}
