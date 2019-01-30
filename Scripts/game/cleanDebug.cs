using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
public class cleanDebug : MonoBehaviour {

	public Text txtDebug;
	public Text testtxt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void cleanScreen()
	{
		txtDebug.text = "";
		testtxt.text = "";
	}
	public void testSend(string str)
	{
		Control.analysis(str);
	}
}
