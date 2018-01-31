using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float width;

    // Use this for initialization
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        width = lineRenderer.widthMultiplier;
    }

    public void SetStartPoint(Vector3 position)
    {
        Debug.Log(lineRenderer.positionCount);
        lineRenderer.SetPosition(0, position);
    }

    public void SetEndPoint(Vector3 position)
    {
        lineRenderer.SetPosition(1, position);
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void SetWidthRatio(float ratio)
    {
        lineRenderer.widthMultiplier = width * ratio;
    }
}