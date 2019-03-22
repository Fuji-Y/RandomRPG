using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanControllerAS : MonoBehaviour
{
    public double myHP = 500f;
    public double myMP = 30;
    public int myDEF = 0;
    public int myATK = 100;
    //表示するテキスト
    private GameObject parameterText;
    //時間計測用の数字
    private float delta = 0;
    //待ってほしい時間
    private float span = 1;

    BattleManager battleManager;
    EnemyControllerAS enemyControllerAS;

    //コンポーネントを入れる
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        enemyControllerAS = GameObject.Find("EnemyControllerAS").GetComponent<EnemyControllerAS>();
        
        animator = GetComponent<Animator>();
        //シーン中のTextオブジェクトを取得
        this.parameterText = GameObject.Find("ParameterText");
    }

    void Attack()
    {
        this.parameterText.GetComponent<Text>().text = "1,2,3,4から数字を選択してください\n1.通常攻撃    2.魔法攻撃\n3.瞑想    4.必殺技";
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemyControllerAS.eneHP -= (myATK - enemyControllerAS.eneDEF);
            animator.SetBool("ScrewKick", true);
            this.parameterText.GetComponent<Text>().text = "HPを"+ (myATK - enemyControllerAS.eneDEF) + "削った！" ;
            this.delta = 0;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && myMP >= 10)
        {
            myMP -= 10;
            enemyControllerAS.eneHP -= myATK * 1.2;
            this.parameterText.GetComponent<Text>().text = "HPを" + (myATK * 1.2) + "削った！";
            this.delta = 0;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.parameterText.GetComponent<Text>().text = "HPが" + (myHP * 0.3) + "回復\n" + "MPが" + (myMP * 0.3) + "回復";
            myHP *= 1.3;
            myMP *= 1.3;
            this.delta = 0;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int kakuritu = Random.Range(1, 11);
            if (kakuritu <= 5)
            {
                enemyControllerAS.eneHP -= (myATK * 3 - enemyControllerAS.eneDEF);
                this.parameterText.GetComponent<Text>().text = "HPを" + (myATK * 3 - enemyControllerAS.eneDEF) + "削った！";
            } else
            {
                this.parameterText.GetComponent<Text>().text = "空振りした！";
            }
            this.delta = 0;
            battleManager.isMyturn = false;
        }
        //Debug.Log(hisHP);
    }

    public void EndAttack ()
    {
        animator.SetBool("ScrewKick", false);
    }
    

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        //戦闘処理
        if (battleManager.isMyturn == true && this.delta > this.span)
        {
            if (myHP > 0 && enemyControllerAS.eneHP > 0)
            {
                Attack();
            }
            else
            {
                this.parameterText.GetComponent<Text>().text = "戦闘終了:敗北";
            }
        }
    }
}
