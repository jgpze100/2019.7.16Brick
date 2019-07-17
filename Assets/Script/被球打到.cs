﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 被球打到 : MonoBehaviour
{
    bool BP;
    int HP = 0;
    GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
        BP = true;
       
    }


    void Update()
    {
        //一鍵通關
        if(Input.GetKey(KeyCode.H))
        {
            gameObject.SetActive(false);
            GameManager.Gr += 3;
            GameManager.boss = true;
            
        }
        if (GameManager.Gr >= 156 && BP == true)
        {
            GameManager.boss = true;
            
            BP = false;
        }
    }



    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("球"))
        {
            HP += 1 ;
            
            if (HP == 3)
            {
                this.gameObject.SetActive(false);
                
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.CompareTag("sword"))
        {
            HP += 1;

            if (HP == 3)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
