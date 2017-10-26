using UnityEngine;

/// <summary>
/// カメラがプレイヤーを追いかけるクラス
/// </summary>
public class CameraController : MonoBehaviour
{

    GameObject player;
    
    void Start()
    {
        //プレイヤーを取得
        player = GameObject.Find("catPre");  //Playerを見つける
    }

    void Update()
    {
        //カメラ追従
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
