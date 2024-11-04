using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnTriggerEnter is Called Once Another Collider Enters This One
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name + " has entered the cube");
    }

    // OnTriggerStay is Called While Another Collider Stays Inside This One
    void OnTriggerStay(Collider other)
    {
        print(other.gameObject.name + " is still in the cube");
    }

    // OnTriggerExit is Called Once Another Collider Exits This One
    void OnTriggerExit(Collider other)
    {
        print(other.gameObject.name + " has left the cube");
    }
}
