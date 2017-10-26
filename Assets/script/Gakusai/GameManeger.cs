using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// UIやシーン移行設定クラス
/// </summary>

public class GameManeger : MonoBehaviour
{

    static float timeCount = 60;    //制限時間
    float loadLength;               //旗までの距離

    GUIStyle style;
    GUIStyleState timeColor;
    Transform player;
    Transform flag;

    void Start()
    {

        style = new GUIStyle();
        timeColor = new GUIStyleState();
        timeColor.textColor = Color.black;  //黒色
        style.normal = timeColor;           //

        player = GameObject.Find("catPre").transform;
        flag = GameObject.Find("flag").transform;

    }

    void Update()
    {

        //制限時間
        timeCount = timeCount - 1 * Time.deltaTime;

        //時間が0になったらゲームオーバー
        if (timeCount < 1)
        {
            SceneManager.LoadScene("GameOver");
        }

        loadLength = flag.position.x - player.position.x;
        //距離が1未満になるとクリア
        if (loadLength < 1)
        {
            SceneManager.LoadScene("ClearScene");
        }


    }

    private void OnGUI()
    {
        //時間表記
        GUI.Label(new Rect(650, 20, 400, 300), "宅配限界時間まであと " + timeCount.ToString("00") + "秒", style);

        //旗までの距離
        GUI.Label(new Rect(650, 40, 400, 300), "ゴールまであと " + loadLength.ToString("00") + "m", style);

    }
    //staticでクリアシーンと変数を共有
    public static float TimeScore()
    {
        return timeCount;
    }


}
