using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static public float mouseSensitivity;
    public GameObject connectedBody;
    Vector3 centerOfMass;
    private void Awake() {
        mouseSensitivity = 400f;
    }


    void Update()
    {
        RotateCamera();
    }


    void RotateCamera(){
        Vector3 centerOfMass = connectedBody.GetComponent<Rigidbody>().centerOfMass;

       
        //mouse control just for checkig
        //remove afterwards
        transform.RotateAround(centerOfMass, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime + 0.0000001f);
        transform.RotateAround(centerOfMass, Vector3.left, Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime + 0.0000001f);
    }

}
