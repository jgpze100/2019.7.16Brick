using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum Status { Start, Play, Pause, dead, Boss,End };
    public static GameManager Instance = null;
    [Header("目前的遊戲狀態")]
    public Status GameStatus;

    static GameManager instacne;
    public GameObject SGT;
    public GameObject youwin;
    public GameObject reset;
    public GameObject Grade;
    public GameObject Skill_A;
    public GameObject Blue;
    public GameObject FinalB;
    public Text Score;
    public Text SkillPoint;
    public Text die;
    
    //分數
    public int Gr = 0;
    public int skill = 0;
    public int Player_HP = 0;
    public int BOSS_HP = 0;
    public int BOSS_Score = 0;
    //第一個磚塊的位置
    public int StartX = -2;
    public int StartY = 4;
    public bool start;
    public bool boss;
    public bool isdie;
    public bool bossisdie;
    public bool ballFight;


    int LV;

// Start is called before the first frame update
    void Awake()
    {
        //如果不想被重置紀錄的話
        /*if(instacne == null)
        {
            instacne = this;
            DontDestroyOnLoad(this);
            name = "GM";
        }*/
        start = true;
        boss = false;
        isdie = false;
        ballFight = false;
        bossisdie = false;
        FinalB.SetActive(false);
        Grade.SetActive(false);
        Skill_A.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
            
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        GameStatus = Status.Start;

    }


    // Update is called once per frame
    void Update()
    {
        Score.text = "" + Gr;
        SkillPoint.text = "" + skill;
        BOSS_Score = Gr;
        print(Player_HP);
        switch (GameStatus)
        {
            case Status.Start:
                SGT.GetComponent<Text>().text = "  按下S鍵開始遊戲";
                if (Input.GetKey(KeyCode.S))
                {
                    
                    Destroy(SGT.gameObject);
                    Gr = 0;
                    skill = 0;
                    BOSS_HP = 0;
                    Player_HP = 0;

                    Grade.SetActive(true);
                    Skill_A.SetActive(true);
                    


                    for (int i = -4; i <= 8; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {

                            //複製磚塊
                            Instantiate(Blue, new Vector3(StartX + i, StartY - j, 0), Quaternion.identity);

                        }

                    }
                    GameStatus = Status.Play;

                }
                
                break;
            case Status.Play:
                if (Gr >= 156 && boss == true)
                {
                    GameStatus = Status.Boss;
                    boss = false;
                }
                else if(isdie == true)
                {
                    GameStatus = Status.dead;
                }
                break;
            case Status.Pause:
                
                break;
            case Status.dead:
                die.text = "         系阿啦\n按下R鍵可以重來";
                if (Input.GetKey(KeyCode.R) && isdie == true)
                {
                    GameStatus = Status.Play;
                    SceneManager.LoadScene(0);
                    isdie = false;

                }
                
                break;
            case Status.Boss:
                if (BOSS_Score >= 156 && boss == true)
                {
                    FinalB.SetActive(true);
                    boss = false;
                    
                }

                if (isdie == true)
                {
                    GameStatus = Status.dead;
                }
                if (bossisdie == true)
                {
                    FinalB.SetActive(false);
                    GameStatus = Status.End;
                }
                break;
            case Status.End:
                youwin.GetComponent<Text>().text = "                           你贏了!!\n但接下來還有很多可怕的BOSS在等著你呢...";
                reset.GetComponent<Text>().text = "按下R可以重新遊玩~";
                if (Input.GetKey(KeyCode.R) && bossisdie == true)
                {
                    GameStatus = Status.Play;
                    SceneManager.LoadScene(0);
                   

                }

                break; 

        }
        
        
        
    }
}
