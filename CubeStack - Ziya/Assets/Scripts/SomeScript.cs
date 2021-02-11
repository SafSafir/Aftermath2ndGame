using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;



    private void Start()
    {
        obj1.transform.parent = obj2.transform;
    }
    private void Update()
    {
        

    }
}
