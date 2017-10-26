using UnityEngine;
using System.Collections;

/// <summary>
/// 左右に行ったり来たりさせるクラス
/// </summary>
public class MoveLtoR : MonoBehaviour
{
    private float speed = 1.0f; //移動スピード
    private int dir = -1;        //向き

    bool turnFlg;

    //雲のレイヤーを取得
    public LayerMask cloudLayer;

    //rayの高さのoffset値
    Vector3 rayOffset = new Vector3(2, 0.6f, 0);

    //SpriteRendererの取得
    SpriteRenderer spriterenderer;

    void Start()
    {
        //SpriteRendererの取得
        spriterenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        //rayを発射
        turnFlg = Physics2D.Linecast(transform.position - rayOffset, transform.position - rayOffset + transform.right * 0.6f * dir, cloudLayer);
        //rayの描画(可視化)
        Debug.DrawLine(transform.position - rayOffset, transform.position - rayOffset + transform.right * 0.6f * dir, Color.green);

        if (turnFlg)
        {
            //rayが当たったらTurnメソッドを呼び出す
            Turn();
        }

        transform.Translate(Vector3.right * speed * dir * Time.deltaTime);
    }

    //ターンする
    public void Turn()
    {
        //画像の反転
        spriterenderer.flipX = !spriterenderer.flipX;
        //移動方向の変更
        dir = dir * -1; //向きを反転.
    }
}