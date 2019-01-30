using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject pauseUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pause()
	{
		pauseUI.SetActive(!pauseUI.activeSelf);
		if (pauseUI.activeSelf)
		{
			Time.timeScale = 0;
			pauseButton.GetComponentInChildren<Text>().text = "►";
		}
		else
		{
			Time.timeScale = 1;
			pauseButton.GetComponentInChildren<Text>().text = "||";
		}
		
	}

	public void quit()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("home");
	}

	public void again()
	{
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync("loading");
	}
}
