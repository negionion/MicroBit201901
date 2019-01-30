using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
	[SerializeField]
	private HP hp;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trig)
	{
		if (trig.tag == "enemy" && tag == "normal")
		{
			Debug.Log("Boom!!!!!!!!!!!!!");
			hp.lose();
			GameObject.Find("boomPool").GetComponent<ObjPool>().reuse(transform.position);
		}
	}
}
