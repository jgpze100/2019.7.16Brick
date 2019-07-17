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

       

        if (attack == true && GameManager.Instance.GameStatus == GameManager.Status.Boss)
        {
            Timer += Time.deltaTime;
            

        }
        if (Timer >= 5 && GameManager.Instance.GameStatus == GameManager.Status.Boss)
        {
            i = Random.Range(1, 3);
            Timer = 0;
            anim.SetTrigger("Attack" + i);
        }





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("球拍"))
        {
            GameManager.Player_HP++;
            if (GameManager.Player_HP == 5)
            {
                GameManager.isdie = true;
                GameManager.GameStatus = GameManager.Status.dead;
            }
        }
    }
    
}
    
