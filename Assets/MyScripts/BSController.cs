﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BSController : MonoBehaviour
{
    public GameObject bstext;
    public GameObject moneyText;
    private int count;
    ButtonControllerBS buttonControllerBS;
    ButtonControllerBS2 buttonControllerBS2;
    public GameObject YNPanel;
    public GameObject numberPanel;

    // Start is called before the first frame update
    void Start()
    {
        bstext = GameObject.Find("BStext");
        moneyText = GameObject.Find("MoneyText");
        YNPanel = GameObject.Find("YesNoPanel");
        numberPanel = GameObject.Find("NumberPanel");
        moneyText.GetComponent<Text>().text = "所持ゴールド\n" + DontDestroyOnLoadcs.money + "G";
        Starttext();

        GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.white;

        buttonControllerBS = GameObject.Find("ButtonControllerBS").GetComponent<ButtonControllerBS>();
        buttonControllerBS2 = GameObject.Find("ButtonControllerBS2").GetComponent<ButtonControllerBS2>();
    }

    // Update is called once per frame
    void Update()
    {
        SecondText();
        ThirdText();
    }

    void Starttext()
    {
        bstext.GetComponent<Text>().text = "    どれを買いますか？\n     1.革の鎧\n     2.鉄の鎧\n     3.鋼の鎧\n     4.ミスリルの鎧\n     5.やめておく";
        count = 0;
        GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.white;
        numberPanel.SetActive(true);
        YNPanel.SetActive(false);
    }

    void SecondText()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || buttonControllerBS.isButton1Down)
        {
            bstext.GetComponent<Text>().text = "革の鎧     100G\nHP + 50      MP + 10\n防御 + 30      攻撃 + 50\n\n購入しますか?\nYes → y   No → n";
            this.count = 1;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || buttonControllerBS.isButton2Down)
        {
            bstext.GetComponent<Text>().text = "鉄の鎧     500G\nHP + 100      MP + 20\n防御 + 50      攻撃 + 100\n\n購入しますか?\nYes → y   No → n";
            this.count = 2;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.gray;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || buttonControllerBS.isButton3Down)
        {
            bstext.GetComponent<Text>().text = "鋼の鎧     1000G\nHP + 200      MP + 30\n防御 + 100      攻撃 + 150\n\n購入しますか?\nYes → y   No → n";
            this.count = 3;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || buttonControllerBS.isButton4Down)
        {
            bstext.GetComponent<Text>().text = "ミスリルの鎧      1500G\nHP + 500      MP + 50\n防御 + 50      攻撃 + 200\n\n購入しますか?\nYes → y   No → n";
            this.count = 4;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) || buttonControllerBS.isButton5Down)
        {
            bstext.GetComponent<Text>().text = "本当にやめますか？\nYes → y\nNo → n";
            this.count = 5;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
        }
    }

    void ThirdText()
    {
        if (count == 1 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 100)
            {
                DontDestroyOnLoadcs.money -= 100;
                DontDestroyOnLoadcs.myMAXHP += 50;
                DontDestroyOnLoadcs.myMAXMP += 10;
                DontDestroyOnLoadcs.myDEF += 30;
                DontDestroyOnLoadcs.myATK += 50;
                DontDestroyOnLoadcs.color = 1;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 100)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
        }

        if (count == 2 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 500)
            {
                DontDestroyOnLoadcs.money -= 500;
                DontDestroyOnLoadcs.myMAXHP += 100;
                DontDestroyOnLoadcs.myMAXMP += 20;
                DontDestroyOnLoadcs.myDEF += 50;
                DontDestroyOnLoadcs.myATK += 100;
                DontDestroyOnLoadcs.color = 2;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 500)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
        }

        if (count == 3 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 800)
            {
                DontDestroyOnLoadcs.money -= 800;
                DontDestroyOnLoadcs.myMAXHP += 200;
                DontDestroyOnLoadcs.myMAXMP += 30;
                DontDestroyOnLoadcs.myDEF += 100;
                DontDestroyOnLoadcs.myATK += 150;
                DontDestroyOnLoadcs.color = 3;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 800)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
        }

        if (count == 4 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 1200)
            {
                DontDestroyOnLoadcs.money -= 1200;
                DontDestroyOnLoadcs.myMAXHP += 500;
                DontDestroyOnLoadcs.myMAXMP += 50;
                DontDestroyOnLoadcs.myDEF += 150;
                DontDestroyOnLoadcs.myATK += 200;
                DontDestroyOnLoadcs.color = 4;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 1200)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
        }

        if (count == 5 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKeyDown(KeyCode.N) || buttonControllerBS2.isNButtonDown)
        {
            Starttext();
        }
    }
}