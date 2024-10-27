using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private int healthpoints = 3992;

    // Start is called before the first frame update
    void Start()
    {
        UsePotion(healthpoints);
        UsePotion(healthpoints);
        UsePotion(healthpoints);
        UsePotion(healthpoints);
        Debug.Log("healthpoints = " + healthpoints);
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    int UsePotion(int health)
    {
        health += 400;
        Debug.Log("400 health added");
        return health;
    }

}
