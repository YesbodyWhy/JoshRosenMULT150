using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    float mouseX;
    float mouseY;
    private GameObject MainCamera;
    private GameObject CameraGuy;
    public GameObject CameraSubject;

    // Start is called before the first frame update
    void Start()
    {

        MainCamera = GameObject.Find("Main Camera");
        //Debug.Log(MainCamera);
        //Debug.Log(CameraSubject);
        CameraGuy = GameObject.Find("CameraGuy");
        //Debug.Log(CameraGuy);

        Cursor.lockState = CursorLockMode.Confined;

    }

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (mouseX != 0)
        {
            MainCamera.transform.Translate(mouseX, mouseY, 0f);
            //MainCamera.transform.LookAt(CameraSubject.transform, new Vector3(0f,1f,0f));

        }

    }
}
