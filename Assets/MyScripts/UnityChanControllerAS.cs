using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanControllerAS : MonoBehaviour
{
    //表示するテキスト
    public GameObject parameterText;

    BattleManager battleManager;
    EnemyControllerAS enemyControllerAS;
    ButtonControllerAS buttonControllerAS;
    private bool isHit = false;
    //コンポーネントを入れる
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoadcs.myHP = DontDestroyOnLoadcs.myMAXHP;

        if (DontDestroyOnLoadcs.color == 1)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (DontDestroyOnLoadcs.color == 2)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.gray;
        }

        if (DontDestroyOnLoadcs.color == 3)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.green;
        }

        if (DontDestroyOnLoadcs.color == 4)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.cyan;
        }

        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        if(DontDestroyOnLoadcs.mob)enemyControllerAS = GameObject.Find("ZolrikPrefab").GetComponent<EnemyControllerAS>();
        if(DontDestroyOnLoadcs.boss) enemyControllerAS = GameObject.Find("ZolrikMercenary").GetComponent<EnemyControllerAS>();
        buttonControllerAS = GameObject.Find("ButtonControllerAS").GetComponent<ButtonControllerAS>();
        
        animator = GetComponent<Animator>();
        //シーン中のTextオブジェクトを取得
        this.parameterText = GameObject.Find("ParameterText");
        //this.eneHPMPText.GetComponent<Text>().text = "HP " + enemyControllerAS.eneHP + "\nMP " + enemyControllerAS.eneMP;
    }

    void Attack()
    {
        isHit = false;
        this.parameterText.GetComponent<Text>().text = "1,2,3,4から数字を選択してください\n1.通常攻撃    2.MP消費攻撃\n3.瞑想    4.狙い打ち";
        if (Input.GetKeyDown(KeyCode.Alpha1) || buttonControllerAS.isButton1Down)
        {
            enemyControllerAS.eneHP -= (DontDestroyOnLoadcs.myATK - enemyControllerAS.eneDEF);
            isHit = true;
            animator.SetBool("ScrewKick", true);
            this.parameterText.GetComponent<Text>().text = "通常攻撃\nHPを"+ (DontDestroyOnLoadcs.myATK - enemyControllerAS.eneDEF) + "削った！" ;
            //this.eneHPMPText.GetComponent<Text>().text = "HP " + enemyControllerAS.eneHP + "\nMP " + enemyControllerAS.eneMP;
            battleManager.delta = 0;
            battleManager.isMyturn = false;
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)|| buttonControllerAS.isButton2Down) && DontDestroyOnLoadcs.myMP >= 10)
        {
            DontDestroyOnLoadcs.myMP -= 10;
            isHit = true;
            enemyControllerAS.eneHP -= DontDestroyOnLoadcs.myATK * 2;
            animator.SetBool("Hikick", true);
            this.parameterText.GetComponent<Text>().text = "MP消費攻撃\nHPを" + (DontDestroyOnLoadcs.myATK * 2) + "削った！";
            //this.eneHPMPText.GetComponent<Text>().text = "HP " + enemyControllerAS.eneHP + "\nMP " + enemyControllerAS.eneMP;
            battleManager.delta = 0;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || buttonControllerAS.isButton3Down)
        {
            this.parameterText.GetComponent<Text>().text = "瞑想\nHPが" + (DontDestroyOnLoadcs.myHP * 0.3) + "回復\n" + "MPが" + (DontDestroyOnLoadcs.myMP * 0.3) + "回復";
            animator.SetBool("Pose", true);
            DontDestroyOnLoadcs.myHP *= 1.3;
            DontDestroyOnLoadcs.myMP *= 1.3;
            battleManager.delta = 0;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || buttonControllerAS.isButton4Down)
        {
            int kakuritu = Random.Range(1, 11);
            if (kakuritu <= 4)
            {
                isHit = true;
                enemyControllerAS.eneHP -= (DontDestroyOnLoadcs.myATK * 2 - enemyControllerAS.eneDEF);
                this.parameterText.GetComponent<Text>().text = "会心の一撃！\nHPを" + (DontDestroyOnLoadcs.myATK * 2 - enemyControllerAS.eneDEF) + "削った！";
                animator.SetBool("ScrewKick", true);
                //this.eneHPMPText.GetComponent<Text>().text = "HP " + enemyControllerAS.eneHP + "\nMP " + enemyControllerAS.eneMP;
            } else
            {
                this.parameterText.GetComponent<Text>().text = "空振りした！";
                animator.SetBool("ScrewKick", true);
            }
            battleManager.delta = 0;
            battleManager.isMyturn = false;
        }
        //Debug.Log(hisHP);
    }

    public void EndAttack ()
    {
        animator.SetBool("ScrewKick", false);
        if(isHit) enemyControllerAS.eneanimator.SetBool("Death", true);
    }

    public void EndMagic()
    {
        animator.SetBool("Hikick", false);
    }

    public void EndDown()
    {
        animator.SetBool("DamageDown", false);
    }

    public void EndPose()
    {
        animator.SetBool("Pose", false);
    }


    

    // Update is called once per frame
    void Update()
    {
        //戦闘処理
        if (battleManager.isMyturn == true && battleManager.delta > battleManager.span)
        {
            if (DontDestroyOnLoadcs.myHP > 0 && enemyControllerAS.eneHP > 0)
            {
                Attack();
            }
            else
            {
                this.parameterText.GetComponent<Text>().text = "戦闘終了:敗北";
                DontDestroyOnLoadcs.lose = true;
                battleManager.endscene = true;
            }
        }
    }
}
