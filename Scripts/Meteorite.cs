using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(
				Random.Range(0f, 360f),
				Random.Range(0f, 360f),
				Random.Range(0f, 360f)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider trig)
	{
		if (trig.tag == "attack")
		{
			Score.add();
			GameObject.Find("boomPool").GetComponent<ObjPool>().reuse(transform.position);
			EnemyCreat.meteoriteCount--;
			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
		else if(trig.tag == "recovery")
		{
			EnemyCreat.meteoriteCount--;
			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
	}
}
