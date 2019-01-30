using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(
				Random.Range(-15f, 15f),
				Random.Range(-30f, 30f),
				0f), Space.Self);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * 7);
	}

	void OnTriggerEnter(Collider trig)
	{
		if (trig.tag == "attack")
		{
			Score.add(3);
			GameObject.Find("boomPool").GetComponent<ObjPool>().reuse(transform.position);
			EnemyCreat.enemyFighterCount--;
			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
		else if (trig.tag == "recovery")
		{
			EnemyCreat.enemyFighterCount--;
			GetComponentInParent<ObjPool>().recovery(gameObject);
		}
	}
}
