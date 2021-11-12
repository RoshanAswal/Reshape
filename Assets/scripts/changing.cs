using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class changing : MonoBehaviour
{
    private bool cp = true, sp = false, tp = false, starting = true;
    public GameObject CP, SP, TP, parent, Etp, Esp, Ecp;
    public List<GameObject> newList = new List<GameObject>();
    GameObject Tob, Sob, Cob;
    public int c = 0;
    public progress pr;
    void Update()
    {
        if (starting)
        {
            Cob = Instantiate(CP) as GameObject;
            Cob.transform.position = parent.transform.position;
            Destroy(parent);
            starting = false;
            newList.Add(Cob);
        }
        foreach (GameObject obj in newList.ToArray())
        {
            if (!pr.invisible){
                if(obj.tag == "invisibleCube"){
                    Cob = Instantiate(CP) as GameObject;
                    Cob.transform.position = obj.transform.position;
                    newList.Add(Cob);
                    foreach (GameObject i in newList.ToArray())
                    {
                        if (i != Cob)
                        {
                            Destroy(i);
                            newList.Remove(i);
                        }
                    }   
                }else if(obj.tag == "invisibleSphere"){
                    Sob = Instantiate(SP) as GameObject;
                    Sob.transform.position = obj.transform.position;
                    newList.Add(Sob);
                    foreach (GameObject i in newList.ToArray())
                    {
                        if (i != Sob)
                        {
                            Destroy(i);
                            newList.Remove(i);
                        }
                    }
                }else if(obj.tag == "invisibleTriangle"){
                    Tob = Instantiate(TP) as GameObject;
                    Tob.transform.position = obj.transform.position;
                    newList.Add(Tob);
                    foreach (GameObject i in newList.ToArray())
                    {
                        if (i != Tob)
                        {
                            Destroy(i);
                            newList.Remove(i);
                        }
                    }
                }
            }
        }
        if (pr.invisible == false)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    change(CP, SP, TP);
                }
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    change(Ecp, Esp, Etp);
                }
            }
        }
        if (c == 1)
        {
            tp = true;
            cp = false;
            sp = false;
        }
        else if (c == 2)
        {
            tp = false;
            cp = true;
            sp = false;
        }
        else
        {
            tp = false;
            cp = false;
            sp = true;
            c = 0;
        }
    }
    void change(GameObject cube, GameObject sphere, GameObject triangle)
    {
        if (sp)
        {
            c++;
            Sob = Instantiate(sphere) as GameObject;
            Sob.transform.position = Cob.transform.position;
            newList.Add(Sob);
            foreach (GameObject i in newList.ToArray())
            {
                if (i != Sob)
                {
                    Destroy(i);
                    newList.Remove(i);
                }
            }
        }
        else if (tp)
        {
            c++;
            Tob = Instantiate(triangle) as GameObject;
            Tob.transform.position = Sob.transform.position;
            newList.Add(Tob);
            foreach (GameObject i in newList.ToArray())
            {
                if (i != Tob)
                {
                    Destroy(i);
                    newList.Remove(i);
                }
            }
        }
        else if (cp)
        {
            c++;
            Cob = Instantiate(cube) as GameObject;
            Cob.transform.position = Tob.transform.position;
            newList.Add(Cob);
            foreach (GameObject i in newList.ToArray())
            {
                if (i != Cob)
                {
                    Destroy(i);
                    newList.Remove(i);
                }
            }
        }
    }
}
        




