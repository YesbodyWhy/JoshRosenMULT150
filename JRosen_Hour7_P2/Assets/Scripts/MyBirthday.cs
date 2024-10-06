using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBirthday : MonoBehaviour
{

    private int MyBirthdayValue = 18;

    // Start is called before the first frame update
    void Start()
    {

    for (int Count = 1; Count <= 31; Count ++)
        {
            if (Count == MyBirthdayValue)
            {
                Debug.Log("It's my birthday!");
            }
            else
            {
                Debug.Log(Count);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
