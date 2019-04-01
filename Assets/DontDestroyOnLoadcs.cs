using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadcs : MonoBehaviour
{
    //ヨロイの購入などで変化
    public static double myMAXHP = 500;
    public static double myMAXMP = 30;

    //ヨロイの色

    //戦闘時とポーション取得時に変化
    public static double myHP = 500;
    public static double myMP = 30;
    public static int myDEF = 0;
    public static int myATK = 100;

    //持っているお金
    public static int money = 100;

    //戦闘何回目か
    public static int kaisuu = 0;
    public static bool lose = false;
    public static bool mob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
