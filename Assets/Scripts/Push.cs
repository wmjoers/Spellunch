using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
        }        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
        }        
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2d.AddTorque(5f,ForceMode2D.Impulse);
        }        
    }

}
