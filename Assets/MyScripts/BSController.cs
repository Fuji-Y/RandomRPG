using System.Collections;
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
            bstext.GetComponent<Text>().text = "革の鎧     100G\n若干強くなる\n\n購入しますか?\nYes → y   No → n";
            this.count = 1;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || buttonControllerBS.isButton2Down)
        {
            bstext.GetComponent<Text>().text = "鉄の鎧     500G\nそこそこ強くなる\n\n購入しますか?\nYes → y   No → n";
            this.count = 2;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.gray;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || buttonControllerBS.isButton3Down)
        {
            bstext.GetComponent<Text>().text = "鋼の鎧     2500G\n結構強くなる\n\n購入しますか?\nYes → y   No → n";
            this.count = 3;
            numberPanel.SetActive(false);
            YNPanel.SetActive(true);
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || buttonControllerBS.isButton4Down)
        {
            bstext.GetComponent<Text>().text = "ミスリルの鎧      12500G\nもの凄く強くなる\n\n購入しますか?\nYes → y   No → n";
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
            if (DontDestroyOnLoadcs.money >= 100 && DontDestroyOnLoadcs.color == 0)
            {
                DontDestroyOnLoadcs.money -= 100;
                DontDestroyOnLoadcs.myMAXHP *= 1.1;
                DontDestroyOnLoadcs.myMAXMP *= 1.1;
                DontDestroyOnLoadcs.myDEF *= 1.1;
                DontDestroyOnLoadcs.myATK *= 1.1;
                DontDestroyOnLoadcs.color = 1;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 100)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
            if (DontDestroyOnLoadcs.color >= 1)
            {
                bstext.GetComponent<Text>().text = "すでに装備を持っています\nnを押すと戻ります";
            }
        }

        if (count == 2 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 500)
            {
                DontDestroyOnLoadcs.money -= 500;
                DontDestroyOnLoadcs.myMAXHP *= 1.4;
                DontDestroyOnLoadcs.myMAXMP *= 1.4;
                DontDestroyOnLoadcs.myDEF *= 1.4;
                DontDestroyOnLoadcs.myATK *= 1.4;
                DontDestroyOnLoadcs.color = 2;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 500)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
            if (DontDestroyOnLoadcs.color >= 2)
            {
                bstext.GetComponent<Text>().text = "すでに装備を持っています\nnを押すと戻ります";
            }
        }

        if (count == 3 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 2500)
            {
                DontDestroyOnLoadcs.money -= 2500;
                DontDestroyOnLoadcs.myMAXHP *= 1.7;
                DontDestroyOnLoadcs.myMAXMP *= 1.7;
                DontDestroyOnLoadcs.myDEF *= 1.7;
                DontDestroyOnLoadcs.myATK *= 1.7;
                DontDestroyOnLoadcs.color = 3;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 2500)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
            if (DontDestroyOnLoadcs.color >= 3)
            {
                bstext.GetComponent<Text>().text = "すでに装備を持っています\nnを押すと戻ります";
            }
        }

        if (count == 4 && (Input.GetKeyDown(KeyCode.Y) || buttonControllerBS2.isYButtonDown))
        {
            if (DontDestroyOnLoadcs.money >= 12500)
            {
                DontDestroyOnLoadcs.money -= 12500;
                DontDestroyOnLoadcs.myMAXHP *= 2.2;
                DontDestroyOnLoadcs.myMAXMP *= 2.2;
                DontDestroyOnLoadcs.myDEF *= 2.2;
                DontDestroyOnLoadcs.myATK *= 2.2;
                DontDestroyOnLoadcs.color = 4;
                //DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
                SceneManager.LoadScene("GameScene");
            }
            if (DontDestroyOnLoadcs.money < 12500)
            {
                bstext.GetComponent<Text>().text = "お金が足りません\nnを押すと戻ります";
            }
            if (DontDestroyOnLoadcs.color == 4)
            {
                bstext.GetComponent<Text>().text = "すでに装備を持っています\nnを押すと戻ります";
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