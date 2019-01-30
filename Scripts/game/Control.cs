using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	static private Vector3 controler;
	static private bool buttonA, buttonB;
	public GameObject character;
	public Camera camera;
	public float moveSpeed = 10.0f;


	public Text txtData;
	static private string txtDebug;
	
	// Use this for initialization
	void Start () {
		controler.Set(0,0,0);
		buttonA = false;
		buttonB = false;
	}
	
	// Update is called once per frame
	void Update () {
		txtData.text = txtDebug;
		txtData.text += "X : " + controler.x + " Y : " + controler.y;

		move();
		
	}
	static public void analysis(string data)
	{
		if (data == "")
			return;
		if(data.Contains("X") && data.Contains("Y"))
		{
			int interval;
			int xStart, yStart;
			xStart = data.IndexOf("X") + 1;	//X123
			yStart = data.IndexOf("Y") + 1; //Y456
			interval = data.IndexOf(",") - xStart;   //X123,Y456
			txtDebug = "X : " + data.Substring(xStart, interval) + "\n";
			txtDebug += "Y : " + data.Substring(yStart) + "\n";
			controler.x = int.Parse(data.Substring(xStart, interval));
			controler.y = int.Parse(data.Substring(yStart));
			//controler = -controler;	//與Micro Bit的轉向相反
		}
		if(data.Contains("A"))
		{
			buttonA = true;
			txtDebug += "bA touch\n";
		}
		else
			buttonA = false;

		if(data.Contains("B"))
		{
			buttonB = true;
			txtDebug += "bB touch\n";
		}
		else
			buttonB = false;
	}

	void move()
	{

		//character.transform.position += (-controler / 10f) * Time.deltaTime;
		//character.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
		character.transform.Translate(
			(-controler.x / 10f) * Time.deltaTime,
			(-controler.y / 12f) * Time.deltaTime,
			1f * Time.deltaTime * moveSpeed,
			Space.World);
		
		//設定座標區間在(-7~7, -1~7, 任意)，使其不超出攝影機範圍
		character.transform.position = new Vector3(
			Mathf.Clamp(character.transform.position.x, -7, 7),
			Mathf.Clamp(character.transform.position.y, -1, 7),
			character.transform.position.z);

		character.transform.rotation = Quaternion.Euler(controler.y / 1.7f, 0, controler.x / 1.5f);

		camera.transform.position = new Vector3(
			camera.transform.position.x,
			camera.transform.position.y,
			character.transform.position.z - 10f);
		
		//Mathf.LerpAngle(character.transform.rotation.z, controler.x, Time.deltaTime)
	}

	static public bool attack()
	{
		return buttonA;
	}

	static public bool block()
	{
		return buttonB;
	}



}
