using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    /* 
    private void OnMouseUpAsButton() 
    {
        Debug.Log("OnMouseUpAsButton!");        
    } 
    */

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown!");        
    }

    void OnMouseDrag() 
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f);
    }
}
