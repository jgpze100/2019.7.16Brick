using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 球移動 : MonoBehaviour
{
    
    
    public GameObject Player;
    public float speed;
    public bool go;
    float HF;
    int start;
    GameManager GameManager;
    Rigidbody2D rig;







    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.zero;
        go = false;

    }

    void Update()
    {
        if(GameManager.Instance.GameStatus == GameManager.Status.Start)
        {
            go = true;
        }
        if (Input.GetKey(KeyCode.C) && GameManager.Instance.GameStatus == GameManager.Status.Play && go == true)
        {
            start = Random.Range(0, 3);
            switch (start)
            {
                case 0:

                    rig.velocity = Vector2.up * speed;

                    break;
                case 1:

                    rig.velocity = new Vector2(0.6f,-0.6f) * speed;
                    
                    break;
                case 2:
                    rig.velocity = new Vector2(-0.6f, 0.6f) * speed;
                    //rig.velocity = Vector2.one * speed;
                    
                    break;
                        

            }
            go = false;
            print("執行");


        }

        if(GameManager.Instance.GameStatus == GameManager.Status.Boss && GameManager.ballFight == false)
        {
            Vector2 BossP = new Vector2();
            BossP.x = Player.transform.position.x;
            BossP.y = -3.14f;
            transform.position = BossP;
            


        }
        


        die();
        VsBoss();



    }
   
   
    void VsBoss()
    {
        if(GameManager.Gr >= 156)
        {
            GameManager.boss = true;
        }
    }
    void die()
    {
        if(gameObject.transform.position.y <= -5)
        {
            GameManager.GameStatus = GameManager.Status.dead;
            GameManager.isdie = true;
            gameObject.SetActive(false);
            
        }
        
        
    }

    //可以通過簡單地將球的 x  坐標除以球拍的寬度來實現。
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        //減去  racketPos.x  從價值  ballPos.x  值，以獲得相對位置
        return (ballPos.x - racketPos.x) / racketWidth;
    }


    private void OnCollisionEnter2D(Collision2D ion)
    {
        switch(ion.gameObject.tag)
        {
            case "球拍":
                if ( GameManager.Instance.GameStatus == GameManager.Status.Play)
                {
                    //計算命中位子
                    float x = hitFactor(transform.position, ion.transform.position, ion.collider.bounds.size.x);
                    //計算方向，將長度設置為1
                    Vector2 dir = new Vector2(x, 1).normalized;
                    //用dir *速度當命中球拍後的速度
                    GetComponent<Rigidbody2D>().velocity = dir * speed;

                }
                break;
            case "磚塊":
                switch (GameManager.Gr)
                {
                    default:
                        break;
                    case 9:
                        speed = 6;
                        break;
                    case 19:
                        speed = 8;
                        break;
                    case 29:
                        speed = 10;
                        break;
                }
                break;
         
        }
 
    }
    

}
