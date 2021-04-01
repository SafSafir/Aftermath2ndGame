using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    public Text cubeCounterText;

    private void Awake() {
        cubeCounterText.text = "Cube Left: " + GameController.cubeCounter.ToString();
    }

    private void Update() {
        cubeCounterText.text = "Cube Left: " + GameController.cubeCounter.ToString();
    }

}
