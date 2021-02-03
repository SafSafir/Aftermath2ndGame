using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesOccupationController : MonoBehaviour
{
    [Header("Cube Faces")]
    public GameObject cubeRight;
    public GameObject cubeBack;
    public GameObject cubeLeft;
    public GameObject cubeFront;
    public GameObject cubeUp;

    [Header("Faces of Cube Occupation State")]
    public bool isRightOccupied = false;
    public bool isBackOccupied = false;
    public bool isLeftOccupied = false;
    public bool isFrontOccupied = false;
    public bool isUpOccupied = false;


    Cube cube;


    private bool isGameStarted;

    private void Awake()
    {

        cube = GetComponent<Cube>();

        isGameStarted = true;
    }


    private void FixedUpdate()
    {
        RemoveFacesColliderBasedOnFaceOccupation();
    }

    private void RightSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeRight.transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isRightOccupied = true;
                //Output all of the collider names
                Debug.Log("Hit Right: " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }
        
    }

    private void BackSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeBack.transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isBackOccupied = true;
                //Output all of the collider names
                Debug.Log("Hit Back: " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }
       
    }


    private void LeftSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeLeft.transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isLeftOccupied = true;
                //Output all of the collider names
                Debug.Log("Hit Left: " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }
    }


    private void FrontSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFront.transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isFrontOccupied = true;
                //Output all of the collider names
                Debug.Log("Hit Front: " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }
    }


    private void UpSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeUp.transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isUpOccupied = true;
                //Output all of the collider names
                Debug.Log("Hit Up: " + hitColliders[i].name + i);
                //Increase the number of Colliders in the array
                i++;
            }
        }
    }




    /// <summary>
    /// This method is for drawing the unoccupied cube faces in scene mode for current cube.
    /// </summary>
    private void DrawGizmosOfCubeFaces()
    {
        if (cube.isInCurrentCube)
        {
            if (!isRightOccupied)
                Gizmos.DrawSphere(cubeRight.transform.position, 0.1f);
            if (!isBackOccupied)
                Gizmos.DrawSphere(cubeBack.transform.position, 0.1f);
            if (!isLeftOccupied)
                Gizmos.DrawSphere(cubeLeft.transform.position, 0.1f);
            if (!isFrontOccupied)
                Gizmos.DrawSphere(cubeFront.transform.position, 0.1f);
            if (!isUpOccupied)
                Gizmos.DrawSphere(cubeUp.transform.position, 0.1f);
        }
        
    }

    /// <summary>
    /// This Method is for removing sphere collider if there is a cube next to this cube
    /// </summary>
    private void RemoveFacesColliderBasedOnFaceOccupation()
    {
        if (cube.isInCurrentCube)
        {
            if (!isRightOccupied)
                RightSideCollisionDetection();
            if (!isBackOccupied)
                BackSideCollisionDetection();
            if (!isLeftOccupied)
                LeftSideCollisionDetection();
            if (!isFrontOccupied)
                FrontSideCollisionDetection();
            if (!isUpOccupied)
                UpSideCollisionDetection();
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (isGameStarted)
        {
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            DrawGizmosOfCubeFaces();
        }
    }
}
