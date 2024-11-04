using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    void CheckForRaycastHit()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            print(hit.collider.gameObject.name + " has been destroyed!");
            Destroy(hit.collider.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Mouse X");
        float dirY = Input.GetAxis("Mouse Y");
        //vvv This is opposite since we rotate about those Axes
        transform.Rotate(-dirY, dirX, 0);
        CheckForRaycastHit();
    }
}
