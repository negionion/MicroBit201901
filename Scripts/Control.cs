using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	static private Vector3 controler;
	static private bool buttonA, buttonB;
	public GameObject character;
	public Camera camera;
	public Text txtData;
	static private string txtDebug;
	public float moveSpeed = 10.0f;
	

	
	// Use this for initialization
	void Start () {

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

			
			xStart = data.IndexOf("X") + 2;	//X 123
			yStart = data.IndexOf("Y") + 2; //Y 456
			interval = data.IndexOf(",") - xStart;   //X 123, Y 456
			txtDebug = "X : " + data.Substring(xStart, interval) + "\n";
			txtDebug += "Y : " + data.Substring(yStart) + "\n";
			controler.x = int.Parse(data.Substring(xStart, interval));
			controler.y = int.Parse(data.Substring(yStart));
			//controler = -controler;	//與Micro Bit的轉向相反
		}
		if(data.Contains("bA"))
		{
			buttonA = true;
			txtDebug += "bA touch\n";
		}
		else
			buttonA = false;

		if(data.Contains("bB"))
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
