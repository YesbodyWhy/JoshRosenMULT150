using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private float health;
    private float poisonDamage;

    // Start is called before the first frame update
    void Start()
    {

        health = 1004.0f;
        poisonDamage = 125.5f;

        Debug.Log("Health = " + health);

        while (health > 0) //I just used a loop like step 14 indicated, but there WAS a version of this where health -= poisonDamage was copy pasted a million times
        {
            health -= poisonDamage;
            Debug.Log("Health = " + health);
        }

        if (health <= 0)
        {
            Debug.Log("Player has been unalived!");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}