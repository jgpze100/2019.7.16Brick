using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossdeter : MonoBehaviour
{
    GameManager GameManager;
    
    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
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
