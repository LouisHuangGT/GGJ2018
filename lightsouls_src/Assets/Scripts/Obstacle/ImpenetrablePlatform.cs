using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpenetrablePlatform : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lightmode")
        {
            LightElf le = other.gameObject.GetComponent<LightElf>();
            le.ConverttoOriginalState();
        }
    }
}
