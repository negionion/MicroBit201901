using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreat : MonoBehaviour {
	[SerializeField]
	private Transform character;

	[SerializeField]
	private ObjPool meteoritePool1;
	[SerializeField]
	private ObjPool meteoritePool2;
	public int meteoriteQuantity = 20;
	static public int meteoriteCount = 0;
	public float meteoriteRate = 0.5f;
	private float meteoriteTimer = 0f;

	[SerializeField]
	private ObjPool enemyFighterPool1;
	[SerializeField]
	private ObjPool enemyFighterPool2;
	public int enemyFighterQuantity = 10;
	static public int enemyFighterCount = 0;	
	public float enemyFighterRate = 1f;
	private float enemyFighterTimer = 0f;

	private float metTimeing = 0;
	private float enfTimeing = 0;

	// Use this for initialization
	void Start () {
		meteoriteCount = 0;
		enemyFighterCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		metTimeing += Time.deltaTime;
		enfTimeing += Time.deltaTime;
		if (metTimeing >= meteoriteTimer && meteoriteCount < meteoriteQuantity)
		{
			metTimeing = 0;
			meteoriteTimer = Random.Range(meteoriteRate - 0.5f, meteoriteRate);
			Vector3 pos = new Vector3(
				Random.Range(-15, 15),
				Random.Range(-8, 12),
				Random.Range(character.position.z + 60, character.position.z + 80));
			meteoriteCount++;
			if (Random.Range(0f, 1f) < 0.5f)
			{
				meteoritePool1.reuse(pos);
			}
			else
			{
				meteoritePool2.reuse(pos);
			}			
		}

		if (enfTimeing >= enemyFighterTimer && enemyFighterCount < enemyFighterQuantity)
		{
			enfTimeing = 0;
			enemyFighterTimer = Random.Range(enemyFighterRate - 1f, enemyFighterRate);
			Vector3 pos = new Vector3(
				Random.Range(-7, 7),
				Random.Range(-1, 7),
				Random.Range(character.position.z + 60, character.position.z + 80));
			enemyFighterCount++;
			if (Random.Range(0f, 1f) < 0.3f)
			{
				enemyFighterPool1.reuse(pos);
			}
			else
			{
				enemyFighterPool2.reuse(pos);
			}
		}

	}
}
