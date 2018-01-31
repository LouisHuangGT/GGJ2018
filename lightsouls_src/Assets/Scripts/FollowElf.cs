using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowElf : MonoBehaviour
{

    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (target)
            transform.position = target.transform.position;
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
}