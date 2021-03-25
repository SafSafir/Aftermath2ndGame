using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyofMaterialsController : MonoBehaviour
{


    public Material transparentCubeMaterial;
    public Material cubeMaterial;
    
    private void Awake() {
        //transparentCubeMaterial.SetColor("_TransparentColor", Color.red);
        //transparentCubeMaterial.SetColor("_CubeHighColor", new Color(0, 255, 0, 255));
        //transparentCubeMaterial.SetColor("_CubeLowColor", new Color(140, 31, 31, 255));
    }

}
