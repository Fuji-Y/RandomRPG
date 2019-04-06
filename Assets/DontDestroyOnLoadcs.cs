using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadcs : MonoBehaviour
{
    //ヨロイの購入などで変化
    public static double myMAXHP;
    public static double myMAXMP;

    //ヨロイの色
    public static int color;

    //戦闘時とポーション取得時に変化
    public static double myHP;
    public static double myMP;
    public static double myDEF;
    public static double myATK;

    //持っているお金
    public static int money;

    //戦闘何回目か
    public static int kaisuu;
    public static int history;
    public static int losekaisuu;
    public static bool lose;
    public static bool mob;
    public static bool boss;

    //場所
    public static bool Bukiya;

    //PlayerPrefに容れないもの
    public static bool Load;
    public static int boskaisuu = 0;


    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void StartButton()
    {
        // StartButton
        myMAXHP = 500;
        myMAXMP = 30;
        myHP = 500;
        myMP = 30;
        myDEF = 0;
        myATK = 100;
        money = 100;
        kaisuu = 0;
        history = 0;
        losekaisuu = 0;
        lose = false;
        mob = false;
        boss = false;
        Bukiya = false;
    }

    public void LoadButton()
    {
        // LoadButton ScoreManager後の処理
        myMAXHP = scoreManager.myMAXHP_num;
        myMAXMP = scoreManager.myMAXMP_num;
        color = scoreManager.color_num;
        myHP = scoreManager.myHP_num;
        myMP = scoreManager.myMP_num;
        myDEF = scoreManager.myDEF_num;
        myATK = scoreManager.myATK_num;
        money = scoreManager.money_num;
        kaisuu = scoreManager.kaisuu_num;
        history = scoreManager.boskaisuu_num;
        losekaisuu = scoreManager.losekaisuu_num;
        if(scoreManager.lose_bool == 1) lose = true;
        if (scoreManager.mob_bool == 1) mob = true;
        if (scoreManager.boss_bool == 1) boss = true;
        if (scoreManager.Bukiya_bool == 1) Bukiya = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
