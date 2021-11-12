using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{   
    Transform OriginalPos;
    void Start()
    {
        OriginalPos=this.gameObject.transform;
    }

}
