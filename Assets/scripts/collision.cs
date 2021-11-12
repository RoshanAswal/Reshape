using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="triangle" || other.gameObject.tag=="circle"  || other.gameObject.tag=="square"){
            FindObjectOfType<GameManager>().over();
            FindObjectOfType<GameManager>().stopSound();
        }
    }
}
