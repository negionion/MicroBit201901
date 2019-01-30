using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPool : MonoBehaviour {

	public GameObject preObj;       //預製物件
	private Queue<GameObject> pool = new Queue<GameObject>();

	// Use this for initialization
	void Start()
	{
		creatObj();
	}

	//產生物件池中的物件
	private void creatObj(int poolSize = 5)
	{
		GameObject _obj;
		for (int i = 0; i < poolSize; i++)
		{			
			_obj = Instantiate(preObj);
			_obj.SetActive(false);
			_obj.transform.SetParent(transform, false);
			pool.Enqueue(_obj);
		}
	}

	//取出物件
	public void reuse(Vector3 iniPosition)
	{
		if (pool.Count == 0)
			creatObj();
		GameObject _reuse = pool.Dequeue();
		_reuse.transform.position = iniPosition;    //定義物件位置
		_reuse.SetActive(true);                     //顯示物件		
	}

	public void recovery(GameObject reObj)
	{
		pool.Enqueue(reObj);
		reObj.SetActive(false);
	}
}
