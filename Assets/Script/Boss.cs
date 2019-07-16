using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float Timer;
    public bool attack;
    GameManager GameManager;
    Animator anim;
    public int i;
   
    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        
        attack = false;

    }

    
    void Update()
    {
        if (GameManager.BOSS_Score >= 156 && GameManager.Instance.GameStatus == GameManager.Status.Boss)
        {
            anim.SetBool("angry", true);
            GameManager.BOSS_Score = 0;
            anim.SetBool("Reach", true);
            attack = true;


        }

       

        if (attack == true)
        {
            Timer += Time.deltaTime;
           
        }

        if (Timer >= 5)
        {
            i = Random.Range(1, 3);
            Timer = 0;
            anim.SetTrigger("Attack" + i);
        }





        /* if (Attack == true)
         {
             Invoke("等待執行", 3);

             if (Atk == 1)
             {
                 anim.SetBool("attack1", true);
                 Attack = false;
             }
             if (Atk == 2)
             {
                 anim.SetBool("attack2", true);
                 Attack = false;
             }*/




        /*if( Atk == 0)
        {
            anim.SetBool("attack_1", true); 
            Attack = false;
        }
        else
        {
            anim.SetBool("attack_1", false);
        }
        if()
        {
            anim.SetBool("attack_2", true);
        }
        else
        {
            anim.SetBool("attack_2", false);
            Attack = false;
        }*/

    }
        

   
    }
    
