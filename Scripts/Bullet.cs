using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Vector3 iniPos;
	public float speed;

	void OnEnable()
	{
		iniPos = transform.position;
	}


	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
		if(Vector3.Distance(transform.position, iniPos) > 50)
			GameObject.Find("bulletPool").GetComponent<ObjPool>().recovery(gameObject);
	}
}
