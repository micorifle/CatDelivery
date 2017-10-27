using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// クリアシーンのスコア管理クラス
/// </summary>

public class ScoreManeger : MonoBehaviour {

    float boxScore;     //荷物のスコアを入れる
    float timeScore;    //時間のスコアを入れる
    string timeText;    //時間の評価をいれる
    string boxText;     //荷物の評価を入れる
    public GameObject scoreText1;
    public GameObject scoreText2;

	// Use this for initialization
	void Start () {
        //scoreText1 = GameObject.Find("score");
        //scoreText1 = GameObject.Find("score");
        boxScore = HpBerDirector.BoxScore();    //HpBerDirectorの荷物カラーを取得
        timeScore = GameManeger.TimeScore();    //GameManegerの残り時間を取得
	}
	
	// Update is called once per frame
	void Update () {
        //荷物カラーによってセリフ変化
        if (boxScore <= 0.4f)
        {
            boxText = "中身ぐちゃぐちゃよ";
        }
        else if (boxScore <= 0.8f)
        {
            boxText = "荷物潰れてない？";

        }
        else if (boxScore == 1.0f)
        {
            boxText = "荷物カンペキ！";
        }

        //残り時間によってによってセリフ変化
        if (timeScore < 10)
        {
            timeText = "遅いじゃない…";
        }
        else if (timeScore > 10 && timeScore < 40)
        {
            timeText = "まぁまぁね…";
        }
        else
        {
            timeText = "さすが、早いわね～";
        }
        //テキスト表示
        scoreText1.GetComponent<Text>().text = timeText;
        scoreText2.GetComponent<Text>().text =  boxText;
        

    }
             

}
