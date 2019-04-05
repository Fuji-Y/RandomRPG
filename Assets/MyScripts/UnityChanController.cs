using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    /*入力させる
    private InputField inputField;*/
    //前進するための力
    public float forwardForce = 300.0f; //150
    //動きを減速させる係数
    private float coefficient = 0.9f;
    //立ち止まる判定
    public bool stop = false;
    //public bool one = true;
    //ルート選択時に表示するテキスト
    private GameObject stateText;
    //Button
    ButtonSizeController buttonController;

    // Use this for initialization
    void Start()
    {
        if (DontDestroyOnLoadcs.mob && DontDestroyOnLoadcs.lose == false)
        {
            Vector3 posy = transform.position;
            posy.y = 0.6f;
            transform.position = posy;
            Vector3 posz = transform.position;
            posz.z = 125;
            transform.position = posz;
            DontDestroyOnLoadcs.mob = false;
        }

        if (DontDestroyOnLoadcs.Bukiya)
        {
            Vector3 posy = transform.position;
            posy.y = 0.6f;
            transform.position = posy;
            Vector3 posz = transform.position;
            posz.z = 140;
            transform.position = posz;
            DontDestroyOnLoadcs.Bukiya = false;
        }

        if (DontDestroyOnLoadcs.mob) DontDestroyOnLoadcs.mob = false;
        if (DontDestroyOnLoadcs.boss) DontDestroyOnLoadcs.boss = false;

        if(DontDestroyOnLoadcs.color == 1)
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

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 0.5f);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("ChoiceText");

        this.buttonController = GameObject.Find("Scripts/ButtonSize").GetComponent<ButtonSizeController>();
    }

    void Update()
    {
        //立ち止まるためにUnityちゃんの動きを減衰する
        if (this.stop)
        {
            this.forwardForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        //Unityちゃんに前方向の力を加える
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if (other.gameObject.tag == "FirstGoalTag")
        {
            //stateTextに選択を求める言葉を表示
            this.stateText.GetComponent<Text>().text = "←/→のどちらかを選択してください";
            this.stop = true;
        }

        //コース突入時の場合
        if (other.gameObject.tag == "TurnRightTag" || other.gameObject.tag == "TurnLeftTag")
        {
            //directionのz軸の方向を向かせる
            Vector3 direction = transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (other.gameObject.tag == "LeftTag")
        {
            //directionの-x軸の方向を向かせる
            Vector3 direction = transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }

        if (other.gameObject.tag == "RightTag")
        {
            Vector3 direction = transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        //アイテムや敵に接触の場合
        if (other.gameObject.tag == "CoinTag")
        {
            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            //お金を増やす
            DontDestroyOnLoadcs.money += 100;
        }

        if (other.gameObject.tag == "PortionTag")
        {
            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            //MPを増やす
            DontDestroyOnLoadcs.myMP = DontDestroyOnLoadcs.myMAXMP;
        }

        if (other.gameObject.tag == "ZolrikTag")
        {
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            DontDestroyOnLoadcs.mob = true;
            //Scene切り替え
            SceneManager.LoadScene("AttackingScene");
        }

        if (other.gameObject.tag == "BukiyaTag")
        {
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            DontDestroyOnLoadcs.Bukiya = true;
            //Scene切り替え
            SceneManager.LoadScene("BuyingScene");
        }

        if (other.gameObject.tag == "ZolrikMercenaryTag")
        {
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            DontDestroyOnLoadcs.boss = true;
            //Scene切り替え
            SceneManager.LoadScene("AttackingScene");
        }
    }

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "FirstGoalTag")
        {
            if (Input.GetKey(KeyCode.LeftArrow) || buttonController.isLButtonDown)
            {
                //directionの-X軸の方向を向かせる
                other.gameObject.tag = "Untagged";
                Vector3 direction = transform.position;
                transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                this.stop = false;
                this.forwardForce = 500.0f;
                this.myAnimator.speed = 1.0f;
                this.stateText.GetComponent<Text>().text = null;
               
            }
            if (Input.GetKey(KeyCode.RightArrow) || buttonController.isRButtonDown)
            {
                //directionのX軸の方向を向かせる
                other.gameObject.tag = "Untagged";
                Vector3 direction = transform.position;
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                this.stop = false;
                this.forwardForce = 500.0f;
                this.myAnimator.speed = 1.0f;
                this.stateText.GetComponent<Text>().text = null;
            }
        }
    }

    /*
     void InputLogger()
     {
         string inputvalue = inputField.text;
         int inputValue = Convert.ToInt32(inputvalue);
         if (inputValue == 1 || inputValue == 2)
             {
                 //directionの-X軸の方向を向かせる
                 Vector3 direction = transform.position;
                 transform.rotation = Quaternion.LookRotation(new Vector3
                     (-direction.x, 0, 0));
             this.one = false;
             }
         if (inputValue == 3 || inputValue == 4)
         {
             //directionのX軸の方向を向かせる
             Vector3 direction = transform.position;
             transform.rotation = Quaternion.LookRotation(new Vector3
                 (direction.x, 0, 0));
             this.one = false;
         }
         this.stop = false;
     }
     */
}
