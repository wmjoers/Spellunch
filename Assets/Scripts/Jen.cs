using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jen : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int sprtiteIndex = 0;
    private float animationTimer = 0f;

    public List<Sprite> sprites = new List<Sprite>();
    public float animationSpeed = 0f;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        animationTimer  = animationSpeed;
    }

    void Update()
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0f) 
        {
            sprtiteIndex = (sprtiteIndex + 1) % sprites.Count;
            spriteRenderer.sprite = sprites[sprtiteIndex];
            animationTimer += animationSpeed;
        }
    }
}
