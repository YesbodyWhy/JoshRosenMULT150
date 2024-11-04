using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{

    private float distance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Xinput = Input.GetAxis("Horizontal");
        float Zinput = Input.GetAxis("Vertical");

        float scale = 10f;

        distance = (float) Math.Abs(new Vector3(transform.position.x, 0f, transform.position.z).magnitude);
        Debug.Log(distance);

        Vector3 newvelocity = new Vector3(Xinput * scale, 0f, Zinput * scale);
        float ybounce = newvelocity.magnitude/(scale) * (float) Math.Abs(Math.Sin(distance));
        

        transform.position = new Vector3(transform.position.x, ybounce, transform.position.z);
        GetComponent<Rigidbody>().velocity = newvelocity;

    }
}
