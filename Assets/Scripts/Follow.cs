using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Camera arCamera;

    void Start() {
       arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();

    }
    // Update is called once per frame
    void Update()
    {   
        if(Input.touchCount > 0)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 0.3f;
            this.transform.position = arCamera.ScreenToWorldPoint(temp);
        }
       
    }
}
