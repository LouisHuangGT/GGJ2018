using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractionPlatform : MonoBehaviour {
    public float eta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lightmode")
        {
            LightElf le = other.gameObject.GetComponent<LightElf>();
            le.Refract(-transform.up, eta);
        }
    }
}
