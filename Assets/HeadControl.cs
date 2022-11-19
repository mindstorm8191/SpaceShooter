using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour
{
    int leftCount = 150;
    int rightCount = 42;
    bool mode = false;
    int count;

    public GameObject bodyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        // Instantiate a body segment. Give it the same location & rotation as the head
        GameObject tailObject = (GameObject)Instantiate(bodyPrefab, transform.position, transform.rotation);
        
        // The GameObject goesn't give us access to script information, but we can use GetComponent get it, so we can
        // set variables needed for this to work
        BodyController tail = tailObject.GetComponent<BodyController>();
        tail.followCount = 10;
        tail.uplink = this.gameObject;
    }

    // Update is called once per frame. FixedUpdate is called once per physics tick
    void Update()
    {
        count++;
        if(!mode && count>leftCount) {  // done turning left
            mode = !mode;
            count = 0;
        }
        if(mode && count>rightCount) {  // done turning right
            mode = !mode;
            count = 0;
        }
        float adjust = (mode)?0.3f:-0.3f;
        transform.Rotate(0,adjust,0, Space.Self);
        transform.Translate(0,0,-0.01f,Space.Self);
    }
}
