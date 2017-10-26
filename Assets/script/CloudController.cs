using UnityEngine;
using System.Collections;
/// <summary>
/// 背景の雲を移動させるクラス
/// </summary>

public class CloudController : MonoBehaviour
{
    float move;
    public float spritemove=0; 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
            move = spritemove;
        
        transform.Translate(move, 0f, 0f);  //移動取得

    }
}
