using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーの設定管理クラス
/// </summary>
public class PlayerController : MonoBehaviour
{


    Rigidbody2D rigid2D;
    Animator animator;
    GameObject hpDirector;

    float count = 0.0f;         //ギミック発動時間
    float speedx;               //
    float pullPower;            //引きよせる力
    bool speedSwitch = false;   //
    bool downHpSwitch = true;


    float jumpForce = 680.0f;  //
    float walkForce = 30.0f;   //
    float maxWalkSpeed = 2.0f; //


    void Start()
    {

        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hpDirector = GameObject.Find("HpDirector");
    }


    void Update()
    {

        //二段ジャンプ禁止
        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
        {
            //
            animator.SetTrigger("JumpTrigger");
            rigid2D.AddForce(transform.up * jumpForce);
        }

        //
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (downHpSwitch == true)
            {
                HpDown();
            }
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (downHpSwitch == true)
            {
                HpDown();
            }
            key = -1;
        }

        speedx = Mathf.Abs(rigid2D.velocity.x);

        //
        if (speedx < maxWalkSpeed)
        {
            rigid2D.AddForce(transform.right * key * walkForce);

        }

        //
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //
        if (rigid2D.velocity.y == 0)
        {
            animator.SetBool("Walk", true);
            animator.speed = speedx / 2.0f;
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.speed = 1.0f;
        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

        if (speedSwitch == true)    //GimmickManager移植
        {
            //カウント
            count = count - 1 * Time.deltaTime;

            if (count <= 0)
            {
                maxWalkSpeed = 2.0f;    //通常スピードに戻す
                downHpSwitch = true;
                jumpForce = 680;
                speedSwitch = false;
                //カウントリセット
                count = 0;
            }
        }

    }

    void OnTriggerStay2D(Collider2D collision)      //接触している間
    {
        if (collision.tag == "Setaria")             //ねこじゃらしtagに接触したら
        {
            GameObject setaria = collision.gameObject;//接触しているオブジェクトを保存
            Vector2 setariaPos = setaria.transform.position;//接触したオブジェクトの座標を保存

            if (transform.position.x < setariaPos.x)//ねこじゃらしの左側にいるとき
            {
                pullPower = 0.5f;
            }
            else if (transform.position.x > setariaPos.x)//ねこじゃらしの右側にいるとき
            {
                pullPower = -0.5f;
            }
            else
            {
                pullPower = 0.0f;
            }

            if (speedx < maxWalkSpeed)              //上の方にあるのと同じやつ(keyがpullPowerに変わっただけ)
            {
                rigid2D.AddForce(transform.right * pullPower * walkForce);
            }
        }
    }


    public void Stop(float timeCount)//動けない
    {
        downHpSwitch = false;
        maxWalkSpeed = 0;
        jumpForce = 0;
        //カウントは引数で制御
        count = timeCount;
        speedSwitch = true;
    }
    public void SpeedUp()//スピードアップ
    {
        downHpSwitch = false;
        maxWalkSpeed = 10.0f;
        //3秒カウント
        count = 3.0f;
        speedSwitch = true;
    }
    void HpDown()
    {
        hpDirector.GetComponent<HpBerDirector>().DownHP();  //移動するとhpバー減少,しないと止まる
    }

}