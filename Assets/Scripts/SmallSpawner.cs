using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpawner : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public int x;
    


    void Start()
    {
        NewTetrominoe();

    }

    public void NewTetrominoe()
    {
        x = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[x];
    }
}
