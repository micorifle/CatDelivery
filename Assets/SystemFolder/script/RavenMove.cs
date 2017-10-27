using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// カラスの移動制御クラス
/// </summary>

public class RavenMove : MonoBehaviour {

    float posLength;        //プレイヤーとの距離
    Transform player;       //プレイヤーの位置
    public GameObject poo;  //糞のオブジェクト(Prefab)
    GameObject unko;        //インスタンス作成用オブジェクト
    bool pooSwitch = true;  //糞を出すかどうか
	// Use this for initialization
	void Start () {
        //プレイヤーオブジェクトの位置をplayer変数に保存
        player = GameObject.Find("catPre").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //距離変数に自分の位置-プレイヤの位置を保存
        posLength = transform.position.x - player.position.x;

        //距離が1未満の時
        if (posLength < 1)
        {
            if (pooSwitch == true)
            {
                poo.transform.position = transform.position;    //pooの位置をカラスと同期
                unko = Instantiate(poo);                        //インスタンスを作成
                pooSwitch = false;                              //もうでない
            }
        }

        //距離が10以上の時
        if (posLength < -10)
        {
            //自分と糞をデストロイ
            Destroy(gameObject);
            Destroy(unko);
        }
        //左に移動
        transform.Translate(-0.05f,0,0);

    }
}
