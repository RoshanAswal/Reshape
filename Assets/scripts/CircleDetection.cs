using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="square" || other.gameObject.tag=="triangle"){
            Time.timeScale=0f;
            FindObjectOfType<GameManager>().over();
        }
    }
}
