using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerAS : MonoBehaviour
{
    public double eneHP;
    public double eneMP;
    public int eneDEF;
    public int eneATK;

    BattleManager battleManager;
    UnityChanControllerAS unityChanControllerAS;
    //表示するテキスト
    private GameObject parameterText;
    private GameObject myHPMPText;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        unityChanControllerAS = GameObject.Find("unitychan").GetComponent<UnityChanControllerAS>();

        animator = GetComponent<Animator>();

        this.parameterText = GameObject.Find("ParameterText");
        this.myHPMPText = GameObject.Find("MyHPMPText");

        this.myHPMPText.GetComponent<Text>().text = "HP " + unityChanControllerAS.myHP + "\nMP  " + unityChanControllerAS.myMP;

        eneHP = 500;
        eneMP = 30;
        eneDEF = 0;
        eneATK = 200;

        //パラメータつける
        //if (this.gameObject.tag == "")
        //{
        //    eneHP = 1000;
        //    eneMP = 50;
        //    eneDEF = 50;
        //    eneATK = 100;
        //}
    }

    void Attack()
    {
        int damage = Random.Range(1, 9);
        if (damage <= 3)
        {
            unityChanControllerAS.myHP -= (eneATK - unityChanControllerAS.myDEF);
            animator.SetBool("Attack", true);
            this.parameterText.GetComponent<Text>().text = "HPを" + (eneATK - unityChanControllerAS.myDEF) + "削られた！";
            this.myHPMPText.GetComponent<Text>().text = "HP "+ unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        else if (damage <= 6 && eneMP >=10)
        {
            eneMP -= 10;
            unityChanControllerAS.myHP -= eneATK * 1.2;
            this.parameterText.GetComponent<Text>().text = "HPを" + (eneATK * 1.2) + "削られた！";
            this.myHPMPText.GetComponent<Text>().text = "HP " + unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        else if (damage <= 9 && eneHP <= unityChanControllerAS.myATK)
        {
            this.parameterText.GetComponent<Text>().text = "敵のHPが " + (eneHP * 0.3) + "回復\n" + "敵のMPが " + (eneMP * 0.3) + "回復";
            eneHP *= 1.3;
            eneMP *= 1.3;
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        else
        {
            int kakuritu = Random.Range(1, 11);
            if (kakuritu <= 5)
            {
                unityChanControllerAS.myHP -= (eneATK * 3 - unityChanControllerAS.myDEF);
                this.parameterText.GetComponent<Text>().text = "HPを" + (eneATK * 3 - unityChanControllerAS.myDEF) + "削られた！";
                this.myHPMPText.GetComponent<Text>().text = "HP " + unityChanControllerAS.myHP + "\nMP " + unityChanControllerAS.myMP;
            }
            else
            {
                this.parameterText.GetComponent<Text>().text = "敵が空振りした！";
            }
            battleManager.delta = 0;
            battleManager.isMyturn = true;
        }
        //Debug.Log(myHP);
    }

    public void EndAttack()
    {
        animator.SetBool("Attack", false);
    }

    // Update is called once per frame
    void Update()
    {
        //戦闘処理
        if (battleManager.isMyturn == false && battleManager.delta > battleManager.span)
        {
            if (unityChanControllerAS.myHP > 0 && eneHP > 0)
            {
                Attack();
            }
            else
            {
                this.parameterText.GetComponent<Text>().text = "戦闘終了:勝利！";
            }
        }
    }
}
