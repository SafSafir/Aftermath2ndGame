using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{


    /// <summary>
    /// This method is for detecting the last end point
    /// </summary>
    /// <returns></returns>
    public Vector3 ReturnEndPoint()
    {

        Vector3 CalculatedEndPoint = transform.position + Vector3.up;

        return CalculatedEndPoint;
    }
}
