using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	static private int score;

	[SerializeField]
	private Text scoreTxt;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreTxt.text = score.ToString();
	}

	static public void add(int n = 1)
	{
		score += n;
	}

	static public int get()
	{
		return score;
	}

}
