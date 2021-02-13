using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool isInCurrentCube;

    private void Awake()
    {
        isInCurrentCube = true;
    }

}
