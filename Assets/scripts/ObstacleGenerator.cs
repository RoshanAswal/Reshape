using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] floating;
    public Transform player;
    private List<GameObject> newObstacles=new List<GameObject>();
    private List<GameObject> newFloating=new List<GameObject>();
    float speedlimit=0;
    float zDir=0f;
    float speed=-62f;
    public progress pr;
    Vector3 StartingDir=new Vector3(0.2f,0.85f,5f);
    private void Awake() {
        foreach (GameObject obj in obstacles)
        {   if(obj.tag=="cubeBox"){
                GameObject ob=Instantiate(obj,new Vector3(0f,0f,150f+zDir),Quaternion.Euler(90f,0f,0f)) as GameObject;
                ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
                newObstacles.Add(ob);
            }
            else{
                GameObject ob=Instantiate(obj,new Vector3(7f,0f,150f+zDir),Quaternion.Euler(90f,0f,0f)) as GameObject;
                ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
                newObstacles.Add(ob);
            }
            zDir+=150f;
        }
        for(int i=0;i<3;i++){
            int x=Random.Range(0,6);
            GameObject ob=Instantiate(floating[x],new Vector3(Random.Range(-30,-150f),Random.Range(18f,-21f),Random.Range(220f,350f)),Quaternion.Euler(90f,0f,0f));
            GameObject ob1=Instantiate(floating[x],new Vector3(Random.Range(30,150f),Random.Range(18f,-21f),Random.Range(350f,480f)),Quaternion.Euler(90f,0f,0f));
            ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
            ob1.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
            newFloating.Add(ob);
            newFloating.Add(ob1);
        }
    }
    private void Update() {
        speedlimit+=1f*Time.deltaTime;
        if(speedlimit>10 && speed>-85){
            speed-=2.5f;
            speedlimit=0;
        }

        foreach (GameObject obj in newObstacles.ToArray())
        {   
            if(obj.transform.position.z<-150){
                Generate();
                DestroyObstacle(obj);
            }
            
        }
        foreach (GameObject i in newFloating.ToArray())
        {
            if(i.transform.position.z<-50){
                DestroyFloating(i);
                GenerateFloating();
            }
        }
        foreach (GameObject obj in newObstacles.ToArray())
        {
            Collider[] colObject=Physics.OverlapSphere(obj.transform.position,30f);
            foreach (Collider col in colObject)
            {
                if( col.gameObject!=obj && (col.gameObject.tag=="cubeBox" || col.gameObject.tag=="triangleBox" || col.gameObject.tag=="sphereBox"))
                    DestroyObstacle(obj);
            }
        }
    }

    void DestroyFloating(GameObject ob){
        newFloating.Remove(ob);
        Destroy(ob);                
    }
    private void GenerateFloating() {
        int x=Random.Range(0,6);
        float[] r={Random.Range(-30f,-150f),Random.Range(30f,150f)};
        int pos=Random.Range(0,r.Length);
        GameObject ob=Instantiate(floating[x],new Vector3(r[pos],Random.Range(18f,-21f),Random.Range(220f,350f)),Quaternion.Euler(90f,0f,0f));
        ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
        newFloating.Add(ob);
    }
    private void Generate() {
        int x=Random.Range(0,9);
        if(obstacles[x].tag=="cubeBox"){
            GameObject ob;
            ob=Instantiate(obstacles[x],new Vector3(0f,-0.05f,1350f),Quaternion.Euler(90f,0f,0f));
            ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
            newObstacles.Add(ob);
        }
        else{
            GameObject ob;
            ob=Instantiate(obstacles[x],new Vector3(7f,-0.05f,1350f),Quaternion.Euler(90f,0f,0f));
            ob.GetComponent<Rigidbody>().velocity= new Vector3(0f,0f,speed);
            newObstacles.Add(ob);
        }
    }
    void DestroyObstacle(GameObject ob){
        newObstacles.Remove(ob);
        Destroy(ob);        
    }   
}
