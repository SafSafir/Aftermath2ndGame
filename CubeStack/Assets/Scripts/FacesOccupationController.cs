using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesOccupationController : MonoBehaviour
{
    

    public GameObject transparentCube;


    public GameObject[] cubeFaces;

    public bool[] isOccupied;
    
    private int cubeFaceCounter;

    private bool isGameStarted;

    private void Awake()
    {

        cubeFaceCounter = 0;

        isGameStarted = true;
    }

    private void Start()
    {
        
        if (this.gameObject.CompareTag("Current Cube"))
        {
          StartCoroutine(RoamAroundUnoccupiedFacesOfCurrentCube());
        }
        
    }


    private void RightSideCollisionDetection()
    {
        if (this.gameObject.CompareTag("Current Cube"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[0].transform.position, 0.1f);


            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].gameObject.tag == "Checkpoint"){
                    break;
                }
                isOccupied[0] = true;
                i++;
            }
        }
        
    }

    private void BackSideCollisionDetection()
    {
        if (this.gameObject.CompareTag("Current Cube"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[1].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].gameObject.tag == "Checkpoint"){
                    break;
                }
                isOccupied[1] = true;
                i++;
            }
        }
       
    }


    private void LeftSideCollisionDetection()
    {
        if (this.gameObject.CompareTag("Current Cube"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[2].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].gameObject.tag == "Checkpoint"){
                    break;
                }
                isOccupied[2] = true;
                i++;
            }
        }
    }


    private void FrontSideCollisionDetection()
    {
        if (this.gameObject.CompareTag("Current Cube"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[3].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].gameObject.tag == "Checkpoint"){
                    break;
                }
                isOccupied[3] = true;
                i++;
            }
        }
    }


    private void UpSideCollisionDetection()
    {
        if (this.gameObject.CompareTag("Current Cube"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(cubeFaces[4].transform.position, 0.1f);

            int i = 0;
            //Check when there is a new collider coming into contact with the box
            while (i < hitColliders.Length)
            {
                if(hitColliders[i].gameObject.tag == "Checkpoint"){
                    break;
                }
                isOccupied[4] = true;
                i++;
            }
        }
    }




    /// <summary>
    /// This method is for drawing the unoccupied cube faces in scene mode for current cube.
    /// </summary>
    private void DrawGizmosOfCubeFaces()
    {
        if (this.gameObject.CompareTag("Current Cube"))
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
        if (this.gameObject.CompareTag("Current Cube"))
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
            if (!this.gameObject.CompareTag("Current Cube"))
                yield break;
            if (!isOccupied[cubeFaceCounter])
            {

                transparentCube.transform.position = cubeFaces[cubeFaceCounter].transform.position;
                transparentCube.transform.rotation = this.gameObject.transform.rotation;
                yield return new WaitForSeconds(0.75f);

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
