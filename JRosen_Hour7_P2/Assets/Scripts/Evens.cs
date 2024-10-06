using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evens : MonoBehaviour
{

    private int evenVal = 22;
    
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(evenVal);

        while (evenVal < 100)
        {
            evenVal += 2;
            Debug.Log(evenVal);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
