using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
	[SerializeField]
	private GameObject block;
	[SerializeField]
	private GameObject fighter;
	[SerializeField]
	private Image meter;
	private int total = 1000, nowValue;
	// Use this for initialization
	void Start () {
		nowValue = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		if(Control.block() && nowValue > 0)
		{
			fighter.tag = "attack";
			block.SetActive(true);
		}
		else
		{
			fighter.tag = "normal";
			block.SetActive(false);
		}
		meter.fillAmount = ((float)nowValue / total);
	}

	//每秒50次
	void FixedUpdate()
	{
		if (Control.block())
		{
			nowValue -= 4;
		}
		else
		{
			nowValue += 2;
		}
		nowValue = Mathf.Clamp(nowValue, 0, 1000);
	}
}
