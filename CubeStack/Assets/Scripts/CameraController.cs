using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static public float mouseSensitivity;
    static public Vector3 maxHeightPosition;
    public Transform maxHeightTransform;
    private void Awake() {
        maxHeightPosition = maxHeightTransform.position;
        mouseSensitivity = 400f;
    }


    void Update()
    {
        RotateCamera();
    }


    void RotateCamera(){
        transform.LookAt(maxHeightPosition);
        transform.RotateAround(maxHeightPosition, Vector3.up, Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime + 0.0000001f);
        transform.RotateAround(maxHeightPosition, Vector3.left, Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime + 0.0000001f);
    }

}
