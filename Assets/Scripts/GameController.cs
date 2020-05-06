using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector, System.NonSerialized]
    public static GameController shared;

    [HideInInspector, System.NonSerialized]
    public int score = 0;

    void Awake()
    {
        if(shared == null) 
        {
            shared = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        } 
    }

}
