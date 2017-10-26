using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HPバーが増減するクラス
/// </summary>
public class HpBerDirector : MonoBehaviour
{

    GameObject hpGage;
    GameObject boxGage;
    GameObject player;
    float count = 0;
    static float coler = 1.0f;

    void Start()
    {
        //ヒエラルキー内にあるオブジェクトを探す
        hpGage = GameObject.Find("hpGage");
        player = GameObject.FindGameObjectWithTag("Player");
        boxGage = GameObject.Find("boxGage");
    }


    void Update()
    {
        //体力0になったら
        if (hpGage.GetComponent<Image>().fillAmount == 0)
        {
            count = 5.0f;                                       //5秒カウント
            player.GetComponent<PlayerController>().Stop(count);//停止
        }
        //カウントする
        if (count > 0)
        {
            count = count - 1 * Time.deltaTime;
            hpGage.GetComponent<Image>().fillAmount += 0.002f;  //hpGage回復
        }
    }

    public void DecreaseHp()
    {
        //HPバー減少
        hpGage.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void IncrementHp()
    {
        //HPバー増加
        hpGage.GetComponent<Image>().fillAmount += 0.2f;
    }
    public void DownHP()
    {
        //歩くごとにHPバーが減っていく
        hpGage.GetComponent<Image>().fillAmount -= 0.001f;
    }
    public void BoxHpDown()
    {
        //荷物のカラーを赤くしていく
        coler -= 0.2f;
        boxGage.GetComponent<Image>().color = new Color(1.0f,coler,coler,1.0f);
    }
    //staticでクリアシーンと変数を共有
    public static float BoxScore()
    {
        return coler;
    }
}
