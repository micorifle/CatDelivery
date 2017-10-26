using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物とのあたり判定を区別するスクリプト
public class Sensor : MonoBehaviour
{
    bool shieldSwitch = false;//シールドをとったぜスイッチOFF！！
    bool timeSwitch = false;//時間計測スイッチOFF！！
    float time = 3.0f;//秒数
    GameObject cat;

    GameObject audioManager;

    // Use this for initialization
    void Start()
    {
        cat = transform.parent.gameObject;

        audioManager = GameObject.Find("AudioManager");//SEがあるスクリプトを参照
        


    }

    // Update is called once per frame
    void Update()
    {
        if (shieldSwitch == true)//シールドをとったぜスイッチON！！
        {
            //↓ネコの色を変える
            cat.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 1.0f, 1.0f);
            if (Input.GetKeyDown(KeyCode.B))//Bボタンを押したら！！
            {
                audioManager.GetComponent<AudioManager>().SE_tate();//シールドのSEをならす
                timeSwitch = true;//時間計測スイッチON！！
            }
        }
        if (timeSwitch == true)//シールドを3秒間発動するためのスクリプト
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
            audioManager.GetComponent<AudioManager>().SE_fish();//SEならす

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
