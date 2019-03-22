using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanControllerAS : MonoBehaviour
{
    public double myHP = 500f;
    public double myMP = 30;
    public int myDEF = 0;
    public int myATK = 100;

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
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemyControllerAS.eneHP -= (myATK - enemyControllerAS.eneDEF);
            animator.SetBool("Jab", true);
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && myMP >= 10)
        {
            myMP -= 10;
            enemyControllerAS.eneHP -= myATK * 1.2;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            myHP *= 1.3;
            myMP *= 1.3;
            battleManager.isMyturn = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int kakuritu = Random.Range(1, 11);
            if (kakuritu <= 5)
            {
                enemyControllerAS.eneHP -= myATK * 3;
            }
            battleManager.isMyturn = false;
        }
        //Debug.Log(hisHP);
    }
    

    // Update is called once per frame
    void Update()
    {
        //戦闘処理
        if (battleManager.isMyturn == true)
        {
            if (myHP > 0 && enemyControllerAS.eneHP > 0)
            {
                Attack();
            }
        }
    }
}
