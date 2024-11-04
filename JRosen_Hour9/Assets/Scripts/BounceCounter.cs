using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{

    private int Count;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerExit is Called Once Another Collider Exits This One
    void OnCollisionExit(Collision other)
    {
        Count += 1;
        print(other.gameObject.name + " has bounced off of " + gameObject.name + Count + " Times!");
    }
}
