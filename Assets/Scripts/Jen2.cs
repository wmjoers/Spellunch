using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jen2 : MonoBehaviour
{
    private Animator animator;

    void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Running", false);
        }
    }
}
