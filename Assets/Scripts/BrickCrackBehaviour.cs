﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCrackBehaviour : MonoBehaviour
{
    //Vamos utilizar o conceito de lista/Array para armazenar os sprites
    public Sprite[] spriteList;
    int maxHits;
    protected int hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        hitCounter = 0;
        maxHits = spriteList.Length;
        GetComponent<SpriteRenderer>().sprite = spriteList[hitCounter];
    }

     private void OnCollisionExit2D(Collision2D collision) 
    {
        hitCounter++;
        if (hitCounter == maxHits)
        {
            Destroy (gameObject);
        } 
        else
        {
            GetComponent<SpriteRenderer>().sprite = spriteList[hitCounter];
        } 
    }
}
