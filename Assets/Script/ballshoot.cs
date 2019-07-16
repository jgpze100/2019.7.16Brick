using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballshoot : MonoBehaviour
{
    GameManager GameManager;
    public GameObject ball;
    public float MoveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameStatus == GameManager.Status.Boss)
        {
            Fight();
        }
        
    }
    void Fight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fightball;
            fightball = Instantiate(ball, transform.position, Quaternion.Euler(0, 0, 0));
            fightball.GetComponent<Rigidbody2D>().velocity = Vector2.up * MoveSpeed;
        }

    }
}
