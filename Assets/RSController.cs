using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSController : MonoBehaviour
{
    public GameObject resultText;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyOnLoadcs.color == 1)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.yellow;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (DontDestroyOnLoadcs.color == 2)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.gray;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.gray;
        }

        if (DontDestroyOnLoadcs.color == 3)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.green;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.green;
        }

        if (DontDestroyOnLoadcs.color == 4)
        {
            GameObject.Find("uwagi").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("Shirts").GetComponent<Renderer>().material.color = Color.cyan;
            GameObject.Find("shirts_sode").GetComponent<Renderer>().material.color = Color.cyan;
        }

        Resulttext();
    }

    void Resulttext()
    {
        resultText = GameObject.Find("ResultText");
        resultText.GetComponent<Text>().text = "倒したボスの数" + DontDestroyOnLoadcs.boskaisuu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
