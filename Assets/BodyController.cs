using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    //public GameObject bodyPrefab
    public GameObject uplink;
    public int followCount;
    // Start is called before the first frame update
    void Start()
    {
        if(followCount>1) {
            GameObject tailObject = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);

            // Get the specific object from the GameObject
            BodyController tail = tailObject.GetComponent<BodyController>();
            tail.followCount = followCount-1;
            tail.uplink = this.gameObject;
        }
        Debug.Log(followCount);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(uplink.transform.position.x);
        transform.LookAt(uplink.transform);
        float distance = Vector3.Distance(gameObject.transform.position, uplink.gameObject.transform.position);
        if(distance > 0.7f) {
            transform.Translate(0,0,distance-0.7f);
        }
    }
}
