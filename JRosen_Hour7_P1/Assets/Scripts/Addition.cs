using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        int sum;

        int a;
        int b;
        int c;

        a = 2;
        b = 4;
        c = 8;

        sum = (a + b + c);

        sum++;

        Debug.Log(sum);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
