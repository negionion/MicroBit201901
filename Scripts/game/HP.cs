using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
	[SerializeField]
	private Image meter;

	private int hp = 3;

	[SerializeField]
	private PauseUI menu;
	// Use this for initialization

	public void add(int n = 1)
	{
		hp += n;
		hp = hp > 3 ? 3 : hp;
		meter.fillAmount = hp / 3f;
	}

	public void lose(int n = 1)
	{
		hp -= n;
		meter.fillAmount = hp / 3f;
		if (hp == 0)
		{
			Invoke("gameover", 1f);			
		}
	}

	private void gameover()
	{
		menu.pause();
		menu.pauseButton.SetActive(false);
	}
}
