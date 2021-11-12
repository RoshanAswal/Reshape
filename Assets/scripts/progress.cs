using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class progress : MonoBehaviour
{
    public GameObject time;
    public Slider slide;
    float fillSpeed=0.05f;
    float targetProgress=0f;
    public GameObject btn;
    public bool invisible=false;
    public float timetext=8;
    private void Start() {
        increment(1f);
    }
    void Update()
    {        
        if(slide.value<targetProgress && !invisible){
            slide.value+=fillSpeed*Time.deltaTime;
        }
        if(slide.value>=1f){
            btn.SetActive(true);
            slide.value=0.9f;
        }
        if( timetext>0 && invisible)
        {  
            timetext -= Time.deltaTime;
            time.GetComponent<Text>().text=timetext.ToString("0");
        }else{
            time.SetActive(false);
            timetext=8;
        }
    }
    void increment(float newProgress){
        targetProgress+=slide.value+newProgress;
    }
    public void invisibleFunction(){
        invisible=true;
        time.SetActive(true);
        btn.SetActive(false);
        Invoke("makingVisible",8f);
    }
    void makingVisible(){
        slide.enabled=true;
        slide.value=0;
        invisible=false;
    }

}
