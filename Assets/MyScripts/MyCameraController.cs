using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離x
    private float differencex;
    //Unityちゃんとカメラの距離z
    private float differencez;
    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（x座標）の差を求める
        this.differencex = unitychan.transform.position.x - this.transform.position.x;
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.differencez = unitychan.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(this.unitychan.transform.position.x - differencex, this.transform.position.y, this.unitychan.transform.position.z - differencez);
    }
}