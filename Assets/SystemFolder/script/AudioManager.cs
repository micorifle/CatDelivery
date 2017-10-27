using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音を管理するクラス
/// </summary>

public class AudioManager : MonoBehaviour
{
    //音を鳴らす元
    AudioSource gameSE;
 
    //音を保存する
    public AudioClip acquisitionSE;
    public AudioClip tateSE;
    public AudioClip fishSE;
    public AudioClip unkoSE;
    public AudioClip enemySE;

    // Use this for initialization
    void Start()
    {
        gameSE = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //音を鳴らすメソッド
    public void SE_acquisition()
    {
        
        gameSE.clip = acquisitionSE;
        gameSE.Play();

    }
    public void SE_tate()
    {
        gameSE.clip = tateSE;
        gameSE.Play();
    }
    public void SE_fish()
    {
        gameSE.clip = fishSE;
        gameSE.Play();
    }
    public void SE_unko()
    {
        gameSE.clip = unkoSE;
        gameSE.Play();
    }
    public void SE_enemy()
    {
        gameSE.clip = enemySE;
        gameSE.Play();
    }

}
