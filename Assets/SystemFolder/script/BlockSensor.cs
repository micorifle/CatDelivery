using UnityEngine;

/// <summary>
/// ブロックの当たり判定をみるクラス
/// </summary>
public class BlockSensor : MonoBehaviour
{
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    //ブロック衝突メソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと衝突したか
        if (collision.tag == "Player")
        {
            animator.SetTrigger("CucumberUpTrigger");   //きゅうり上昇

            Destroy(GetComponent<CircleCollider2D>());  //ブロックの判定部分だけ破壊

        }
    }

}
