using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerAS : MonoBehaviour
{
    public double eneHP;
    public double eneMP;
    public double eneDEF;
    public double eneATK;

    BattleManager battleManager;
    UnityChanControllerAS unityChanControllerAS;
    //表示するテキスト
    private GameObject parameterText;

    public Animator eneanimator;

    private bool ishit;
    // Start is called before the first frame update
    void Start()
    {
        ishit = false;
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        unityChanControllerAS = GameObject.Find("unitychan").GetComponent<UnityChanControllerAS>();

        eneanimator = GetComponent<Animator>();

        this.parameterText = GameObject.Find("ParameterText");

        if ((DontDestroyOnLoadcs.mob && DontDestroyOnLoadcs.kaisuu == 0) || DontDestroyOnLoadcs.lose)
        {
            eneHP = 500;
            eneMP = 30;
            eneDEF = 0;
            eneATK = 100;
        } else if (DontDestroyOnLoadcs.mob)
        {
            eneHP = 100 + DontDestroyOnLoadcs.myATK * 2;
            eneMP = DontDestroyOnLoadcs.myMAXMP;
            eneDEF = DontDestroyOnLoadcs.myDEF;
            eneATK = DontDestroyOnLoadcs.myATK - 50;
        } 

        if (DontDestroyOnLoadcs.boss)
        {
            eneHP = 200 + DontDestroyOnLoadcs.myATK * 2;
            eneMP = 10 + DontDestroyOnLoadcs.myMAXMP;
            eneDEF = DontDestroyOnLoadcs.myDEF +10;
            eneATK = DontDestroyOnLoadcs.myATK - 10;
        }

    }

    void Attack()
    {
        ishit = false;
        int damage = Random.Range(1, 9);
        if (damage <= 3)
        {
            DontDestroyOnLoadcs.myHP -= (eneATK - DontDestroyOnLoadcs.myDEF);
            eneanimator.SetBool("Attack", true);
            this.parameterText.GetComponent<Text>().text = "敵の通常攻撃\nHPを" + (eneATK - DontDestroyOnLoadcs.myDEF) + "削られた！";
            //this.myHPMPText.GetComponent<Text>().text = "HP "+ unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
            ishit = true;
        }
        else if (damage <= 6 && eneMP >= 10)
        {
            eneMP -= 10;
            DontDestroyOnLoadcs.myHP -= eneATK * 2;
            eneanimator.SetBool("Attack", true);
            this.parameterText.GetComponent<Text>().text = "敵のMP消費攻撃\nHPを" + (eneATK * 2) + "削られた！";
            //this.myHPMPText.GetComponent<Text>().text = "HP " + unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
            ishit = true;
        }
        else if (damage <= 9 && eneHP <= DontDestroyOnLoadcs.myATK)
        {
            this.parameterText.GetComponent<Text>().text = "瞑想\n敵のHPが " + (eneHP * 0.3) + "回復\n" + "敵のMPが " + (eneMP * 0.3) + "回復";
            eneanimator.SetBool("Idle4", true);
            eneHP *= 1.3;
            eneMP *= 1.3;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        else
        {
            int kakuritu = Random.Range(1, 11);
            if (kakuritu <= 4)
            {
                DontDestroyOnLoadcs.myHP -= (eneATK * 2 - DontDestroyOnLoadcs.myDEF);
                eneanimator.SetBool("Attack", true);
                this.parameterText.GetComponent<Text>().text = "会心の一撃！\nHPを" + (eneATK * 2 - DontDestroyOnLoadcs.myDEF) + "削られた！";
                ishit = true;
                //this.myHPMPText.GetComponent<Text>().text = "HP " + unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            }
            else
            {
                eneanimator.SetBool("Attack", true);
                this.parameterText.GetComponent<Text>().text = "敵が空振りした！";
            }
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        //Debug.Log(myHP);
    }

    public void EndAttack()
    {
        eneanimator.SetBool("Attack", false);
        if(ishit) unityChanControllerAS.animator.SetBool("DamageDown", true);
    }

    public void EndDeath()
    {
        eneanimator.SetBool("Death", false);
    }

    public void EndIdle()
    {
        eneanimator.SetBool("Idle4", false);
    }

    // Update is called once per frame
    void Update()
    {
        //戦闘処理
        if (battleManager.isMyturn == false && battleManager.delta > battleManager.span)
        {
            if (DontDestroyOnLoadcs.myHP > 0 && eneHP > 0)
            {
                Debug.Log("Attackの呼び出し");
                Attack();
            }
            else
            {
                DontDestroyOnLoadcs.money += DontDestroyOnLoadcs.kaisuu * 100;
                this.parameterText.GetComponent<Text>().text = "戦闘終了:勝利！\n" + DontDestroyOnLoadcs.kaisuu * 100 + "G 獲得！";
                DontDestroyOnLoadcs.lose = false;
                battleManager.endscene = true;
            }
        }
    }
}
