using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    Vector3 calculatedEndPoint;
    private void Awake()
    {
        calculatedEndPoint = GetComponentInChildren<Transform>().position;
        Debug.Log(calculatedEndPoint);
    }
    /// <summary>
    /// This method is for detecting the last end point
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnEndPoint()
    {
        return calculatedEndPoint;
    }
}
