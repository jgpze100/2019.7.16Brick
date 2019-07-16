using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightballScore : MonoBehaviour
{
    GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
        
    }


    void Update()
    {
        balldes();
    }

    void balldes()
    {
        if(gameObject.transform.position.y >= 4)
        {
            gameObject.SetActive(false);
        }
        if(gameObject.transform.position.y <= -5)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boss"))
        {
            GameManager.BOSS_HP++;
            GameManager.skill++;
            gameObject.SetActive(false);
            if (GameManager.BOSS_HP == 30)
            {
                GameManager.bossisdie = true;
            }
           
                
        }
    }
}
