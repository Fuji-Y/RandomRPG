﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraControllerBS : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    public GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        //this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}