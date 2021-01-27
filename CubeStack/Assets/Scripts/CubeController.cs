using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    enum CubeFieldStates
    {
        UpField,
        RightField,
        LeftField,
        FrontField,
        BackField
    }

    public GameObject cubePrefab;
    


    public Vector3 lastEndPoint;



    private void Update()
    {
        CreateCubeOnClick();
        //Debug.Log(lastEndPoint);
    }


    /// <summary>
    /// This method is for creating new cubes when pressing the mouse button
    /// </summary>
    private void CreateCubeOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentCube = Instantiate(cubePrefab, lastEndPoint, Quaternion.identity);
            Cube cubeScript = currentCube.GetComponent<Cube>();
            lastEndPoint = cubeScript.ReturnEndPoint();
        }
    }



}
