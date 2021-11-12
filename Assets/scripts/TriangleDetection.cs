using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="circle" || other.gameObject.tag=="square"){
            Time.timeScale=0f;
            FindObjectOfType<GameManager>().over();
        }
    }
}
