using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// クリアシーンのスコア管理クラス
/// </summary>

public class ScoreManeger : MonoBehaviour {

    float boxScore;     //荷物のスコアを入れる
    float timeScore;    //時間のスコアを入れる
    string timeText;    //時間の評価をいれる
    string boxText;     //荷物の評価を入れる
    GameObject scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("score");
        boxScore = HpBerDirector.BoxScore();    //HpBerDirectorの荷物カラーを取得
        timeScore = GameManeger.TimeScore();    //GameManegerの残り時間を取得
	}
	
	// Update is called once per frame
	void Update () {
        //荷物カラーによってセリフ変化
        if (boxScore <= 0.4f)
        {
            boxText = "頑張ろう";
        }
        else if (boxScore <= 0.8f)
        {
            boxText = "やりますね";

        }
        else if (boxScore == 1.0f)
        {
            boxText = "すごいです";
        }

        //残り時間によってによってセリフ変化
        if (timeScore < 10)
        {
            timeText = "ギリギリ";
        }
        else if (timeScore > 10 && timeScore < 40)
        {
            timeText = "まぁまぁ";
        }
        else
        {
            timeText = "すごく";
        }
        //テキスト表示
        scoreText.GetComponent<Text>().text = timeText + boxText;

    }
}
