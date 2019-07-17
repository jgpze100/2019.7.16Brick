using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGetsorce : MonoBehaviour
{
    
    GameManager GameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {

        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D c)
   {

        if (c.gameObject.CompareTag("磚塊"))
        {
            GameManager.Gr++;
            
        }
        if (c.gameObject.CompareTag("boss"))
        {
            GameManager.BOSS_HP++;
            if (GameManager.BOSS_HP == 30)
            {
                GameManager.bossisdie = true;
            }

        }
    }
}
