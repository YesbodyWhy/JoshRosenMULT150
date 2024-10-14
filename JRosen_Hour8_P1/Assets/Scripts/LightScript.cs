using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    public GameObject Light;
    Light LightComponent;
    public bool toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        
        Light = GameObject.FindWithTag("Light");
        LightComponent = Light.GetComponent<Light> ();
        LightComponent.enabled = toggle;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            toggle = !toggle;
            LightComponent.enabled = toggle;
        }

    }
}
