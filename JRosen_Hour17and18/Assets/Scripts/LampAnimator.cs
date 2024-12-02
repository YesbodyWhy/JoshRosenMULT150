using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAnimator : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W");
            animator.SetTrigger("Rotate");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");
            animator.SetTrigger("Hover");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("S");
            animator.SetTrigger("Scale");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            print("D");
            animator.SetTrigger("Color");
        }

    }
}
