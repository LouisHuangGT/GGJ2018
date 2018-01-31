using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfTrail : MonoBehaviour
{

    public GameObject trail;

    public void AddTrail(Vector3 startPoint, Vector3 endPoint)
    {
        startPoint.z = 0;
        endPoint.z = 0;
        Instantiate(trail, startPoint, Quaternion.identity);
        trail.GetComponent<LineRenderer>().SetPositions(new Vector3[] { startPoint, endPoint });
    }
}