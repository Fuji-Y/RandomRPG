using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    private bool isButtonDown = false;
    private bool isLoadButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || this.isButtonDown)
        {
            DontDestroyOnLoadcs.Load = false;
            Debug.Log("StartButton");　//後で消す
            SceneManager.LoadScene("GameScene");
        }

        if (Input.GetKey(KeyCode.Space) || this.isLoadButtonDown)
        {
            DontDestroyOnLoadcs.Load = true;
            Debug.Log("LoadButton");　//後で消す
            SceneManager.LoadScene("GameScene");
        }
    }

    public void GetMyButtonDown()
    {
        this.isButtonDown = true;
    }

    public void GetMyLoadButtonDown()
    {
        this.isLoadButtonDown = true;
    }
}
