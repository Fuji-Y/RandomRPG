using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControllerAS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("敵に当たった");
            //col.GetComponent<Enemy>().SetState("damage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
