using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSizeController : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rbutton;
    private RectTransform lbutton;
    //左ボタン押下の判定
    public bool isLButtonDown = false;
    //右ボタン押下の判定
    public bool isRButtonDown = false;

    public float x, y;  //変更したいサイズ
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
