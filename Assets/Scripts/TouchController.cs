using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject mouseDot; 

    public List<GameObject> touchDots = new List<GameObject>();
    private Stack<GameObject> availableTouchDots = new Stack<GameObject>();
    private Dictionary<int, GameObject> activeTouchObjects = new Dictionary<int, GameObject>();

    private GameObject selectedObject;

    void Start()
    {
        foreach(var touchObj in touchDots)
        {
            availableTouchDots.Push(touchObj);
        }
    }

    void Update()
    {
        HandleMouseInput();
        HandleTouchInput();
        //HandleObjectSelection();
    }
    
    private void HandleObjectSelection()
    {
        if (selectedObject == null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hitObject = Physics2D.Raycast(mouseWorldPos, Vector3.forward);
                if(hitObject)
                {
                    selectedObject = hitObject.transform.gameObject;
                }
            }
        }
        else 
        {
            if(Input.GetMouseButton(0))
            {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                selectedObject.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f);
            }    
            else 
            {
                selectedObject = null;
            }
        }
    }

    private void HandleTouchInput()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began && availableTouchDots.Count > 0)
            {
                var touchObj = availableTouchDots.Pop();
                activeTouchObjects.Add(touch.fingerId, touchObj);
                var touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchObj.transform.position = new Vector3(touchWorldPos.x, touchWorldPos.y, 0f);
            }
            else if(touch.phase == TouchPhase.Ended && activeTouchObjects.ContainsKey(touch.fingerId))
            {
                var touchObj = activeTouchObjects[touch.fingerId];
                activeTouchObjects.Remove(touch.fingerId);
                availableTouchDots.Push(touchObj);
            }
            else if(touch.phase == TouchPhase.Moved && activeTouchObjects.ContainsKey(touch.fingerId))
            {
                var touchObj = activeTouchObjects[touch.fingerId];
                var touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchObj.transform.position = new Vector3(touchWorldPos.x, touchWorldPos.y, 0f);
            }
        }
    }

    private void HandleMouseInput()
    {
        if(Input.GetMouseButton(0))
        {
            var mouseScreenPos = Input.mousePosition;
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseDot.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f);
        }
    }
}
