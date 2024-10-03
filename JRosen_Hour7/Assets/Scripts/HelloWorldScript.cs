using UnityEngine;

public class HelloWorldScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        print("Hello World");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse clicked!! yAY");
        }

    }

}