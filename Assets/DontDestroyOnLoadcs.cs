using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadcs : MonoBehaviour
{
    //ヨロイの購入などで変化
    public static double myMAXHP = 500;
    public static double myMAXMP = 30;

    //ヨロイの色
    public static int color;

    //戦闘時とポーション取得時に変化
    public static double myHP = 500;
    public static double myMP = 30;
    public static double myDEF = 0;
    public static double myATK = 100;

    //持っているお金
    public static int money = 100;

    //戦闘何回目か
    public static int kaisuu = 0;
    public static int boskaisuu = 0;
    public static bool lose = false;
    public static bool mob;
    public static bool boss;

    //場所
    public static bool Bukiya;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
