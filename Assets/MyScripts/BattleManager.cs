using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public bool isMyturn = true;

    UnityChanControllerAS unityChanControllerAS;
    EnemyControllerAS enemyControllerAS;

    //時間計測用の数字
    public float delta = 0;
    //待ってほしい時間
    public float span = 3;
    //text
    private GameObject eneHPMPText;
    private GameObject myHPMPText;

    public bool endscene = false;
    

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyOnLoadcs.mob) Destroy(GameObject.Find("ZolrikMercenary"));
        if (DontDestroyOnLoadcs.boss) Destroy(GameObject.Find("ZolrikPrefab"));
        unityChanControllerAS = GameObject.Find("unitychan").GetComponent<UnityChanControllerAS>();
        enemyControllerAS = GameObject.Find("ZolrikPrefab").GetComponent<EnemyControllerAS>();
        this.eneHPMPText = GameObject.Find("EneHPMPText");
        this.myHPMPText = GameObject.Find("MyHPMPText");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        this.eneHPMPText.GetComponent<Text>().text = "HP " + enemyControllerAS.eneHP + "\nMP " + enemyControllerAS.eneMP;
        this.myHPMPText.GetComponent<Text>().text = "HP " + DontDestroyOnLoadcs.myHP + "\nMP  " + DontDestroyOnLoadcs.myMP;

        if (enemyControllerAS.eneHP < 0)
        {
            enemyControllerAS.eneHP = 0;
        }

        if (DontDestroyOnLoadcs.myHP < 0)
        {
            DontDestroyOnLoadcs.myHP = 0;
        }

        if (DontDestroyOnLoadcs.myHP > DontDestroyOnLoadcs.myMAXHP)
        {
            DontDestroyOnLoadcs.myHP = DontDestroyOnLoadcs.myMAXHP;
            unityChanControllerAS.parameterText.GetComponent<Text>().text = "最大HP値を超えて回復することはできません";
        }

        if (DontDestroyOnLoadcs.myMP > DontDestroyOnLoadcs.myMAXMP)
        {
            DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
            unityChanControllerAS.parameterText.GetComponent<Text>().text = "最大MP値を超えて回復することはできません";
        }

        if (this.endscene == true)
        {
            EndScene();
        }
    }

    void EndScene()
    {
        DontDestroyOnLoadcs.myHP = DontDestroyOnLoadcs.myMAXHP;
        if (DontDestroyOnLoadcs.myMP < DontDestroyOnLoadcs.myMAXMP / 2) DontDestroyOnLoadcs.myHP = DontDestroyOnLoadcs.myMAXMP / 2;
        SceneManager.LoadScene("GameScene");
    }
}
