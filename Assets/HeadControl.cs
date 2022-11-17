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
        GameObject tailObject = (GameObject)Instantiate(bodyPrefab, transform.position, transform.rotation);
        
        // Get the specific object from the GameObject
        BodyController tail = tailObject.GetComponent<BodyController>();
        tail.followCount = 10;
        tail.uplink = this.gameObject;
    }

    // Update is called once per frame. FixedUpdate is called once per physics tick
    void Update()
    {
        count++;
        if(!mode && count>leftCount) {
            mode = !mode;
            count = 0;
        }
        if(mode && count>rightCount) {
            mode = !mode;
            count = 0;
        }
        float adjust = (mode)?0.3f:-0.3f;
        transform.Rotate(0,adjust,0, Space.Self);
        transform.Translate(0,0,-0.01f,Space.Self);
    }
}
