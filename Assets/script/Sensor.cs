using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    bool shieldSwitch = false;
    bool timeSwitch = false;
    float time = 3.0f;
    GameObject cat;

    GameObject audioManager;

    // Use this for initialization
    void Start()
    {
        cat = transform.parent.gameObject;

        audioManager = GameObject.Find("AudioManager");
        


    }

    // Update is called once per frame
    void Update()
    {
        if (shieldSwitch == true)
        {
            
            cat.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
            if (Input.GetKeyDown(KeyCode.B))
            {
                audioManager.GetComponent<AudioManager>().SE_tate();
                timeSwitch = true;
            }
        }
        if (timeSwitch == true)
        {
            time = time - 1 * Time.deltaTime;
            cat.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1.0f, 1.0f);
            if (time < 0)
            {
                cat.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                time = 3.0f;
                shieldSwitch = false;
                timeSwitch = false;
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Fish")//接触したのが魚tagだったら
        {
            audioManager.GetComponent<AudioManager>().SE_fish();

            //HpDirectorを見つける
            GameObject hgdirector = GameObject.Find("HpDirector");
            //IncrementHpメソッドを呼び出す
            hgdirector.GetComponent<HpBerDirector>().IncrementHp();

            Destroy(collision.gameObject);//接触した魚を破壊
        }

        if (collision.tag == "Setaria")//接触したのがねこじゃらしtagだったら
        {
            //親オブジェクトを保存
            GameObject cat = transform.parent.gameObject;
            //Stopメソッドを呼び出す
            cat.GetComponent<PlayerController>().Stop(3.0f);

            Destroy(collision.gameObject);//接触したねこじゃらしを破壊
        }

        if (collision.tag == "Cucumber")//接触したのがきゅうりtagだったら
        {
            audioManager.GetComponent<AudioManager>().SE_acquisition();

            //親オブジェクトを保存
            GameObject cat = transform.parent.gameObject;
            //SpeedUpメソッドを呼びだす
            cat.GetComponent<PlayerController>().SpeedUp();


            Destroy(collision.gameObject);//接触したきゅうりを破壊
        }

        if (collision.tag == "Enemy")//接触したのが敵tagだったら
        {
            audioManager.GetComponent<AudioManager>().SE_enemy();
            //HpDirectorをみつける
            GameObject hgdirector = GameObject.Find("HpDirector");
            //DecreaseHpメソッドを呼び出す
            if (timeSwitch == false)
            {
                hgdirector.GetComponent<HpBerDirector>().DecreaseHp();
                hgdirector.GetComponent<HpBerDirector>().BoxHpDown();
            }

            Destroy(collision.gameObject);//接触したねずみを破壊
        }
        if (collision.tag == "Unko")
        {
            audioManager.GetComponent<AudioManager>().SE_unko();

            GameObject hgdirector = GameObject.Find("HpDirector");
            if (timeSwitch == false)
            {
                hgdirector.GetComponent<HpBerDirector>().DecreaseHp();
                hgdirector.GetComponent<HpBerDirector>().BoxHpDown();
            }
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Shield")
        {
            audioManager.GetComponent<AudioManager>().SE_acquisition();
            shieldSwitch = true;
            Destroy(collision.gameObject);
        }
    }
}
