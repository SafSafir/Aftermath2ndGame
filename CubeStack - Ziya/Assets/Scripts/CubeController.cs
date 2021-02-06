using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject newCube;

    Cube cube;

    FacesOccupationController facesOccupationController;

    private void Awake()
    {
        cube = GetComponent<Cube>();
        facesOccupationController = GetComponent<FacesOccupationController>();
    }

    private void Update()
    {
        SpawnNextCube();
    }

    private void FixedUpdate()
    {
        
    }


    /// <summary>
    /// This method is for spawning new cube to the scene with current cube features. 
    /// </summary>
    public void SpawnNextCube()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            cube.isInCurrentCube = false;
            newCube = Instantiate(this.gameObject, facesOccupationController.transparentCube.transform.position, Quaternion.identity);
            DisableCurrentCubeFeatures();
        }
    }

    /// <summary>
    /// This method is for to disable the current cube features of previous cubes, due to make them do not act like current cube.
    /// </summary>
    private void DisableCurrentCubeFeatures()
    {
        cube.enabled = false;
        facesOccupationController.enabled = false;
        this.enabled = false;
    }

}
