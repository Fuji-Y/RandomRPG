using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerBS2 : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform Ybutton;
    private RectTransform Nbutton;
    //Yボタン押下の判定
    public bool isYButtonDown = false;
    //Nボタン押下の判定
    public bool isNButtonDown = false;

    public float x, y;  //変更したいサイズ
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Yボタンを押し続けた場合の処理
    public void GetMyYButtonDown()
    {
        this.isYButtonDown = true;
    }
    //Yボタンを離した場合の処理
    public void GetMyYButtonUp()
    {
        this.isYButtonDown = false;
    }

    //Nボタンを押し続けた場合の処理
    public void GetMyNButtonDown()
    {
        this.isNButtonDown = true;
    }
    //Nボタンを離した場合の処理
    public void GetMyNButtonUp()
    {
        this.isNButtonDown = false;
    }
}
