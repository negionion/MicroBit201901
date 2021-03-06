﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {
	private float timing;
	public ObjPool bulletPool;
	public float fireRate = 0.3f;

	[SerializeField]
	private Transform gunL;
	[SerializeField]
	private Transform gunR;

	[SerializeField]
	private Image meter;
	private int total = 1000, nowValue;
	// Use this for initialization
	void Start () {
		nowValue = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		timing += Time.deltaTime;
		fire();
			
	}
	void fire()
	{
		if (!Control.attack() || timing < fireRate || nowValue <= 0)
			return;
		timing = 0;		
		bulletPool.reuse(gunL.position);
		bulletPool.reuse(gunR.position);
		nowValue -= 50;
		nowValue = Mathf.Clamp(nowValue, 0, 1000);
		meter.fillAmount = (float)nowValue / total;
	}

	void FixedUpdate()
	{
		if (!Control.attack())
		{
			nowValue += 10;
			nowValue = Mathf.Clamp(nowValue, 0, 1000);
			meter.fillAmount = (float)nowValue / total;
		}
		
	}
}
