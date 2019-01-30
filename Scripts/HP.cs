using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {
	[SerializeField]
	private Image meter;

	private int hp;

	[SerializeField]
	private PauseUI menu;
	// Use this for initialization
	void Start () {
		hp = 3;
	}
	
	// Update is called once per frame
	void Update () {
		meter.fillAmount = hp / 3f;
	}

	public void add(int n = 1)
	{
		hp += n;
		hp = hp > 3 ? 3 : hp;
	}

	public void lose(int n = 1)
	{
		hp -= n;
		if (hp == 0)
		{
			menu.pause();
			menu.pauseButton.SetActive(false);
		}
	}
	public int get()
	{
		return hp;
	}
}
