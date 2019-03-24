using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public bool isMyturn = true;

    //時間計測用の数字
    public float delta = 0;
    //待ってほしい時間
    public float span = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
    }
}
