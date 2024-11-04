using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{

    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var lookTarget = Target.transform.position;
        lookTarget.y = 0f;

        transform.LookAt(lookTarget, Vector3.up);
    }
}
