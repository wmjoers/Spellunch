using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float rotationForce = 0f;
    public float jumpForce = 0f;

    private AudioSource audioSource;

    public AudioClip jumpSound;
    public AudioClip impactSound;

    // public float speed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();    
        audioSource = gameObject.GetComponent<AudioSource>();
        // transform.position = new Vector3( 0, 0, 0); 
    }

    // Update is called once per frame
    /* void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3( transform.position.x + speed * Time.deltaTime, transform.position.y, 0);         
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3( transform.position.x - speed * Time.deltaTime, transform.position.y, 0);         
        }
    } */

    private void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-rotationForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(rotationForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpSound);
            rb2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.PlayOneShot(impactSound);        
    }
}
