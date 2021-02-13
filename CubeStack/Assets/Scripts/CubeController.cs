using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject newCube;
    public GameObject connectedBody;

    Cube cube;

    FacesOccupationController facesOccupationController;
  
    private void Awake()
    {
        cube = GetComponent<Cube>();
        facesOccupationController = GetComponent<FacesOccupationController>();

        SetConnectedBody();
    }

    private void Update()
    {
        SpawnNextCube();
        
    }



    /// <summary>
    /// This method is for spawning new cube to the scene with current cube features. 
    /// </summary>
    public void SpawnNextCube()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayCubeParticleAnimation();
            ResetCenterofMass();
            cube.isInCurrentCube = false;
            ClearOccupationStates();
            Generate();
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


    /// <summary>
    /// This method is for instantiate new cube
    /// </summary>
    private void Generate()
    {
        newCube = Instantiate(this.gameObject, facesOccupationController.transparentCube.transform.position, facesOccupationController.transparentCube.transform.rotation);
  
    }


    /// <summary>
    /// This method is for clearing faces occpation states of cube due to generate next cube properly.
    /// </summary>
    private void ClearOccupationStates()
    {
        for (int i = 0; i < facesOccupationController.isOccupied.Length; i++)
        {
            facesOccupationController.isOccupied[i] = false;
        }
    }


    /// <summary>
    /// This method is for connetcting the cube to main body
    /// </summary>
    private void SetConnectedBody()
    {

        this.gameObject.transform.parent = connectedBody.transform;
    }


    /// <summary>
    /// This method is for resetting the center of gravity of connected body due to make it knock over
    /// </summary>
    private void ResetCenterofMass()
    {
        connectedBody.GetComponent<Rigidbody>().useGravity = false;
        connectedBody.GetComponent<Rigidbody>().useGravity = true;
    }
    /// <summary>
    /// This method is for playing particle animation of cube
    /// </summary>
    private void PlayCubeParticleAnimation() 
    {
        if (facesOccupationController.transparentCube.transform.position == facesOccupationController.cubeFaces[0].transform.position)
        {
            facesOccupationController.cubeFaces[0].GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (facesOccupationController.transparentCube.transform.position == facesOccupationController.cubeFaces[1].transform.position)
        {
            facesOccupationController.cubeFaces[1].GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (facesOccupationController.transparentCube.transform.position == facesOccupationController.cubeFaces[2].transform.position)
        {
            facesOccupationController.cubeFaces[2].GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (facesOccupationController.transparentCube.transform.position == facesOccupationController.cubeFaces[3].transform.position)
        {
            facesOccupationController.cubeFaces[3].GetComponentInChildren<ParticleSystem>().Play();
        }
        else if (facesOccupationController.transparentCube.transform.position == facesOccupationController.cubeFaces[4].transform.position)
        {
            facesOccupationController.cubeFaces[4].GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
