using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

	void Awake()
	{
		BTsocket.disConnect();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void gameStart()
	{
		SceneManager.LoadScene("connect");
	}
}
