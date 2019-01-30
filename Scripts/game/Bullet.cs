using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Vector3 iniPos;
	public float speed;

	void OnEnable()
	{
		iniPos = transform.position;
		transform.rotation = GameObject.Find("character").GetComponent<Transform>().rotation;
	}


	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		if(Vector3.Distance(transform.position, iniPos) > 50)
			GetComponentInParent<ObjPool>().recovery(gameObject);
	}

	void OnTriggerEnter(Collider trig)
	{
		if (trig.tag == "enemy")
		{
			Debug.Log("hit!");

			//test
			GameObject.Find("boomPool").GetComponent<ObjPool>().reuse(transform.position);

			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
	}
}
