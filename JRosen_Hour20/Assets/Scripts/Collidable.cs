using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public GameManager manager;
    public float moveSpeed = 20f;
    public float timeAmount = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
        //Debug.Log(gameObject.name);
        if (gameObject.name == "Obstacle(Clone)")
        {
            GameObject originalGameObject = gameObject;
            GameObject child = originalGameObject.transform.GetChild(0).gameObject;
            child = child.transform.GetChild(0).gameObject;
            child.transform.Rotate(0, 0, moveSpeed * Time.deltaTime * 360);
            //Debug.Log(child);
        }
        else
        {
            GameObject originalGameObject = gameObject;
            GameObject child = originalGameObject.transform.GetChild(0).gameObject;
            child.transform.Rotate(moveSpeed * Time.deltaTime * 10, 0, moveSpeed * Time.deltaTime * 25);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.AdjustTime(timeAmount);
            Destroy(gameObject);
        }
    }
}
