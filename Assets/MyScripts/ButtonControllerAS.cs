using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerAS : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform button1;
    private RectTransform button2;
    private RectTransform button3;
    private RectTransform button4;

    //ボタン1押下の判定
    public bool isButton1Down = false;
    //ボタン2押下の判定
    public bool isButton2Down = false;
    //ボタン3押下の判定
    public bool isButton3Down = false;
    //ボタン4押下の判定
    public bool isButton4Down = false;

    public float x, y;  //変更したいサイズ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ボタン1を押し続けた場合の処理
    public void GetMyButton1Down()
    {
        this.isButton1Down = true;
    }

    //ボタン1を離した場合の処理
    public void GetMyButton1Up()
    {
        this.isButton1Down = false;
    }

    //ボタン2を押し続けた場合の処理
    public void GetMyButton2Down()
    {
        this.isButton2Down = true;
    }

    //ボタン2を離した場合の処理
    public void GetMyButton2Up()
    {
        this.isButton2Down = false;
    }

    //ボタン3を押し続けた場合の処理
    public void GetMyButton3Down()
    {
        this.isButton3Down = true;
    }

    //ボタン3を離した場合の処理
    public void GetMyButton3Up()
    {
        this.isButton3Down = false;
    }

    //ボタン4を押し続けた場合の処理
    public void GetMyButton4Down()
    {
        this.isButton4Down = true;
    }

    //ボタン4を離した場合の処理
    public void GetMyButton4Up()
    {
        this.isButton4Down = false;
    }
}
