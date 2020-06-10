using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeTest : MonoBehaviour
{
    public float aspectRatio;
    public Vector3 maxCam;

    // Start is called before the first frame update
    void Start()
    {
        float targetWidth = 6.66f;
        float camWidth = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)).x - transform.position.x;
        float prc = targetWidth / camWidth;
        Camera.main.orthographicSize = 5f * prc;
    }

    // Update is called once per frame
    void Update()
    {
        aspectRatio = Camera.main.aspect;
        maxCam = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)) - transform.position;
    }
}
