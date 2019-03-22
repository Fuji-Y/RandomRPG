using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CourceGenerator : MonoBehaviour
{
    //ZolrikPrefabを入れる
    public GameObject ZolrikPrefab;
    //CoinPrefabを入れる
    public GameObject CoinPrefab;
    //NoActionPrefabを入れる
    public GameObject NoActionPrefab;
    //PortionPrefabを入れる
    public GameObject PortionPrefab;
    //生成地点のx
    public float Pos;
    //生成地点のz
    private int Posz = 95;

    //ランダムに数字を選ぶ際の数字
    int start = 1;
    int end = 4;


    // Use this for initialization
    void Start()
    {
        List<int> numbers = new List<int>();
        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];
            IfX(ransu);
            Generator();
            numbers.RemoveAt(index);
        }
       
        void IfX(int ransu)
        {

            //乱数とタグを紐付け
            if (ransu == 1)
            {
                Pos = -22.0f;
            }
            if (ransu == 2)
            {
                Pos = -8.0f;
            }
            if (ransu == 3)
            {
                Pos = 9.0f;
            }
            if (ransu == 4)
            {
                Pos = 23.0f;
            }
        }

        void Generator()
        {
            if (numbers.Count == 1)
            {
                GameObject Zolrik = Instantiate(ZolrikPrefab) as GameObject;
                Zolrik.transform.position = new Vector3(Pos, Zolrik.transform.position.y, Posz);
            }

            if (numbers.Count == 2)
            {
                GameObject Coin = Instantiate(CoinPrefab) as GameObject;
                Coin.transform.position = new Vector3(Pos, Coin.transform.position.y, Posz);
            }


            if (numbers.Count == 3)
            {
                GameObject NoAction = Instantiate(NoActionPrefab) as GameObject;
                NoAction.transform.position = new Vector3(Pos, NoAction.transform.position.y, Posz);
            }

            if (numbers.Count == 4)
            {
                GameObject Portion = Instantiate(PortionPrefab) as GameObject;
                Portion.transform.position = new Vector3(Pos, Portion.transform.position.y, Posz);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
