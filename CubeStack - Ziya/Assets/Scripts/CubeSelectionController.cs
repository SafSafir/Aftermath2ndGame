using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelectionController : MonoBehaviour
{
    public GameObject[] transparentCubes;
    int currentTransparentCube;


    private void Awake()
    {
        currentTransparentCube = 0;
    }

    private void Start()
    {
        StartCoroutine(SetCubesTransparency());
    }

    IEnumerator SetCubesTransparency()
    {
        while(true)
        {
            transparentCubes[currentTransparentCube].GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(1f);
            transparentCubes[currentTransparentCube].GetComponent<MeshRenderer>().enabled = false;
            currentTransparentCube++;

            if (currentTransparentCube > 4)
            {
                currentTransparentCube = 0;
            }
        }
        
    }

}
