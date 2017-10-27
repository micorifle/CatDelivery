using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    
    public void NextScene(string sceneName)
    {
        //もしボタン発動時にSE鳴らしたいならお使いください
        //ButtonSound.PlayOneShot(rankingButtonSound.clip);

        SceneManager.LoadScene(sceneName);
    }
}
