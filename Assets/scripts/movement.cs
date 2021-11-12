using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    float dir;
    public float speed=60f;
    private void Start() {
        rb=GetComponent<Rigidbody>();
    }
    private void Update() {
        dir=Input.acceleration.x*speed;
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,-10.3f,10.3f),transform.position.y,transform.position.z);
    }
    private void FixedUpdate() {
        rb.velocity= new Vector3(dir,0f,0f);
    }
}
