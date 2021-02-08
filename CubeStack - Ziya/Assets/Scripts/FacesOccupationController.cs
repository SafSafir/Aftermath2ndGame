using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesOccupationController : MonoBehaviour
{


    public GameObject transparentCube;


    public GameObject[] cubeFaces;

    public bool[] isOccupied;

    Cube cube;

    private int cubeFaceCounter;

    private bool isGameStarted;

    private void Awake()
    {

        cube = GetComponent<Cube>();

        cubeFaceCounter = 0;

        isGameStarted = true;
    }

    private void Start()
    {
        if (cube.isInCurrentCube)
        {
          StartCoroutine(RoamAroundUnoccupiedFacesOfCurrentCube());
        }
        
    }


    private void RightSideCollisionDetection()
    {
        if (cube.isInCurrentCube)
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[0].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isOccupied[0] = true;
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
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[1].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isOccupied[1] = true;
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
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[2].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isOccupied[2] = true;
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
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[3].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isOccupied[3] = true;
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
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[4].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                isOccupied[4] = true;
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
            if (!isOccupied[0])
                Gizmos.DrawSphere(cubeFaces[0].transform.position, 0.1f);
            if (!isOccupied[1])
                Gizmos.DrawSphere(cubeFaces[1].transform.position, 0.1f);
            if (!isOccupied[2])
                Gizmos.DrawSphere(cubeFaces[2].transform.position, 0.1f);
            if (!isOccupied[3])
                Gizmos.DrawSphere(cubeFaces[3].transform.position, 0.1f);
            if (!isOccupied[4])
                Gizmos.DrawSphere(cubeFaces[4].transform.position, 0.1f);
        }
        
    }

    /// <summary>
    /// This Method is for removing sphere collider if there is a cube next to this cube
    /// </summary>
    private void RemoveFacesColliderBasedOnFaceOccupation()
    {
        if (cube.isInCurrentCube)
        {
            if (!isOccupied[0])
                RightSideCollisionDetection();
            if (!isOccupied[1])
                BackSideCollisionDetection();
            if (!isOccupied[2])
                LeftSideCollisionDetection();
            if (!isOccupied[3])
                FrontSideCollisionDetection();
            if (!isOccupied[4])
                UpSideCollisionDetection();
        }

    }



    public IEnumerator RoamAroundUnoccupiedFacesOfCurrentCube()
    {

        while (true)
        {
            RemoveFacesColliderBasedOnFaceOccupation();
            if (!cube.isInCurrentCube)
                yield break;
            if (!isOccupied[cubeFaceCounter])
            {

                transparentCube.transform.position = cubeFaces[cubeFaceCounter].transform.position;
                yield return new WaitForSeconds(1);
                Debug.Log("cunta");

            }
            cubeFaceCounter++;
            if (cubeFaceCounter >= cubeFaces.Length)
                cubeFaceCounter = 0;
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
