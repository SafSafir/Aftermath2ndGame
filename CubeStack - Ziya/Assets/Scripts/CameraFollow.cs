using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform target;
    public Vector3 Offset;
    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;


    private void Awake()
    {
    }

    private void Start()
    {
        Offset = transform.position - target.position;
        
    }

    private void Update()
    {
        // update position
        Vector3 desiredPosition = target.position + Offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // update rotation
        transform.LookAt(target);
    }


    private void ChangeTargetTransform()
    {

    }
}
