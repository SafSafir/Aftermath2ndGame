using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static public float mouseSensitivity;

    public Transform maxHeight;

    private void Awake() {
        mouseSensitivity = 400f;
    }


    void Update()
    {
        RotateCamera();
    }


    void RotateCamera(){
        transform.LookAt(maxHeight.position);
        transform.RotateAround(maxHeight.position, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime + 0.0000001f);
    }

}
