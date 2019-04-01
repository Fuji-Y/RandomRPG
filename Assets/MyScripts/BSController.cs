using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BSController : MonoBehaviour
{
    public GameObject bstext;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        bstext = GameObject.Find("BStext");
        Starttext();
        GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.white;
        GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.white;
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
    }

    void SecondText()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bstext.GetComponent<Text>().text = "革の鎧     100G\nHP Default + 50   MP Default + 10\n防御 Default + 30   攻撃 Default + 50\n\n購入しますか?\nYes → y   No → n";
            this.count = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bstext.GetComponent<Text>().text = "鉄の鎧     500G\nHP Default + 100   MP Default + 20\n防御 Default + 50   攻撃 Default + 100\n\n購入しますか?\nYes → y   No → n";
            this.count = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bstext.GetComponent<Text>().text = "鋼の鎧     1000G\nHP Default + 200   MP Default + 30\n防御 Default + 100   攻撃 Default + 150\n\n購入しますか?\nYes → y   No → n";
            this.count = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bstext.GetComponent<Text>().text = "ミスリルの鎧      1500G\nHP Default + 500   MP Default + 50\n防御 Default + 50   攻撃 Default + 200\n\n購入しますか?\nYes → y   No → n";
            this.count = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            bstext.GetComponent<Text>().text = "本当にやめますか？\nYes → y\nNo → n";
            this.count = 5;
        }
    }

    void ThirdText()
    {
        if (count == 1 && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (count == 1 && Input.GetKeyDown(KeyCode.N))
        {
            Starttext();
        }

        if (count == 5 && Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (count == 5 && Input.GetKeyDown(KeyCode.N))
        {
            Starttext();
        }
    }
}