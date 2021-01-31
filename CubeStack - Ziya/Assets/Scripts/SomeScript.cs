using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;


    private void Update()
    {
        obj2.transform.parent = obj1.transform;
        // make sure its exactly on it
        obj2.transform.localPosition = Vector3.right;
        obj2.transform.localRotation = Quaternion.identity;
    }

}
