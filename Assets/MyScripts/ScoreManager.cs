using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public  int myMAXHP_num;
    public int myMAXMP_num;

    //ヨロイの色
    public  int color_num;

    //戦闘時とポーション取得時に変化
    public  int myHP_num;
    public  int myMP_num;
    public  int myDEF_num;
    public  int myATK_num;

    //持っているお金
    public  int money_num;

    //戦闘何回目か
    public  int kaisuu_num;
    public  int boskaisuu_num;
    public  int losekaisuu_num;
    public  int lose_bool = 0;
    public  int mob_bool = 0;
    public  int boss_bool = 0;

    //場所
    public  int Bukiya_bool = 0;

    DontDestroyOnLoadcs dontDestroyOnLoadcs;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene") dontDestroyOnLoadcs = GameObject.Find("DontDestroyOnLoadcs").GetComponent<DontDestroyOnLoadcs>();
    }

    // 削除時の処理
    void OnDestroy()
    {
        if (SceneManager.GetActiveScene().name == "AttackingScene" || SceneManager.GetActiveScene().name == "BuyingScene")
        {
            myMAXHP_num = (int)DontDestroyOnLoadcs.myMAXHP;
            myMAXMP_num = (int)DontDestroyOnLoadcs.myMAXMP;
            myHP_num = (int)DontDestroyOnLoadcs.myHP;
            myMP_num = (int)DontDestroyOnLoadcs.myMP;
            myDEF_num = (int)DontDestroyOnLoadcs.myDEF;
            myATK_num = (int)DontDestroyOnLoadcs.myATK;

            color_num = DontDestroyOnLoadcs.color;
            money_num = DontDestroyOnLoadcs.money;
            kaisuu_num = DontDestroyOnLoadcs.kaisuu;
            boskaisuu_num = DontDestroyOnLoadcs.boskaisuu;
            losekaisuu_num = DontDestroyOnLoadcs.losekaisuu;

            if (DontDestroyOnLoadcs.lose) lose_bool = 1;
            if (DontDestroyOnLoadcs.mob) mob_bool = 1;
            if (DontDestroyOnLoadcs.boss) boss_bool = 1;
            if (DontDestroyOnLoadcs.Bukiya) Bukiya_bool = 1;

            // スコアを保存
            if (!DontDestroyOnLoadcs.mob) Save();
        }

        if (SceneManager.GetActiveScene().name == "ResultScene") DontDestroyOnLoadcs.boskaisuu = 0;
    }

    void Save()
    {
        PlayerPrefs.SetInt("MYMAXHP", myMAXHP_num);
        PlayerPrefs.SetInt("MYMAXMP", myMAXMP_num);
        PlayerPrefs.SetInt("COLOR", color_num);

        PlayerPrefs.SetInt("MYHP", myHP_num);
        PlayerPrefs.SetInt("MYMP", myMP_num);
        PlayerPrefs.SetInt("MYDEF", myDEF_num);
        PlayerPrefs.SetInt("MYATK", myATK_num);

        PlayerPrefs.SetInt("MONEY", money_num);
        PlayerPrefs.SetInt("KAISUU", kaisuu_num);
        PlayerPrefs.SetInt("BOSKAISUU", boskaisuu_num);
        PlayerPrefs.SetInt("LOSEKAISUU", losekaisuu_num);
        PlayerPrefs.SetInt("LOSEBOOL", lose_bool);
        PlayerPrefs.SetInt("MOBBOOL", mob_bool);
        PlayerPrefs.SetInt("BOSSBOOL", boss_bool);
        PlayerPrefs.SetInt("BUKIYABOOL", Bukiya_bool);
        PlayerPrefs.Save();
    }

    public void LoadButton()
    {
        //ロード
        myMAXHP_num = PlayerPrefs.GetInt("MYMAXHP");
        myMAXMP_num = PlayerPrefs.GetInt("MYMAXMP");
        color_num = PlayerPrefs.GetInt("COLOR");

        myHP_num = PlayerPrefs.GetInt("MYHP");
        myMP_num = PlayerPrefs.GetInt("MYMP");
        myDEF_num = PlayerPrefs.GetInt("MYDEF");
        myATK_num = PlayerPrefs.GetInt("MYATK");

        money_num = PlayerPrefs.GetInt("MONEY");
        kaisuu_num = PlayerPrefs.GetInt("KAISUU");
        boskaisuu_num = PlayerPrefs.GetInt("BOSKAISUU");
        losekaisuu_num = PlayerPrefs.GetInt("LOSEKAISUU");
        lose_bool = PlayerPrefs.GetInt("LOSEBOOL");
        mob_bool = PlayerPrefs.GetInt("MOBBOOL");
        boss_bool = PlayerPrefs.GetInt("BOSSBOOL");
        Bukiya_bool = PlayerPrefs.GetInt("BUKIYABOOL");
        Debug.Log(money_num); //後で消す

        dontDestroyOnLoadcs.LoadButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
