using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Current Cube")){
            Debug.Log("Ben bir cube'a degiyorum");
            GameController.cubeCounter += 5;
            Destroy(this.gameObject);
        }
    }
}
