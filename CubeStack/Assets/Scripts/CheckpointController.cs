using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    private void Update() {
        
    }

    // devam edilecek yer
    public void GiveMoreCubeOnCheckpoint(){
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, 0.1f);
        if(hitColliders[0].gameObject.CompareTag("Cube")){
            GameController.cubeCounter += 5;
        }
            
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(this.gameObject.transform.position, 0.1f);
    }
}
