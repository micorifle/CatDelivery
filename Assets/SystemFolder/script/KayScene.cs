using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KayScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("TutorialScene");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("GameScene");
            //SceneManager.LoadScene("PlayScene");
        }
	}
}
